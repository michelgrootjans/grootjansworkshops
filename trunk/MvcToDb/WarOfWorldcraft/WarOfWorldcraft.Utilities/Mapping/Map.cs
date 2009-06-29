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

        public static Mapper<From> This<From>(From itemToMap)
        {
            return new Mapper<From>(itemToMap);
        }

        public static ListMapper<From> These<From>(IEnumerable<From> listToMap)
        {
            return new ListMapper<From>(listToMap);
        }
    }

    public class Mapper<From>
    {
        private readonly From from;

        public Mapper(From from)
        {
            this.from = from;
        }

        public To ToA<To>()
        {
            var mapper = Map.locator.GetMapperFor<From, To>();
            return mapper.Map(from);
        }
    }

    public class ListMapper<From>
    {
        private readonly IEnumerable<From> fromList;

        public ListMapper(IEnumerable<From> fromList)
        {
            this.fromList = fromList;
        }

        public IEnumerable<To> ToAListOf<To>()
        {
            foreach (var from in fromList)
                yield return Map.This(from).ToA<To>();
        }
    }
}