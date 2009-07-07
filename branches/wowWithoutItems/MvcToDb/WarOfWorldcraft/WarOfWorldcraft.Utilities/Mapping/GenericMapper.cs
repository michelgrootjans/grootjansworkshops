using AutoMapper;
using Utilities.Mapping;

namespace WarOfWorldcraft.Utilities.Mapping
{
    public class GenericMapperLocator : IMapperLocator
    {
        public IMapper<From, To> GetMapperFor<From, To>()
        {
            return new GenericMapper<From, To>();
        }
    }

    public class GenericMapper<From, To> : IMapper<From, To>
    {
        public To Map(From from)
        {
            return Mapper.Map<From, To>(from);
        }
    }
}