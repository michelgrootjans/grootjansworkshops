using System;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IInternalPlayerService
    {
        Player GetCurrentPlayer();
    }

    internal class InternalPlayerService : IInternalPlayerService
    {
        private readonly IRepository repository;
        private readonly IMembershipService membershipService;

        public InternalPlayerService(IRepository repository, IMembershipService membershipService)
        {
            this.repository = repository;
            this.membershipService = membershipService;
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