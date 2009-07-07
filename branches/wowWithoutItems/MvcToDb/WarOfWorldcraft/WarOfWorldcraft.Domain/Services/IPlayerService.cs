using System;
using WarOfWorldcraft.Domain.Dto;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Queries;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Repository;
using System.Linq;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IPlayerService
    {
        ViewAllPlayersDto GetAllPlayers();
        ViewPlayerDto GetPlayer(string player);
        string CreatePlayer(CreatePlayerDto player);
        ViewPlayerDto GetCurrentPlayer();
    }

    public interface IInternalPlayerService
    {
        Player GetCurrentPlayer();
    }

    internal class PlayerService : IPlayerService, IInternalPlayerService
    {
        private readonly IRepository repository;
        private readonly IMembershipService membershipService;
        private readonly IPlayerStatsGenerator statsGenerator;

        public PlayerService(IRepository repository, IMembershipService membershipService, IPlayerStatsGenerator statsGenerator)
        {
            this.repository = repository;
            this.membershipService = membershipService;
            this.statsGenerator = statsGenerator;
        }

        public ViewAllPlayersDto GetAllPlayers()
        {
            var players = repository.FindAll<Player>();
            var allPlayers = new ViewAllPlayersDto();

            allPlayers.LivingPlayers = Map.These(players.Where(p => !p.IsDead)).ToAListOf<ViewPlayerInfoDto>();
            allPlayers.DeadPlayers = Map.These(players.Where(p => p.IsDead)).ToAListOf<ViewPlayerInfoDto>();
            
            return allPlayers;
        }

        public ViewPlayerDto GetPlayer(string playerId)
        {
            var player = repository.Load<Player>(playerId.ToLong());
            return Map.This(player).ToA<ViewPlayerDto>();
        }

        public string CreatePlayer(CreatePlayerDto playerDto)
        {
            var account = membershipService.CurrentAccount;
            var player = new Player(playerDto.Name, account);
            statsGenerator.GenerateStatsFor(player);
            repository.Save(player);
            return player.Id.ToString();
        }

        ViewPlayerDto IPlayerService.GetCurrentPlayer()
        {
            return Map.This(GetCurrentPlayer()).ToA<ViewPlayerDto>();
        }

        public Player GetCurrentPlayer()
        {
            var account = membershipService.CurrentAccount;

            var player = repository.Find(new LivingPlayerWithAccount(account)).UniqueResult();

            if (player.IsNull())
                throw new ArgumentException("You don't have a player yet.");
            return player;
        }
    }
}