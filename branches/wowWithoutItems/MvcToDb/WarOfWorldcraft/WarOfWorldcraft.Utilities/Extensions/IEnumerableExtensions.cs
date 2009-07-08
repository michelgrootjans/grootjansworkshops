using System;
using System.Collections.Generic;
using System.Linq;

namespace WarOfWorldcraft.Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        private static Random rnd = new Random();

        public static bool HasItems<T>(this IEnumerable<T> list)
        {
            return list.Count() > 0;
        }

        public static bool HasNoItems<T>(this IEnumerable<T> list)
        {
            return !list.HasItems();
        }

        public static T PickAny<T>(this IEnumerable<T> items)
        {
            var list = new List<T>(items);
            var index = rnd.Next(0, list.Count);
            return new List<T>(list)[index];
        }
    }
}