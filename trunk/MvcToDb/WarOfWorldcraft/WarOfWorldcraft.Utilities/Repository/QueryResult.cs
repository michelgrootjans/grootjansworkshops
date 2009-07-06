using System;
using System.Collections.Generic;
using NHibernate;

namespace WarOfWorldcraft.Utilities.Repository
{
    public class QueryResult<T> : IRepositoryResult<T>
    {
        private readonly IQuery query;

        public QueryResult(IQuery query)
        {
            this.query = query;
        }

        public IEnumerable<T> List()
        {
            return query.List<T>();
        }

        public T UniqueResult()
        {
            return query.UniqueResult<T>();
        }
    }
}