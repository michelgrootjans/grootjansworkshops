using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IPlayerService
    {
        IEnumerable<T> GetAllPlayers<T>();
        T GetPlayer<T>(string player);
        string CreatePlayer(CreatePlayerDto player);
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

        public IEnumerable<PlayerDto> GetAllPlayers<PlayerDto>()
        {
            var players = repository.FindAll<Player>();
            return Map.These(players).ToAListOf<PlayerDto>();
        }

        public PlayerDto GetPlayer<PlayerDto>(string playerId)
        {
            var player = repository.Load<Player>(playerId.ToLong());
            return Map.This(player).ToA<PlayerDto>();
        }

        public string CreatePlayer(CreatePlayerDto playerDto)
        {
            var account = membershipService.CurrentAccount;
            var player = new Player(playerDto.Name, account);
            statsGenerator.GenerateStatsFor(player);
            repository.Save(player);
            return player.Id.ToString();
        }

        public Player GetCurrentPlayer()
        {
            var account = membershipService.CurrentAccount;

            var player = repository.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Account", account))
                .Add(Restrictions.Gt("HitPoints", 0))
                .UniqueResult<Player>();

            if (player.IsNull())
                throw new ArgumentException("You don't have a player.");
            return player;
        }
    }
}