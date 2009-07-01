namespace WarOfWorldcraft.Domain.Services
{
    public class ViewChallengeDto
    {
        public ViewChallengeDto()
        {
            Player = new ViewPlayerDto();
            Monster = new ViewMonsterDto();
        }

        public ViewPlayerDto Player { get; set; }
        public ViewMonsterDto Monster { get; set; }
    }
}