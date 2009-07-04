using System.Collections.Generic;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IMonsterGenerator
    {
        void GenerateMonsters();
    }

    internal class MonsterGenerator : IMonsterGenerator
    {
        private readonly IRepository repository;
        private readonly IRandomizer randomizer;
        private readonly IMonsterStatsGenerator statsGenerator;
        private readonly IInternalPlayerService playerService;
        private readonly IList<string> names;

        public MonsterGenerator(IRepository repository, IRandomizer randomizer, IMonsterStatsGenerator statsGenerator, IInternalPlayerService playerService)
        {
            this.repository = repository;
            this.randomizer = randomizer;
            this.statsGenerator = statsGenerator;
            this.playerService = playerService;
            names = InitializeNames();
        }

        public void GenerateMonsters()
        {
            var player = playerService.GetCurrentPlayer();
            var monsters = GenerateMonstersAroundLevel(player.Level);
            foreach (var monster in monsters)
                repository.Save(monster);
        }

        private IEnumerable<Monster> GenerateMonstersAroundLevel(int level)
        {
            for (var i = 0; i < 5; i++)
            {
                var name = PickName();
                var monster = new Monster(name);
                monster.Level = randomizer.GetNumberBetween(level - 3, level + 3).Minimum(1);
                statsGenerator.GenerateStatsFor(monster);

                yield return monster;
            }
        }

        private string PickName()
        {
            var index = randomizer.GetNumberBetween(0, names.Count - 1);
            return names[index];
        }

        private IList<string> InitializeNames()
        {
            var list = new List<string>();

            list.Add("Chicken");
            list.Add("Rabbit");
            list.Add("Cow");
            list.Add("Deer");
            list.Add("Defias Bandit");
            list.Add("Forest Spider");
            list.Add("Forlorn Spirit");
            list.Add("Grey Forest Wolf");
            list.Add("Muddy Murlock");
            list.Add("Spectral Apparition");
            list.Add("Giant Tarantula");
            list.Add("Young Forest Bear");
            list.Add("Blazing Elemental");
            list.Add("Dark Iron Taskmaster");
            list.Add("Harris Pilton");
            list.Add("Ganny Dladines");
            list.Add("Faulty War Golem");
            list.Add("Lava Crab");
            list.Add("Molten Destroyer");
            list.Add("Twilight Emissary");
            list.Add("Bloodtalon Tailasher");
            list.Add("Corrupted Mottled Boar");

            return list;
        }
    }
}