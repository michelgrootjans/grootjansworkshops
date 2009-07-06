using System;
using System.Collections.Generic;
using NHibernate;

namespace WarOfWorldcraft.Utilities.Repository
{
    public interface IRepositoryResult<T>
    {
        IEnumerable<T> List();
        T UniqueResult();
    }

    public class CriteriaResult<T> : IRepositoryResult<T>
    {
        private readonly ICriteria criteria;
        private readonly IRepositoryCriteria<T> queryObject;

        public CriteriaResult(ICriteria criteria, IRepositoryCriteria<T> queryObject)
        {
            this.criteria = criteria;
            this.queryObject = queryObject;
        }

        public IEnumerable<T> List()
        {
            return queryObject.AddCriterionTo(criteria).List<T>();
        }

        public T UniqueResult()
        {
            return queryObject.AddCriterionTo(criteria).UniqueResult<T>();
        }
    }
}