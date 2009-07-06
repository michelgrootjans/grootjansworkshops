namespace WarOfWorldcraft.Domain.Dto
{
    public class ViewChallengeDto<PlayerDto, MonsterDto>
        where PlayerDto : new() 
        where MonsterDto : new()
    {
        public ViewChallengeDto()
        {
            Player = new PlayerDto();
            Monster = new MonsterDto();
        }

        public PlayerDto Player { get; set; }
        public MonsterDto Monster { get; set; }
    }
}