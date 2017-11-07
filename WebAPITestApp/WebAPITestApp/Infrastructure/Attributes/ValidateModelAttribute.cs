using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPITestApp.Infrastructure.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {

        public override async void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                await actionContext.HttpContext.Response.WriteAsync(string.Format("Model state invalid. Bad request {0}", 
                    actionContext.ModelState.Values.SelectMany(e=>e.Errors).FirstOrDefault().ErrorMessage)); 
            }
        }
    }
}
