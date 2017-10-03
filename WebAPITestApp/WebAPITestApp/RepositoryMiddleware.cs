using DBLayer.Contexts;
using DBLayer.DbData;
using DBLayer.UnitOfWork;
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

        public async Task Invoke(HttpContext httpContext, UnitOfWork unitOfWork)
        {
            unitOfWork.Orders.Create(new Order
            {
                ProductName = "testWithOrderContext2",
                Value = 233
            });
            unitOfWork.Products.Create(new Product
            {
                ProductName = "ProductName",
                Description = " somedescr"
            });
            unitOfWork.Users.Create(new User
            {
                FirstName = "FirstName",
                SecondName = "SecondName"
            });
            unitOfWork.Save();
        }
    }
}
