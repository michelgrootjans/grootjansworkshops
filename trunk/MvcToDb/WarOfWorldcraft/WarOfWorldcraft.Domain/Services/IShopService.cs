using System.Collections.Generic;
using System.Linq;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Repository;
using WarOfWorldcraft.Utilities.Extensions;

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
        private readonly IRepository repository;
        private readonly IInternalPlayerService playerService;

        public ShopService(IRepository repository, IInternalPlayerService playerService)
        {
            this.repository = repository;
            this.playerService = playerService;
        }

        public IEnumerable<ViewItemInfoDto> GetShopContents()
        {
            var items = repository.CreateQuery("from Item as item where item.Owner is null").List<Item>();
            return Map.These(items).ToAListOf<ViewItemInfoDto>();
        }

        public IEnumerable<ViewItemInfoDto> GetPlayerInventory()
        {
            var player = playerService.GetCurrentPlayer();
            return Map.These(player.Inventory).ToAListOf<ViewItemInfoDto>();
        }

        public string Buy(string itemId)
        {
            var player = playerService.GetCurrentPlayer();
            var item = repository.Load<Item>(itemId.ToLong());

            player.Buy(item);

            return string.Format("Thank you for buying the {0}", item.Name);
        }
    }
}