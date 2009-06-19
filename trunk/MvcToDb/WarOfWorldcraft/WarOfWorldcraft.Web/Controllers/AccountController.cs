using System;
using System.Web.Mvc;
using System.Web.Security;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Helpers;

namespace WarOfWorldcraft.Web.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        private readonly ICharacterService characterService;

        public AccountController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Authenticate(string userName, string password, bool rememberMe, string returnUrl)
        {
            var characterId = characterService.CreateOrFind(userName, password);
            FormsAuthentication.SetAuthCookie(userName, rememberMe);

            if (!String.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            
            return RedirectToAction("Character", "Detail", characterId.ToIdRoute());
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}