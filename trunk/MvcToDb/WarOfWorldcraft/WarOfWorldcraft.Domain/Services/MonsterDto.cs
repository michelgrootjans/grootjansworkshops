namespace WarOfWorldcraft.Domain.Services
{
    public class ViewMonsterInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MaxHitPoints { get; set; }
    }

    public class ViewMonsterDto : ViewMonsterInfoDto
    {
        public string HitPoints { get; set; }
        public bool IsDead { get; set; }
    }
}