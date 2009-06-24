using System.Web.Mvc;

namespace UnitTests.TestUtilities.Extensions
{
    public static class ActionResultExtensions
    {
        public static RedirectToRouteResult ShouldRedirectToController(this RedirectToRouteResult actionResult, string controller)
        {
            actionResult.RouteValues["controller"].ShouldBeEqualTo(controller);
            return actionResult;
        }

        public static RedirectToRouteResult ShouldRedirectToAction(this RedirectToRouteResult actionResult, string controller)
        {
            actionResult.RouteValues["action"].ShouldBeEqualTo(controller);
            return actionResult;
        }

        public static RedirectToRouteResult ShouldRedirectToId(this RedirectToRouteResult actionResult, string controller)
        {
            actionResult.RouteValues["id"].ShouldBeEqualTo(controller);
            return actionResult;
        }
    }
}