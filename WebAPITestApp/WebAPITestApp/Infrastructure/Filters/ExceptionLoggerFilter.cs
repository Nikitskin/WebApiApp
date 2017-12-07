using Microsoft.AspNetCore.Mvc.Filters;
using WebAPITestApp.NLogger;

namespace WebAPITestApp.Web.Infrastructure.Filters
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
            _logger.Error("Global error appeared during execution {0}", context.Exception);
        }
    }
}