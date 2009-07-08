using WarOfWorldcraft.Domain.Entities;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IStatsGenerator
    {
        void GenerateStatsFor(IStatsHolder statistics);
    }
}