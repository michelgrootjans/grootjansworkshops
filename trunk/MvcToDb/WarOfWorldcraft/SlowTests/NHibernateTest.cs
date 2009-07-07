using HibernatingRhinos.NHibernate.Profiler.Appender;
using NHibernate;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Utilities.Repository;

namespace SlowTests
{
    public abstract class NHibernateTest : StaticContextSpecification
    {
        protected ISession session;
        private ITransaction transaction;
        protected NHibernateRepository repository;

        static NHibernateTest()
        {
            NHibernateProfiler.Initialize();
        }


        protected override sealed void Arrange()
        {
            session = NHibernateHelper.GetCurrentSession();
            transaction = session.BeginTransaction();
            repository = new NHibernateRepository();

            PrepareData();
            PurgeSession();
        }

        protected void PurgeSession()
        {
            session.Flush();
            session.Clear();
        }

        protected abstract void PrepareData();

        protected override sealed void AfterEachTest()
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