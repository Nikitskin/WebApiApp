using DBLayer.DbData;
using DBLayer.DBRepository;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPITestApp.Services
{
    public class RepositoryMiddleware<T> where T : class
    {
        private readonly RequestDelegate _next;

        public RepositoryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IDBRepository<Order> repository, RepositoryService<T> repositoryService)
        {
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            //repository.Create(new Order
            //{
            //    ProductName = "test",
            //    Value = 22
            //});
        }
    }
}
