using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebAPITestApp.Infrastructure.Middleware
{
    public class ErrorHandlerMiddleware
    {
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
            catch (DbUpdateConcurrencyException dbException)
            {
                await context.Response.WriteAsync(string.Format("No match found. Error : {0}", dbException.Message));
            }
            catch (InvalidOperationException invslidException)
            {
                await context.Response.WriteAsync(string.Format("No match found. Error : {0}", invslidException.Message));
            }
            catch (NullReferenceException nullException)
            {
               
                await context.Response.WriteAsync(string.Format("No match found. Error : {0}", nullException.Message));
            }
        }
    }
}