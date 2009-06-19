using Utilities.Mapping;

namespace WarOfWorldcraft.Utilities.Mapping
{
    public class GenericMapper<From, To> : IMapper<From, To>
    {
        public To Map(From from)
        {
            return AutoMapper.Mapper.Map<From, To>(from);
        }
    }
}