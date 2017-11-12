using DBLayer.Contexts;
using DBLayer.DbData;
using DBLayer.DBRepository;
using DBLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.DatabaseServices.Orders;
using ServiceLayer.DatabaseServices.Products;
using WebAPITestApp.Infrastructure;

namespace WebAPITestApp
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
