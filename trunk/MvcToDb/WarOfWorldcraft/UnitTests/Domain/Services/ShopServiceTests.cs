using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using UnitTests.TestUtilities;
using UnitTests.TestUtilities.Extensions;
using Utilities.Mapping;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;

namespace UnitTests.Domain.Services
{
    public class ShopServiceTest : InstanceContextSpecification<IShopService>
    {
        protected IInternalPlayerService playerService;

        protected override void Arrange()
        {
            playerService = Dependency<IInternalPlayerService>();
        }

        protected override IShopService CreateSystemUnderTest()
        {
            return new ShopService(playerService);
        }
    }

    public class when_ShopService_is_told_to_get_the_shop_catalog : ShopServiceTest
    {
        private IEnumerable<ViewItemInfoDto> result;
        private IMapper<Item, ViewItemInfoDto> mapper;
        private IEnumerable<Item> itemsInShop;
        private ViewItemInfoDto dto;

        protected override void Arrange()
        {
            base.Arrange();
            itemsInShop = new Shop().Catalog;
            dto = new ViewItemInfoDto();
            mapper = RegisterMapper<Item, ViewItemInfoDto>();

            When(mapper).IsToldTo(m => m.Map(Arg<Item>.Is.Anything)).Return(dto);
        }

        protected override void Act()
        {
            result = sut.GetShopContents().ToList();
        }

        [Test]
        public void should_map_the_contents_of_the_shop()
        {
            foreach (var item in itemsInShop)
                mapper.AssertWasCalled(m => m.Map(item));
        }

        [Test]
        public void should_return_the_mapped_items()
        {
            result.Count().ShouldBeEqualTo(itemsInShop.Count());
            foreach (var itemInfoDto in result)
                itemInfoDto.ShouldBeSameAs(dto);
        }
    }

    public class when_ShoppingService_is_told_to_get_the_players_inventory : ShopServiceTest
    {
        private IEnumerable<ViewItemInfoDto> result;
        private IMapper<Item, ViewItemInfoDto> mapper;
        private Item item;
        private ViewItemInfoDto mappedItem;
        private Player player;

        protected override void Arrange()
        {
            base.Arrange();
            player = new Player("michel", "mgr");
            item = new Item("piece of bread", 0);
            player.Buy(item);
            mappedItem = new ViewItemInfoDto();

            mapper = RegisterMapper<Item, ViewItemInfoDto>();

            When(playerService).IsToldTo(s => s.GetCurrentPlayer()).Return(player);
            When(mapper).IsToldTo(m => m.Map(item)).Return(mappedItem);
        }


        protected override void Act()
        {
            result = sut.GetPlayerInventory().ToList();
        }

        [Test]
        public void should_get_the_player_from_the_playerservice()
        {
            playerService.AssertWasCalled(s => s.GetCurrentPlayer());
        }

        [Test]
        public void should_map_the_players_inventory()
        {
            mapper.AssertWasCalled(m  => m.Map(item));
        }

        [Test]
        public void should_return_the_mapped_items()
        {
            result.Count().ShouldBeEqualTo(1);
            result.ShouldContain(mappedItem);
        }
    }


    public class when_the_ShopService_is_told_to_buy_an_item : ShopServiceTest
    {
        private string itemName;
        private string result;
        private Player player;
        private Item orderedItem;
        private int playerGold;

        protected override void Arrange()
        {
            base.Arrange();
            player = new Player("Michel", "mgr");
            playerGold = 100;
            player.AddGold(playerGold);

            orderedItem = new Shop().Catalog.First();
            itemName = orderedItem.Name;

            When(playerService).IsToldTo(s => s.GetCurrentPlayer()).Return(player);
        }

        protected override void Act()
        {
            result = sut.Buy(itemName);
        }

        [Test]
        public void should_get_the_current_player()
        {
            playerService.AssertWasCalled(s => s.GetCurrentPlayer());
        }

        [Test]
        public void should_add_the_item_to_the_players_inventory()
        {
            player.Inventory.ShouldContain(orderedItem);
        }

        [Test]
        public void should_reduce_the_amount_of_gold_from_the_player()
        {
            player.Gold.ShouldBeEqualTo(playerGold - orderedItem.Price);
        }

        [Test]
        public void should_return_a_succesfull_message()
        {
            result.ShouldBeEqualTo(string.Format("Thank you for buying the {0}", itemName));
        }
    }
}