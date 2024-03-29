namespace WarOfWorldcraft.Domain.Dto
{
    public class ViewMonsterInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
    }

    public class ViewMonsterDto : ViewMonsterInfoDto
    {
        public string HitPoints { get; set; }
        public string MaxHitPoints { get; set; }
        public bool IsDead { get; set; }
    }
}