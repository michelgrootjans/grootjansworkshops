using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Domain.Dto;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Controllers;
using Rhino.Mocks;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Web.Controllers
{
    public abstract class ShopControllerTest : ControllerSpecification<IShopController>
    {
        protected IShopService shopService;

        protected override void Arrange()
        {
            shopService = Dependency<IShopService>();
        }
        protected override IShopController CreateSystemUnderTest()
        {
            return new ShopController(shopService);
        }
    }

    public class when_ShopController_is_told_to_show_its_Index : ShopControllerTest
    {
        private IList<ViewItemInfoDto> shopCatalog;
        private IList<ViewItemInfoDto> playerInventory;

        protected override void Arrange()
        {
            base.Arrange();
            shopCatalog = new List<ViewItemInfoDto>();
            playerInventory = new List<ViewItemInfoDto>();
            When(shopService).IsToldTo(s => s.GetShopContents()).Return(shopCatalog);
            When(shopService).IsToldTo(s => s.GetPlayerInventory()).Return(playerInventory);
        }


        protected override Func<IShopController, ActionResult> When()
        {
            return c => c.Index(null);
        }

        [Test]
        public void should_tell_the_service_to_get_the_shop_contents()
        {
            shopService.AssertWasCalled(s => s.GetShopContents());
        }

        [Test]
        public void should_tell_the_service_to_get_the_players_inventory()
        {
            shopService.AssertWasCalled(s => s.GetPlayerInventory());
        }

        [Test]
        public void should_show_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }

        [Test]
        public void should_put_the_result_in_the_view()
        {
            var shop = result.ShouldBeOfType<ViewResult>()
                .ViewData.Model.ShouldBeOfType<ViewShopDto>();
            shop.Catalog.ShouldBeEqualTo(shopCatalog);
            shop.PlayerInventory.ShouldBeEqualTo(playerInventory);
        }

        [Test]
        public void should_not_have_a_notification()
        {
            result.ShouldBeOfType<ViewResult>().ViewData["notification"].ShouldBeNull();
        }
    }

    public class when_ShopController_is_told_to_buy_an_Item : ShopControllerTest
    {
        private string itemId = "654";
        private string notification;

        protected override void Arrange()
        {
            base.Arrange();
            itemId = "554456";
            notification = "whatever";

            When(shopService).IsToldTo(s => s.Buy(itemId)).Return(notification);
        }

        protected override Func<IShopController, ActionResult> When()
        {
            return c => c.Buy(itemId);
        }

        [Test]
        public void should_tell_the_service_to_buy_the_item()
        {
            shopService.AssertWasCalled(s => s.Buy(itemId));
        }

        [Test]
        public void should_return_the_index()
        {
            result.ShouldBeOfType<RedirectToRouteResult>()
                .ShouldRedirectToController("Shop")
                .ShouldRedirectToAction("Index")
                .ShouldRedirectWithRouteValue("notification", notification);
        }
    }
}