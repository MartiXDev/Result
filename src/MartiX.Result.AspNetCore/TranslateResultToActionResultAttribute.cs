using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MartiX.Result.AspNetCore
{
    public class TranslateResultToActionResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!((context.Result as ObjectResult)?.Value is IResult result)) return;

            if (!(context.Controller is ControllerBase controller)) return;

            context.Result = controller.ToActionResult(result);
        }
    }
}
