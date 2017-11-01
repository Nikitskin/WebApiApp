using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLogger;

namespace WebAPITestApp.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.HttpContext.Response.WriteAsync(string.Format("Model state invalid. Bad request {0}", 
                    actionContext.ModelState.Values.SelectMany(e=>e.Errors).FirstOrDefault().ErrorMessage)); 
            }
        }
    }
}
