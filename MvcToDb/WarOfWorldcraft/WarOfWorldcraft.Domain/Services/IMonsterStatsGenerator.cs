using WarOfWorldcraft.Domain.Entities;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IMonsterStatsGenerator : IStatsGenerator
    {
    }

    internal class MonsterStatsGenerator : IMonsterStatsGenerator
    {
        public void GenerateStatsFor(IStatsHolder statistics)
        {
            var level = statistics.Level;
            statistics.MaxHitPoints = Roll.SixSidedDice().Times(level);
            statistics.HitPoints = statistics.MaxHitPoints;
            statistics.Attack = Roll.SixSidedDice().Times(level);
            statistics.Defence = Roll.SixSidedDice().Times(level);
            statistics.Gold = Roll.TenSidedDice().Times(level);
        }
    }
}