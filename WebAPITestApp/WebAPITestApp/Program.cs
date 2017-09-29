using DatabaseLayer.DbData;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Ninject;
using WebAPITestApp.DBRepository;

namespace WebAPITestApp
{
    public class Program
    {
        [Inject]
        private IDBRepository<Order> rep;

        public static void Main(string[] args)
        {
            new Program().testMethod();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public void testMethod()
        {
            rep.Create(new Order
            {
                ProductName = "test",
                Value = 22
            }
            );
        }
    }
}
