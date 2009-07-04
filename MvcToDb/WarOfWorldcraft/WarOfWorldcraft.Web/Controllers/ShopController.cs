using System.Web.Mvc;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Helpers;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IShopController
    {
        [AcceptVerbs(HttpVerbs.Get)]
        ActionResult Index(string notification);

        [AcceptVerbs(HttpVerbs.Post)]
        ActionResult Buy(string itemId);
    }

    public class ShopController : Controller, IShopController
    {
        private readonly IShopService shopService;

        public ShopController(IShopService shopService)
        {
            this.shopService = shopService;
        }

        public ActionResult Index(string notification)
        {
            var shop = new ViewShopDto();
            shop.Catalog = shopService.GetShopContents();
            shop.PlayerInventory = shopService.GetPlayerInventory();

            var result = View(shop);
            result.ViewData["notification"] = notification;
            return result;
        }

        public ActionResult Buy(string itemName)
        {
            var notification = shopService.Buy(itemName);
            return RedirectToAction("Index", "Shop", notification.ToNotificationRoute());
        }
    }
}