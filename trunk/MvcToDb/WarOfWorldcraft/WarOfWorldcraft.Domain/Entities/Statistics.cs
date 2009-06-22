using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Domain.Entities
{
    public class Statistics
    {
        public int HitPoints { get; protected internal set; }
        public int MaxHitPoints { get; protected internal set; }
        public int Attack { get; protected internal set; }
        public int Defence { get; protected internal set; }

        public void Randomize(IStatsGenerator generator)
        {
            generator.GenerateStatsFor(this);
        }
    }

}