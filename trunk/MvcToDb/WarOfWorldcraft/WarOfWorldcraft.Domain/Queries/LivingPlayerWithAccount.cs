using System;
using NHibernate;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Queries
{
    public class LivingPlayerWithAccount : IRepositoryCriteria<Player>
    {
        //var player = repository.CreateCriteria<Player>()
        //    .Add(Restrictions.Eq("Account", account))
        //    .Add(Restrictions.Gt("HitPoints", 0))
        //    .UniqueResult<Player>();

        public LivingPlayerWithAccount(string account)
        {
            Account = account;
        }

        public string Account { get; private set; }

        public ICriteria AddCriterionTo(ICriteria criteria)
        {
            return criteria.Add(Restrictions.Eq("Account", Account))
                .Add(Restrictions.Gt("HitPoints", 0));
        }
    }
}