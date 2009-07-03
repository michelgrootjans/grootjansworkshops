using System.Collections.Generic;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IBattleService
    {
        IEnumerable<MonsterDto> GetAllMonsters<MonsterDto>();
        ViewChallengeDto<PlayerDto, MonsterDto> Challenge<PlayerDto, MonsterDto>(string monsterId) 
            where PlayerDto : new()
            where MonsterDto : new();
        void Attack(string monsterId);
    }

    internal class BattleService : IBattleService
    {
        private readonly IRepository repository;
        private readonly IInternalPlayerService playerService;
        private readonly IMonsterGenerator monsterGenerator;

        public BattleService(IRepository repository, IInternalPlayerService playerService, IMonsterGenerator monsterGenerator)
        {
            this.repository = repository;
            this.playerService = playerService;
            this.monsterGenerator = monsterGenerator;
        }

        public IEnumerable<MonsterDto> GetAllMonsters<MonsterDto>()
        {
            var monsters = repository.CreateCriteria<Monster>().Add(Restrictions.Gt("HitPoints", 0)).List<Monster>();
            if (monsters.Count < 5)
            {
                var newmonsters = GenerateMonsters();
                foreach (var monster in newmonsters)
                {
                    repository.Save(monster);
                    monsters.Add(monster);
                }
            }
            return Map.These(monsters).ToAListOf<MonsterDto>();
        }

        public ViewChallengeDto<PlayerDto, MonsterDto> Challenge<PlayerDto, MonsterDto>(string monsterId) 
            where PlayerDto : new() 
            where MonsterDto : new()
        {
            var player = playerService.GetCurrentPlayer();
            var monster = repository.Load<Monster>(monsterId.ToLong());

            var challenge = new ViewChallengeDto<PlayerDto, MonsterDto>();
            challenge.Player = Map.This(player).ToA<PlayerDto>();
            challenge.Monster = Map.This(monster).ToA<MonsterDto>();

            return challenge;
        }


        public void Attack(string monsterId)
        {
            var player = playerService.GetCurrentPlayer();
            var monster = repository.Load<Monster>(monsterId.ToLong());
            player.Fight(monster);
        }

        private IEnumerable<Monster> GenerateMonsters()
        {
            var player = playerService.GetCurrentPlayer();
            return monsterGenerator.GenerateMonstersAroundLevel(player.Level);
        }
    }
}