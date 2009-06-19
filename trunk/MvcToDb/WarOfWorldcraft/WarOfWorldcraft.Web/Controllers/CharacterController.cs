using System.Web.Mvc;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        public ActionResult Index()
        {
            var characters = characterService.GetAllCharacters();
            return View(characters);
        }

        public ActionResult Detail(string id)
        {
            var character = characterService.GetCharacter(id);
            return View(character);
        }
    }
}