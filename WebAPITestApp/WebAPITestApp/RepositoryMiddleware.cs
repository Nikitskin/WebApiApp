using DBLayer.Contexts;
using DBLayer.DbData;
using DBLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebAPITestApp.Services
{
    public class RepositoryMiddleware
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
                OrderedDate = DateTime.Now
            });
            unitOfWork.Products.Create(new Product
            {
                ProductName = "Prod2",
                Description = " somedescr"
            });
            unitOfWork.Users.Create(new User
            {
                FirstName = "First3",
                SecondName = "SecondName"
            });
            unitOfWork.Save();
        }
    }
}
