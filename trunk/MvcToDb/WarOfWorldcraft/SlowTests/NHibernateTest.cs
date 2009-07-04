using HibernatingRhinos.NHibernate.Profiler.Appender;
using NHibernate;
using NHibernate.Cfg;
using UnitTests.TestUtilities;

namespace SlowTests
{
    public abstract class NHibernateTest : StaticContextSpecification
    {
        private static ISessionFactory sessionFactory; //make this one static because it is slow
        protected ISession session;
        private ITransaction transaction;

        static NHibernateTest()
        {
            NHibernateProfiler.Initialize();
        }


        protected sealed override void Arrange()
        {
            if (sessionFactory == null)
                sessionFactory = new Configuration().Configure().BuildSessionFactory();

            session = sessionFactory.OpenSession();
            transaction = session.BeginTransaction();

            PrepareData();
            PurgeSession();
        }

        protected void PurgeSession()
        {
            session.Flush();
            session.Clear();
        }

        protected abstract void PrepareData();

        protected sealed override void AfterEachTest()
        {
            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
            session.Close();
            session.Dispose();
            session = null;
        }
    }
}