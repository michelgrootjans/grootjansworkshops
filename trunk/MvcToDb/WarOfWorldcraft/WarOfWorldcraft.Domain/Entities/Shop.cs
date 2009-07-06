using System.Collections.Generic;

namespace WarOfWorldcraft.Domain.Entities
{
    public class Shop : Character
    {
        public virtual IEnumerable<Item> Catalog
        {
            get
            {
                foreach (var item in inventory)
                    yield return item;
            }
        }

        public virtual void AddToCatalog(Item item)
        {
            inventory.Add(item);
        }
    }
}