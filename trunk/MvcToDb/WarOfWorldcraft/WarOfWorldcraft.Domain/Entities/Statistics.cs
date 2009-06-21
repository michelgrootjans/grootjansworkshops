namespace WarOfWorldcraft.Domain.Entities
{
    public class Statistics
    {
        public int HitPoints { get; protected set; }
        public int MaxHitPoints { get; protected set; }
        public int Attack { get; protected set; }
        public int Defence { get; protected set; }
    }
}