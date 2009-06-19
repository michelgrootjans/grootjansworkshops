using System.Collections.Generic;
using System.Linq;

namespace WarOfWorldcraft.Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool HasItems<T>(this IEnumerable<T> list)
        {
            return list.Count() > 0;
        }

        public static bool HasNoItems<T>(this IEnumerable<T> list)
        {
            return !list.HasItems();
        }
    }
}