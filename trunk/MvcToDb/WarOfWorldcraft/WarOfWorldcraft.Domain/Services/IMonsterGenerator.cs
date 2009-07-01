using System.Collections.Generic;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IMonsterGenerator
    {
        IEnumerable<Monster> GenerateMonstersAroundLevel(int level);
    }

    internal class MonsterGenerator : IMonsterGenerator
    {
        private readonly IRandomizer randomizer;
        private readonly IList<string> names;
        private readonly IMonsterStatsGenerator statsGenerator;

        public MonsterGenerator(IRandomizer randomizer, IMonsterStatsGenerator statsGenerator)
        {
            this.randomizer = randomizer;
            this.statsGenerator = statsGenerator;
            names = InitializeNames();
        }

        public IEnumerable<Monster> GenerateMonstersAroundLevel(int level)
        {
            for (var i = 0; i < 10; i++)
            {
                var name = PickName();
                var monster = new Monster(name);
                monster.Level = randomizer.GetNumberBetween(-3, 3).Minimum(1);
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