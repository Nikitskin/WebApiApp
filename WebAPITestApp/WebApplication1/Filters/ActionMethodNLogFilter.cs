using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Logger.Filters
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
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                _logger.Trace(string.Format("Action finished for controller {0} started with method {1} at {2}", context.Controller,
                    controllerActionDescriptor.MethodInfo.Name, DateTime.Now.ToShortDateString()));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            //TODO Implement user tracking from attribute
            if (controllerActionDescriptor != null)
            {
                _logger.Trace(string.Format("Controller {0} started with method {1} at {2}", context.Controller, 
                    controllerActionDescriptor.MethodInfo.Name, DateTime.Now.ToShortDateString()));
            }
        }
    }
}