using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPITestApp.Infrastructure.Middleware
{
    public class ErrorHandlerMiddleware
    {
        public class HttpStatusCodeException : Exception
        {
            public HttpStatusCode StatusCode { get; set; }

            public HttpStatusCodeException(HttpStatusCode statusCode)
            {
                StatusCode = statusCode;
            }
        }

        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidOperationException invslidException)
            {
                context.Response.StatusCode = (int)exception.StatusCode;
                context.Response.Headers.Clear();
                await context.Response.WriteAsync("Error. No sequence found.");
            }
            catch (ArgumentNullException nullException)
            { }

        }
    }
}