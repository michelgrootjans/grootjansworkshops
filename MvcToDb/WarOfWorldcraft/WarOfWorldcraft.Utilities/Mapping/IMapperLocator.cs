using Utilities.Mapping;

namespace WarOfWorldcraft.Utilities.Mapping
{
    public interface IMapperLocator
    {
        IMapper<From, To> GetMapperFor<From, To>();
    }
}