using System;
using System.Web.Mvc;
using System.Web.Security;

namespace WarOfWorldcraft.Web.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        public AccountController(IFormsAuthentication formsAuth, IMembershipService service)
        {
            FormsAuth = formsAuth ?? new FormsAuthenticationService();
            MembershipService = service ?? new HardcodedMembershipService();
        }

        public IFormsAuthentication FormsAuth { get; private set; }
        public IMembershipService MembershipService { get; private set; }

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

            FormsAuth.SignIn(userName, rememberMe);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuth.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (!MembershipService.ValidateUser(userName, password))
            {
                ModelState.AddModelError("_FORM", "De gebruikersnaam/paswoord combinatie is niet gekend.");
            }

            return ModelState.IsValid;
        }
    }

    public interface IMembershipService
    {
        bool ValidateUser(string userName, string password);
    }

    public class HardcodedMembershipService : IMembershipService
    {
        public bool ValidateUser(string userName, string password)
        {
            return true;
        }
    }

    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthentication
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
}