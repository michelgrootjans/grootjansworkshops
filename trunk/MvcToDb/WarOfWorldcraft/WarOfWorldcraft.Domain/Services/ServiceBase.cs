using NHibernate;
using WarOfWorldcraft.Utilities.NHibernate;

namespace WarOfWorldcraft.Domain.Services
{
    internal abstract class ServiceBase
    {
        protected static ISession session
        {
            get { return NHibernateHelper.GetCurrentSession(); }
        }
    }
}