namespace WarOfWorldcraft.Domain.Services
{
    public class ViewMonsterInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StatsMaxHitPoints { get; set; }
    }

    public class ViewMonsterDto : ViewMonsterInfoDto
    {
        public string StatsHitPoints { get; set; }
    }

}