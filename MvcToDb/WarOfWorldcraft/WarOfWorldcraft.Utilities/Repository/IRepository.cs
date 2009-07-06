using System.Collections.Generic;
using NHibernate;

namespace WarOfWorldcraft.Utilities.Repository
{
    public interface IRepository
    {
        IEnumerable<T> FindAll<T>() where T : class;
        T Load<T>(object id);
        void Save<T>(T t);
        ICriteria CreateCriteria<T>() where T : class;
        IQuery CreateQuery(string query);
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

        public ICriteria CreateCriteria<T>() where T : class
        {
            return NHibernateHelper.GetCurrentSession().CreateCriteria<T>();
        }

        public IQuery CreateQuery(string query)
        {
            return NHibernateHelper.GetCurrentSession().CreateQuery(query);
        }
    }
}