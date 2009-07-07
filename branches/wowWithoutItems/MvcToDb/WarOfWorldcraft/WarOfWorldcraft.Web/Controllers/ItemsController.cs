using System.Web.Mvc;
using MvcContrib;
using MvcContrib.Filters;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IItemsController
    {
        ActionResult Generate();
    }

    [Rescue("Error")]
    public class ItemsController : Controller, IItemsController
    {
        private readonly IItemGenerator itemGenerator;

        public ItemsController(IItemGenerator itemGenerator)
        {
            this.itemGenerator = itemGenerator;
        }

        public ActionResult Generate()
        {
            var notification = itemGenerator.GenerateItems();
            return this.RedirectToAction<ShopController>(c => c.Index(notification));
        }
    }
}