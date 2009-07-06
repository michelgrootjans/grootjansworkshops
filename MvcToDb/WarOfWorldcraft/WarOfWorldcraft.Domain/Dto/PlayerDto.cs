using System.Collections.Generic;

namespace WarOfWorldcraft.Domain.Dto
{
    public class ViewAllPlayersDto
    {
        public IEnumerable<ViewPlayerInfoDto> LivingPlayers { get; set; }
        public IEnumerable<ViewPlayerInfoDto> DeadPlayers { get; set; }

        public ViewAllPlayersDto()
        {
            LivingPlayers = new List<ViewPlayerInfoDto>();
            DeadPlayers = new List<ViewPlayerInfoDto>();
        }
    }

    public class ViewPlayerInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string MaxHitPoints { get; set; }
        public string Gold { get; set; }
        public string Level { get; set; }
    }

    public class ViewPlayerDto : ViewPlayerInfoDto
    {
        public string HitPoints { get; set; }
        public string Attack { get; set; }
        public string Defence { get; set; }
        public bool IsDead { get; set; }
        public string PercentHitPoints { get; set; }
    }

    public class NullPlayerDto : ViewPlayerDto
    {
    }

    public class CreatePlayerDto
    {
        public string Name { get; set; }
    }
}