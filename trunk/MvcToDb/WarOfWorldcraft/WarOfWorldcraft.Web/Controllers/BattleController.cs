using System.Web.Mvc;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Controllers
{
    public class BattleController : Controller
    {
        private readonly IBattleService batlleService;

        public BattleController(IBattleService batlleService)
        {
            this.batlleService = batlleService;
        }

        public ActionResult Index()
        {
            var ennemies = batlleService.GetAllEnemies();
            return View(ennemies);
        }
    }
}