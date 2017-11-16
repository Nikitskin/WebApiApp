using System;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPITestApp.NLogger;

namespace WebAPITestApp.Web.Infrastructure.Filters
{
    public class ActionMethodNLogFilter : IActionFilter
    {
        private readonly ILoggerService _logger;

        public ActionMethodNLogFilter(ILoggerService logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                _logger.Trace(string.Format("Action finished for controller {0} started with method {1} at {2}", context.Controller,
                    controllerActionDescriptor.MethodInfo.Name, DateTime.Now.ToShortDateString()));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                _logger.Trace(string.Format("Controller {0} started for user {1} with method {2} ", context.Controller,
                    context.HttpContext.User.Identity.Name ?? "anonymous", controllerActionDescriptor.MethodInfo.Name));
            }
        }
    }
}