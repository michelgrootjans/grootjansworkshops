using System.Web.Mvc;
using MvcContrib;
using MvcContrib.Filters;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IBattleController
    {
        [AcceptVerbs(HttpVerbs.Get)]
        ActionResult Index();
        
        [AcceptVerbs(HttpVerbs.Get)]
        ActionResult Challenge(string id);

        [AcceptVerbs(HttpVerbs.Post)]
        ActionResult Attack(string monsterId);
    }

    [Rescue("Error")]
    public class BattleController : Controller, IBattleController
    {
        private readonly IBattleService batlleService;

        public BattleController(IBattleService batlleService)
        {
            this.batlleService = batlleService;
        }

        public ActionResult Index()
        {
            var enemies = batlleService.GetAllMonsters<ViewMonsterInfoDto>();
            return View(enemies);
        }

        public ActionResult Challenge(string id)
        {
            var challenge = batlleService.Challenge<ViewPlayerDto, ViewMonsterDto>(id);
            
            if(challenge.Monster.IsDead)
                return View("Win", challenge);
            if(challenge.Player.IsDead)
                return View("Dead", challenge);

            return View(challenge);
        }

        public ActionResult Attack(string monsterId)
        {
            batlleService.Attack(monsterId);
            return this.RedirectToAction(c => c.Challenge(monsterId));
        }
    }
}