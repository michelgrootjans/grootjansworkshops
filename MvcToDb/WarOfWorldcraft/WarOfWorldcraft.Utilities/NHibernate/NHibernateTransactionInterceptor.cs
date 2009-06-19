using AopAlliance.Intercept;

namespace WarOfWorldcraft.Utilities.NHibernate
{
    public class NHibernateTransactionInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            var transaction = NHibernateHelper.GetCurrentSession().BeginTransaction();
            try
            {
                var result = invocation.Proceed();
                transaction.Commit();
                return result;
            }
            catch
            {
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