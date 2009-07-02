using System.Collections.Generic;

namespace WarOfWorldcraft.Utilities.Mapping
{
    public static class Map
    {
        internal static IMapperLocator locator;

        public static void Initialize(IMapperLocator mapperLocator)
        {
            locator = mapperLocator;
        }

        public static IMap This<From>(From itemToMap)
        {
            return new Map<From>(itemToMap);
        }

        public static IListMap These<From>(IEnumerable<From> listToMap)
        {
            return new ListMap<From>(listToMap);
        }
    }
}