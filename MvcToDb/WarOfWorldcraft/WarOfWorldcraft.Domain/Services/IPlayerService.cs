using System.Collections.Generic;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IPlayerService
    {
        IEnumerable<ViewPlayerInfoDto> GetAllPlayers();
        ViewPlayerDto GetPlayer(string player);
        string CreatePlayer(CreatePlayerDto player);
    }

    internal class PlayerService : IPlayerService
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

        public IEnumerable<ViewPlayerInfoDto> GetAllPlayers()
        {
            var players = repository.FindAll<Player>();
            return Map.These(players).ToAListOf<ViewPlayerInfoDto>();
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
    }
}