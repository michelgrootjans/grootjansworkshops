using System.Collections.Generic;

namespace WarOfWorldcraft.Utilities.Mapping
{
    public interface IListMap
    {
        IEnumerable<To> ToAListOf<To>();
    }

    internal class ListMap<From> : IListMap
    {
        private readonly IEnumerable<From> fromList;

        public ListMap(IEnumerable<From> fromList)
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