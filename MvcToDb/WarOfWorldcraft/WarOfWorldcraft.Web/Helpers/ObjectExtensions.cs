using System.Web.Routing;

namespace WarOfWorldcraft.Web.Helpers
{
    public static class ObjectExtensions
    {
        public static RouteValueDictionary ToIdRoute(this object id)
        {
            return new RouteValueDictionary {{"id", id}};
        }
    }
}