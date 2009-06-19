using System.Web.Mvc;

namespace WarOfWorldcraft.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}