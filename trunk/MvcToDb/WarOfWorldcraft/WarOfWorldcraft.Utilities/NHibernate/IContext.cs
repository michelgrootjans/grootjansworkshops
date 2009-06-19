using System.Collections;
using System.Security.Principal;

namespace WarOfWorldcraft.Utilities.NHibernate
{
    public interface IContext
    {
        IDictionary Items { get; }
        IPrincipal Principal { get; }
    }
}