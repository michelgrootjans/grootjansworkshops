using System.Web.Mvc;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.IoC;

namespace WarOfWorldcraft.Web.Filters
{
    public class ShowPlayerDetailsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult.IsNull()) return;

            var playerService = Container.GetImplementationOf<IPlayerService>();
            try
            {
                viewResult.ViewData["currentPlayer"] = playerService.GetCurrentPlayer();
            }
            catch
            {
                viewResult.ViewData["currentPlayer"] = new NullPlayerDto();
            }
        }
    }
}