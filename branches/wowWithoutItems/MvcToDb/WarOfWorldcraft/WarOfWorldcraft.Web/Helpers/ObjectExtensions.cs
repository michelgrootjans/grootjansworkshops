using System.Web.Routing;

namespace WarOfWorldcraft.Web.Helpers
{
    public static class ObjectExtensions
    {
        public static RouteValueDictionary ToIdRoute(this object id)
        {
            return new RouteValueDictionary {{"id", id}};
        }

        public static RouteValueDictionary ToNotificationRoute(this string notification)
        {
            return new RouteValueDictionary {{"notification", notification}};
        }

        public static RouteValueDictionary ToValueRoute(this object value, string key)
        {
            return new RouteValueDictionary {{key, value}};
        }
    }
}