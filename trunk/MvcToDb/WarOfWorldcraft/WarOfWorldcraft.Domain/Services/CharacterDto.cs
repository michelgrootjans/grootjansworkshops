namespace WarOfWorldcraft.Domain.Services
{
    public class ViewCharacterInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string StatsMaxHitPoints { get; set; }
        public string Gold { get; set; }
    }

    public class ViewCharacterDto : ViewCharacterInfoDto
    {
        public string StatsHitPoints { get; set; }
        public string StatsAttack { get; set; }
        public string StatsDefence { get; set; }
    }

    public class CreateCharacterDto 
    {
        public string Name { get; set; }
    }
}