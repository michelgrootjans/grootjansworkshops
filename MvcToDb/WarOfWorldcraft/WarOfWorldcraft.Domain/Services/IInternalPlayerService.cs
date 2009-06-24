using System;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;

namespace WarOfWorldcraft.Domain.Services
{
    internal interface IInternalPlayerService
    {
        Player GetCurrentPlayer();
    }

    internal class InternalPlayerService : ServiceBase, IInternalPlayerService
    {
        private readonly IMembershipService membershipService;

        public InternalPlayerService(IMembershipService membershipService)
        {
            this.membershipService = membershipService;
        }

        public Player GetCurrentPlayer()
        {
            var account = membershipService.CurrentAccount;
            var player = session.CreateCriteria<Player>().Add(Restrictions.Eq("Account", account)).UniqueResult<Player>();
            if (player.IsNull())
                throw new ArgumentException("You didn't create a player yet.");
            return player;
        }
    }
}