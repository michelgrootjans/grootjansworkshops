using System.Web.Mvc;
using MvcContrib;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IPlayerController
    {
        ActionResult Index();
    }

    public class PlayerController : Controller, IPlayerController
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var players = playerService.GetAllPlayers();
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
            var id = playerService.CreatePlayer(player);
            return this.RedirectToAction(c => c.Detail(id));
        }
    }
}