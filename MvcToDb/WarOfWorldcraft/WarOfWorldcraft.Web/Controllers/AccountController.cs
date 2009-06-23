using System;
using System.Web.Mvc;
using System.Web.Security;
using MvcContrib;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Controllers
{
    [HandleError]
    public class AccountController : Controller
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
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return this.RedirectToAction<HomeController>(c => c.Index());
        }

        public ActionResult LogOff()
        {
            authenticationService.SignOut();

            return RedirectToAction("Index", "Home");
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

    public class FormsAuthenticationService : IAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }


    public class HardcodedMembershipService : IMembershipService
    {
        public bool ValidateUser(string userName, string password)
        {
            return true;
        }
    }
}