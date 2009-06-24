namespace WarOfWorldcraft.Domain.Services
{
    public class ViewPlayerInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string MaxHitPoints { get; set; }
        public string Gold { get; set; }
    }

    public class ViewPlayerDto : ViewPlayerInfoDto
    {
        public string HitPoints { get; set; }
        public string Attack { get; set; }
        public string Defence { get; set; }
    }

    public class CreatePlayerDto 
    {
        public string Name { get; set; }
    }
}