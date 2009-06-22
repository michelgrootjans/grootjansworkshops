using System;
using WarOfWorldcraft.Domain.Entities;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IStatsGenerator
    {
        void GenerateStatsFor(Statistics statistics);
    }

    internal class PlayerStatsGenerator : IStatsGenerator
    {
        public void GenerateStatsFor(Statistics statistics)
        {
            statistics.MaxHitPoints = 10 + Roll.SixSidedDice().Twice();
            statistics.HitPoints = statistics.MaxHitPoints;
            statistics.Attack = Roll.SixSidedDice().Twice();
            statistics.Defence = Roll.SixSidedDice().Twice();
        }
    }
}