using System.Web.Mvc;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Helpers;

namespace WarOfWorldcraft.Web.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var characters = characterService.GetAllCharacters();
            return View(characters);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(string id)
        {
            var character = characterService.GetCharacter(id);
            return View(character);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult New()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(CreateCharacterDto character)
        {
            var id = characterService.CreateCharacter(character);
            return RedirectToAction("Detail", id.ToIdRoute());
        }
    }
}