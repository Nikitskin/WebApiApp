using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using DTOLib.AuthModels;

namespace NLogger.Filters
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
            //TODO It will be better to move models in separeted project for me
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                _logger.Trace(string.Format("Controller {0} started for user {1} with method {2} at {3}", context.Controller,
                    ((UserModel)context.ActionArguments["UserModel"]).UserName,
                    controllerActionDescriptor.MethodInfo.Name, DateTime.Now.ToShortDateString()));
            }
        }
    }
}