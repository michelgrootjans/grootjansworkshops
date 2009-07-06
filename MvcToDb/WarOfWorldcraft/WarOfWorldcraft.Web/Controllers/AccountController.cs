using System.Web.Mvc;
using MvcContrib;
using MvcContrib.Filters;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Extensions;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IAccountController
    {
        [AcceptVerbs(HttpVerbs.Get)]
        ActionResult LogOn();

        [AcceptVerbs(HttpVerbs.Post)]
        ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl);

        [AcceptVerbs(HttpVerbs.Post)]
        ActionResult LogOff();
    }

    [Rescue("Error")]
    public class AccountController : Controller, IAccountController
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IMembershipService membershipService;

        public AccountController(IAuthenticationService authenticationService, IMembershipService membershipService)
        {
            this.authenticationService = authenticationService ;
            this.membershipService = membershipService;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl)
        {
            if (!ValidateLogOn(userName, password))
            {
                ViewData["rememberMe"] = rememberMe;
                return View();
            }

            authenticationService.SignIn(userName, rememberMe);
            if (returnUrl.IsNotNullOrEmpty())
            {
                return Redirect(returnUrl);
            }
            return this.RedirectToAction<HomeController>(c => c.Index());
        }

        public ActionResult LogOff()
        {
            authenticationService.SignOut();

            return this.RedirectToAction<HomeController>(c => c.Index());
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (!membershipService.ValidateUser(userName, password))
            {
                ModelState.AddModelError("_FORM", "De gebruikersnaam/paswoord combinatie is niet gekend.");
            }

            return ModelState.IsValid;
        }
    }
}