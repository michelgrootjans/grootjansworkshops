using System.Web.Mvc;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IHomeController
    {
        ActionResult Index();
    }

    [HandleError]
    public class HomeController : Controller, IHomeController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}