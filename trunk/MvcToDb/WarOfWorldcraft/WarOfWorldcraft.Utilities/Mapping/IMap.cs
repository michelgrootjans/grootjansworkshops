namespace WarOfWorldcraft.Utilities.Mapping
{
    public interface IMap
    {
        To ToA<To>();
    }

    internal class Map<From> : IMap
    {
        private readonly From from;

        public Map(From from)
        {
            this.from = from;
        }

        public To ToA<To>()
        {
            var mapper = Map.locator.GetMapperFor<From, To>();
            return mapper.Map(from);
        }

    }
}