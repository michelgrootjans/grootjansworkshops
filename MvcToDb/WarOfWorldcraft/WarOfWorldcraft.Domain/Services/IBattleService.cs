using System.Collections.Generic;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IBattleService
    {
        IEnumerable<ViewMonsterInfoDto> GetAllMonsters();
        ViewChallengeDto Challenge(string monsterId);
        void Attack(string monsterId);
    }

    internal class BattleService : ServiceBase, IBattleService
    {
        private readonly IInternalPlayerService playerService;
        private readonly IMonsterGenerator monsterGenerator;

        public BattleService(IInternalPlayerService playerService, IMonsterGenerator monsterGenerator)
        {
            this.playerService = playerService;
            this.monsterGenerator = monsterGenerator;
        }

        public IEnumerable<ViewMonsterInfoDto> GetAllMonsters()
        {
            var monsters = session.CreateCriteria<Monster>().Add(Restrictions.Gt("HitPoints", 0)).List<Monster>();
            if (monsters.Count < 10)
            {
                var newmonsters = GenerateMonsters(monsters);
                foreach (var monster in newmonsters)
                {
                    session.Save(monster);
                    monsters.Add(monster);
                }
            }            
            return Map.These(monsters).ToAListOf<ViewMonsterInfoDto>();
        }

        public ViewChallengeDto Challenge(string monsterId)
        {
            var player = playerService.GetCurrentPlayer();
            var monster = session.Load<Monster>(monsterId.ToLong());

            var challenge = new ViewChallengeDto();
            challenge.Player = Map.This(player).ToA<ViewPlayerDto>();
            challenge.Monster = Map.This(monster).ToA<ViewMonsterDto>();

            return challenge;
        }


        public void Attack(string monsterId)
        {
            var player = playerService.GetCurrentPlayer();
            var monster = session.Load<Monster>(monsterId.ToLong());
            player.Fight(monster);
        }

        private IEnumerable<Monster> GenerateMonsters(IList<Monster> monsters)
        {
            var player = playerService.GetCurrentPlayer();
            return monsterGenerator.GenerateMonstersAroundLevel(player.Level);
        }
    }
}