using System.Collections.Generic;
using NHibernate;

namespace WarOfWorldcraft.Utilities.Repository
{
    public interface IRepository
    {
        IEnumerable<T> FindAll<T>() where T : class;
        T Load<T>(object id);
        void Save<T>(T t);
        IRepositoryResult<T> Find<T>(IRepositoryQuery<T> query);
        IRepositoryResult<T> Find<T>(IRepositoryCriteria<T> criteria) where T : class;
    }

    public class NHibernateRepository : IRepository
    {
        public IEnumerable<T> FindAll<T>() where T : class
        {
            return NHibernateHelper.GetCurrentSession().CreateCriteria<T>().List<T>();
        }

        public T Load<T>(object id)
        {
            return NHibernateHelper.GetCurrentSession().Load<T>(id);
        }

        public void Save<T>(T t)
        {
            NHibernateHelper.GetCurrentSession().Save(t);
        }

        public IRepositoryResult<T> Find<T>(IRepositoryQuery<T> query)
        {
            return new QueryResult<T>(CreateQuery(query.QueryString));
        }

        public IRepositoryResult<T> Find<T>(IRepositoryCriteria<T> queryObject) where T : class
        {
            return new CriteriaResult<T>(CreateCriteria<T>(), queryObject);
        }

        private ICriteria CreateCriteria<T>() where T : class
        {
            return NHibernateHelper.GetCurrentSession().CreateCriteria<T>();
        }

        private IQuery CreateQuery(string query)
        {
            return NHibernateHelper.GetCurrentSession().CreateQuery(query);
        }
    }

}