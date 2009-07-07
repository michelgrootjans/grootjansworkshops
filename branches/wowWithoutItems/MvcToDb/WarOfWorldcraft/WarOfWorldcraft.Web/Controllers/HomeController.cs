using System.Web.Mvc;
using MvcContrib.Filters;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IHomeController
    {
        ActionResult Index();
    }

    [Rescue("Error")]
    public class HomeController : Controller, IHomeController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}