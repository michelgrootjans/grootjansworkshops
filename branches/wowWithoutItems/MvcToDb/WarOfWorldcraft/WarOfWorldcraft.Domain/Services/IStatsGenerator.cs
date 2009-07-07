using WarOfWorldcraft.Domain.Entities;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IStatsGenerator
    {
        void GenerateStatsFor(IStatsHolder statistics);
    }

    public interface IPlayerStatsGenerator : IStatsGenerator
    {
    }

    public interface IMonsterStatsGenerator : IStatsGenerator
    {
    }

    internal class PlayerStatsGenerator : IPlayerStatsGenerator
    {
        public void GenerateStatsFor(IStatsHolder statistics)
        {
            statistics.MaxHitPoints = 10 + Roll.SixSidedDice().Twice();
            statistics.HitPoints = statistics.MaxHitPoints;
            statistics.Attack = Roll.SixSidedDice().Twice();
            statistics.Defence = Roll.SixSidedDice().Twice();
        }
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