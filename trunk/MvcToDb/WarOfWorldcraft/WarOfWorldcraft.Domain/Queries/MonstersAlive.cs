using NHibernate;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Queries
{
    internal class MonstersAlive : IRepositoryCriteria<Monster>
    {
        public ICriteria AddCriterionTo(ICriteria criteria)
        {
            criteria.Add(Restrictions.Gt("HitPoints", 0));
            return criteria;
        }
    }
}