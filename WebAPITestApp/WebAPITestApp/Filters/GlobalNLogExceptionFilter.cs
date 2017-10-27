using Microsoft.AspNetCore.Mvc.Filters;
using NLogger;

namespace WebAPITestApp.Filters
{
    public class GlobalNLogExceptionFilter : IExceptionFilter
    {
        private readonly ILoggerService _logger;

        public GlobalNLogExceptionFilter(ILoggerService logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.Error("Global error appeared during execution ", context.Exception);
        }
    }
}