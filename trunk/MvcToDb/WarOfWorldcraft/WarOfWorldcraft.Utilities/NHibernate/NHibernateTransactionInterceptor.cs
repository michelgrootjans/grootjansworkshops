using System.Collections.Generic;
using AopAlliance.Intercept;

namespace WarOfWorldcraft.Utilities.NHibernate
{
    public class NHibernateTransactionInterceptor : IMethodInterceptor
    {
        private readonly IList<string> methodsToIgnore;

        public NHibernateTransactionInterceptor()
        {
            methodsToIgnore = new List<string>{"Dispose", "Scripts"};
        }

        public object Invoke(IMethodInvocation invocation)
        {
            if (methodsToIgnore.Contains(invocation.Method.Name)) 
                return invocation.Proceed();

            using (var session = NHibernateHelper.GetCurrentSession())
            using (session.BeginTransaction())
            {
                return invocation.Proceed();
            }
        }
    }
}