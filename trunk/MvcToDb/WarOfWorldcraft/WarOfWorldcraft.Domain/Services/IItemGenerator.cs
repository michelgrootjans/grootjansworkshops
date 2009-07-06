using System;
using System.Collections.Generic;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IItemGenerator
    {
        string GenerateItems();
    }

    class ItemGenerator : IItemGenerator
    {
        private readonly IRepository repository;
        private readonly IRandomizer randomizer;
        private static IList<string> names;

        public ItemGenerator(IRepository repository, IRandomizer randomizer)
        {
            this.repository = repository;
            this.randomizer = randomizer;
            names = InitializeNames();
        }

        public string GenerateItems()
        {
            var items = GenerateItemsRandomly();
            foreach (var item in items)
                repository.Save(item);
            return "Ooh... I found a few items here...";
        }

        private IEnumerable<Item> GenerateItemsRandomly()
        {
            for (var i = 0; i < 20; i++)
            {
                var name = PickName();
                var item = new Item(name, randomizer.GetNumberBetween(1, 50));
                yield return item;
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

            list.Add("Piece of stale bread");
            list.Add("Rusty knife");
            list.Add("Shiny fake ring");
            list.Add("Flux capacitor");
            list.Add("Usemess piece of crap");

            return list;
        }

    }
}