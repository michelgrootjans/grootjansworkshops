using WarOfWorldcraft.Domain.Entities;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IStatsGenerator
    {
        void GenerateStatsFor(IStatsHolder statistics);
    }

    internal class PlayerStatsGenerator : IStatsGenerator
    {
        public void GenerateStatsFor(IStatsHolder statistics)
        {
            statistics.MaxHitPoints = 10 + Roll.SixSidedDice().Twice();
            statistics.HitPoints = statistics.MaxHitPoints;
            statistics.Attack = Roll.SixSidedDice().Twice();
            statistics.Defence = Roll.SixSidedDice().Twice();
        }
    }

    internal class MonsterStatsGenerator : IStatsGenerator
    {
        private readonly int level;

        public MonsterStatsGenerator(int level)
        {
            this.level = level;
        }

        public void GenerateStatsFor(IStatsHolder statistics)
        {
            statistics.Level = level;
            statistics.MaxHitPoints = Roll.SixSidedDice().Times(level);
            statistics.HitPoints = statistics.MaxHitPoints;
            statistics.Attack = Roll.SixSidedDice().Times(level);
            statistics.Defence = Roll.SixSidedDice().Times(level);
            statistics.Gold = Roll.TenSidedDice().Times(level);
        }
    }
}