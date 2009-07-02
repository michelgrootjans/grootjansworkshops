using System.Collections;
using System.Security.Principal;

namespace WarOfWorldcraft.Utilities.Repository
{
    public interface IContext
    {
        IDictionary Items { get; }
        IPrincipal Principal { get; }
    }
}