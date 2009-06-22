using System.Collections.Generic;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IBattleService
    {
        IEnumerable<ViewEnemyInfoDto> GetAllEnemies();
    }

    internal class BattleService : IBattleService
    {
        public IEnumerable<ViewEnemyInfoDto> GetAllEnemies()
        {
            yield return new ViewEnemyInfoDto{Id="1", Name = "Horrible troll", StatsMaxHitPoints = "10"};
            yield return new ViewEnemyInfoDto{Id="2", Name = "Bah", StatsMaxHitPoints = "12"};
        }
    }
}