using System.Web.Mvc;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Helpers;

namespace WarOfWorldcraft.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var players = playerService.GetAllCharacters();
            return View(players);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(string id)
        {
            var player = playerService.GetPlayer(id);
            return View(player);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult New()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(CreatePlayerDto player)
        {
            var id = playerService.CreateCharacter(player);
            return RedirectToAction("Detail", id.ToIdRoute());
        }
    }
}