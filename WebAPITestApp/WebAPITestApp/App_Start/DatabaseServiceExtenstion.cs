using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DBLayer.DBRepository;
using WebAPITestApp.DBLayer.UnitOfWork;
using WebAPITestApp.ServiceLayer.DatabaseServices.Orders;
using WebAPITestApp.ServiceLayer.DatabaseServices.Products;
using WebAPITestApp.Web.Infrastructure;

namespace WebAPITestApp.Web
{
    public static class DatabaseServiceExtenstion
    {

        public static void RegisterDatabase(this IServiceCollection services, string sqlServerConnetcionString)
        {
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<OrderContext>(opt =>
                opt.UseSqlServer(sqlServerConnetcionString));

            services.AddScoped<IDbRepository<Order>, DbRepository<Order>>();
            services.AddScoped<IDbRepository<Product>, DbRepository<Product>>();
            services.AddScoped<IDbRepository<User>, DbRepository<User>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
