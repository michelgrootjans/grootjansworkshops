using System.Collections.Generic;
using System.Linq;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Mapping;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IShopService
    {
        IEnumerable<ViewItemInfoDto> GetShopContents();
        IEnumerable<ViewItemInfoDto> GetPlayerInventory();
        string Buy(string itemName);
    }

    internal class ShopService : IShopService
    {
        private readonly IInternalPlayerService playerService;

        public ShopService(IInternalPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public IEnumerable<ViewItemInfoDto> GetShopContents()
        {
            var items = new Shop().Catalog;
            return Map.These(items).ToAListOf<ViewItemInfoDto>();
        }

        public IEnumerable<ViewItemInfoDto> GetPlayerInventory()
        {
            yield return Map.This(new Item("A strange looking potion", 1)).ToA<ViewItemInfoDto>();
        }

        public string Buy(string itemName)
        {
            var player = playerService.GetCurrentPlayer();
            var item = (from i in new Shop().Catalog
                        where i.Name.Equals(itemName)
                        select i).FirstOrDefault();

            player.Buy(item);

            return string.Format("Thank you for buying the {0}", item.Name);
        }
    }
}