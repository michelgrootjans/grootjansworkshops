using System;

namespace WarOfWorldcraft.Domain.Entities
{
    public class Statistics
    {
        public int HitPoints { get; protected set; }
        public int MaxHitPoints { get; protected set; }
        public int Attack { get; protected set; }
        public int Defence { get; protected set; }

        public void Randomize()
        {
            MaxHitPoints = 10 + Roll.SixSidedDice().Twice();
            HitPoints = MaxHitPoints;
            Attack = Roll.SixSidedDice().Twice();
            Defence = Roll.SixSidedDice().Twice();
        }
    }

}