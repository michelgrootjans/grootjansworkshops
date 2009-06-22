using System.Collections.Generic;
using AopAlliance.Intercept;

namespace WarOfWorldcraft.Utilities.NHibernate
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

            try
            {
                var session = NHibernateHelper.GetCurrentSession();
                using (var transaction = session.BeginTransaction())
                {
                    var result = invocation.Proceed();
                    transaction.Commit();
                    return result;
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }
    }
}