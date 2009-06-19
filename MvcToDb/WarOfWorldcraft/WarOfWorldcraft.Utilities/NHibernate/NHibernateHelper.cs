using NHibernate;
using NHibernate.Cfg;

namespace WarOfWorldcraft.Utilities.NHibernate
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        public static readonly ISessionFactory SessionFactory;
        private static IInterceptor sessionInterceptor;

        static NHibernateHelper()
        {
            SessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            var context = Context.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        public static void CloseSession()
        {
            var context = Context.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null) return;

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            if (SessionFactory != null)
                SessionFactory.Close();
        }

        public static void RegisterInterceptor(IInterceptor interceptor)
        {
            sessionInterceptor = interceptor;
        }

        public static ISession GetNewSession()
        {
            return SessionFactory.OpenSession(sessionInterceptor ?? new EmptyInterceptor());
        }
    }
}