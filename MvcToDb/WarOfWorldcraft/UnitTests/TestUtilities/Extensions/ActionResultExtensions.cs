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

        public static RedirectToRouteResult ShouldRedirectToAction(this RedirectToRouteResult actionResult, string action)
        {
            actionResult.RouteValues["action"].ShouldBeEqualTo(action);
            return actionResult;
        }

        public static RedirectToRouteResult ShouldRedirectToId(this RedirectToRouteResult actionResult, string id)
        {
            actionResult.RouteValues["id"].ShouldBeEqualTo(id);
            return actionResult;
        }

        public static RedirectToRouteResult ShouldRedirectWithRouteValue(this RedirectToRouteResult actionResult, string key, string value)
        {
            actionResult.RouteValues[key].ShouldBeEqualTo(value);
            return actionResult;
        }
    }
}