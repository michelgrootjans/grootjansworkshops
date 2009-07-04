using System.Collections.Generic;

namespace WarOfWorldcraft.Domain.Entities
{
    public class Shop
    {
        private static readonly IEnumerable<Item> catalog;

        static Shop()
        {
            catalog = new List<Item>
                          {
                              new Item("Piece of stale bread", 2),
                              new Item("A strange looking drink", 1)
                          };
        }

        public IEnumerable<Item> Catalog
        {
            get
            {
                foreach (var item in catalog)
                    yield return item;
            }
        }
    }
}