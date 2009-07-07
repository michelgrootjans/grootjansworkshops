namespace WarOfWorldcraft.Domain.Entities
{
    public interface IStatsHolder
    {
        int Level { get; }
        int MaxHitPoints { set; get; }
        int HitPoints { set; }
        int Attack { set; }
        int Defence { set; }
        int Gold { set; }
    }
}