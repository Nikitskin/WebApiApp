using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.NLogger;

namespace WebAPITestApp.DBLayer.DBRepository
{
    public class ProductRepository : DbRepository<Product>
    {
        public ProductRepository(OrderContext context, ILoggerService logger) : base(context, logger)
        {

        }
        public override async Task<Product> GetItem(int id)
        {
            return await DbSet.Include(product => product.OrderProduct).
                ThenInclude(order => order.Order).
                FirstAsync(p => p.Id == id);
        }
    }
}