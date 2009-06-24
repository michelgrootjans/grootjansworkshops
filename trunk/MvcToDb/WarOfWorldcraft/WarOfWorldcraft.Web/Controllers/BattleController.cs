using System.Web.Mvc;
using MvcContrib;
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
            var enemies = batlleService.GetAllMonsters();
            return View(enemies);
        }

        public ActionResult Challenge(string id)
        {
            var challenge = batlleService.Challenge(id);
            
            if(challenge.Monster.IsDead)
                return View("Win", challenge);

            return View(challenge);
        }

        public ActionResult Attack(string monsterId)
        {
            batlleService.Attack(monsterId);
            return this.RedirectToAction(c => c.Challenge(monsterId));
        }
    }
}