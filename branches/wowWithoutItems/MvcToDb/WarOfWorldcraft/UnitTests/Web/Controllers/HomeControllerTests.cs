using System;
using System.Web.Mvc;
using NUnit.Framework;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Web.Controllers;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Web.Controllers
{
    public class when_HomeController_is_told_to_show_its_Index : ControllerSpecification<IHomeController>
    {
        protected override IHomeController CreateSystemUnderTest()
        {
            return new HomeController();
        }

        protected override Func<IHomeController, ActionResult> When()
        {
            return c => c.Index();
        }

        [Test]
        public void should_return_the_default_View()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }

    }
}