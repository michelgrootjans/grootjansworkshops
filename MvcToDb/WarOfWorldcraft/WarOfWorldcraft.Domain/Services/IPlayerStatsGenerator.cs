using WarOfWorldcraft.Domain.Entities;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IPlayerStatsGenerator : IStatsGenerator
    {
    }

    internal class PlayerStatsGenerator : IPlayerStatsGenerator
    {
        public void GenerateStatsFor(IStatsHolder statistics)
        {
            statistics.MaxHitPoints = 10 + Roll.SixSidedDice().Twice();
            statistics.HitPoints = statistics.MaxHitPoints;
            statistics.Attack = 10 + Roll.SixSidedDice().Once();
            statistics.Defence = 6 + Roll.SixSidedDice().Once();
        }
    }
}