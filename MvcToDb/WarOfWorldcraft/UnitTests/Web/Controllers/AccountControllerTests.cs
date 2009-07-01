using System;
using System;
using System.Web.Mvc;
using NUnit.Framework;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Controllers;
using UnitTests.TestUtilities.Extensions;
using Rhino.Mocks;

namespace UnitTests.Web.Controllers
{
    public abstract class AccountControllerTest 
        : ControllerSpecification<IAccountController>
    {
        protected IAuthenticationService authenticationService;
        protected IMembershipService membershipService;

        protected override void Arrange()
        {
            authenticationService = Dependency<IAuthenticationService>();
            membershipService = Dependency<IMembershipService>();
        }

        protected override IAccountController CreateSystemUnderTest()
        {
            return new AccountController(authenticationService, membershipService);
        }
    }

    public class when_AccountController_is_told_to_LogOn
        : AccountControllerTest
    {
        protected override Func<IAccountController, ActionResult> When()
        {
            return c => c.LogOn();
        }

        [Test]
        public void should_return_the_default_View()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }
    }

    public class when_AccountController_is_told_to_LogOn_with_username_and_password
    : AccountControllerTest
    {
        private string username = "test user";
        private string password = "password";

        protected override void Arrange()
        {
            base.Arrange();
            When(membershipService).IsToldTo(s => s.ValidateUser(username, password)).Return(true);
        }

        protected override Func<IAccountController, ActionResult> When()
        {
            return c => c.LogOn(username, password, false, null);
        }

        [Test]
        public void should_ask_the_membershipservice_for_validation()
        {
            membershipService.AssertWasCalled(s => s.ValidateUser(username, password));
        }

        [Test]
        public void should_tell_the_authenticationservice_to_sign_in()
        {
            authenticationService.AssertWasCalled((s => s.SignIn(username, false)));
        }
     
        [Test]
        public void should_redirect_to_return_url()
        {
            result.ShouldBeOfType<RedirectToRouteResult>()
                .ShouldRedirectToController("Home")
                .ShouldRedirectToAction("Index");
        }
    }

    public class when_AccountController_is_told_to_LogOn_with_return_url
    : AccountControllerTest
    {
        private string username = "test user";
        private string password = "password";
        private string returnUrl = "returnurl";

        protected override void Arrange()
        {
            base.Arrange();
            When(membershipService).IsToldTo(s => s.ValidateUser(username, password)).Return(true);
        }

        protected override Func<IAccountController, ActionResult> When()
        {
            return c => c.LogOn(username, password, false, returnUrl);
        }

        [Test]
        public void should_ask_the_membershipservice_for_validation()
        {
            membershipService.AssertWasCalled(s => s.ValidateUser(username, password));
        }

        [Test]
        public void should_tell_the_authenticationservice_to_sign_in()
        {
            authenticationService.AssertWasCalled((s => s.SignIn(username, false)));
        }
     
        [Test]
        public void should_redirect_to_return_url()
        {
            result.ShouldBeOfType<RedirectResult>()
                .Url.ShouldBeEqualTo(returnUrl);
        }
    }

    public class when_AccountController_is_told_to_LogOn_UNSUCCESFULLY_with_username_and_password_succesfully
        : AccountControllerTest
    {
        private string username = "test user";
        private string password = "password";

        protected override Func<IAccountController, ActionResult> When()
        {
            return c => c.LogOn(username, password, true, null);
        }

        [Test]
        public void should_ask_the_membershipservice_for_validation()
        {
            membershipService.AssertWasCalled(s => s.ValidateUser(username, password));
        }

        [Test]
        public void should_tell_the_authenticationservice_to_sign_in()
        {
            authenticationService.AssertWasNotCalled((s => s.SignIn(Arg<string>.Is.Anything, Arg<bool>.Is.Anything)));
        }

        [Test]
        public void should_set_the_remember_me_viewdata()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewData["rememberMe"].ShouldBeOfType<bool>().ShouldBeTrue();
        }

        [Test]
        public void should_show_logon()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }

        [Test]
        public void should_add_an_error_message()
        {
            sut.ShouldBeOfType<AccountController>()
                .ModelState["_FORM"].Errors[0].ErrorMessage.ShouldBeEqualTo("De gebruikersnaam/paswoord combinatie is niet gekend.");
        }
    }

    public class when_AccountController_is_told_to_LogOff : AccountControllerTest
    {
        protected override Func<IAccountController, ActionResult> When()
        {
            return c => c.LogOff();
        }

        [Test]
        public void should_tell_the_authentication_service_to_sign_out()
        {
            authenticationService.AssertWasCalled(s => s.SignOut());
        }

        [Test]
        public void should_redirect_to_home_index()
        {
            result.ShouldBeOfType<RedirectToRouteResult>()
                .ShouldRedirectToController("Home")
                .ShouldRedirectToAction("Index");
        }
    }

}