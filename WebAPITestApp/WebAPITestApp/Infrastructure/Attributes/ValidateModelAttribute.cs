using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPITestApp.Infrastructure.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                var error = actionContext.ModelState.Values.SelectMany(e => e.Errors).FirstOrDefault();
                var errorText = string.IsNullOrEmpty(error?.ErrorMessage) ? error.Exception.Message : error.ErrorMessage;
                actionContext.Result = new BadRequestObjectResult(string.Format("Model state invalid. Bad request with error message = {0}", errorText));
                base.OnActionExecuting(actionContext);
            }
        }
    }
}
