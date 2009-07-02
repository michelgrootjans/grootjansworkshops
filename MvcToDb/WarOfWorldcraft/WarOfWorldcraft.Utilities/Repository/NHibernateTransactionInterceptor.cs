using System.Collections.Generic;
using AopAlliance.Intercept;
using NHibernate;

namespace WarOfWorldcraft.Utilities.Repository
{
    public class NHibernateTransactionInterceptor : IMethodInterceptor
    {
        private readonly IList<string> methodsToIgnore;

        public NHibernateTransactionInterceptor()
        {
            methodsToIgnore = new List<string> {"Dispose", "Scripts"};
        }

        public object Invoke(IMethodInvocation invocation)
        {
            if (methodsToIgnore.Contains(invocation.Method.Name))
                return invocation.Proceed();

            ITransaction transaction = null;
            try
            {
                transaction = NHibernateHelper.GetCurrentSession().BeginTransaction();
                var result = invocation.Proceed();
                transaction.Commit();
                return result;
            }
            catch
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }
    }
}