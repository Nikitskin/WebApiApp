using System.Threading.Tasks;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.DBRepository
{
    public class ProductRepository : DbRepository<Product>
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }
        public override async Task<Product> GetItem(int id)
        {
            return await DbSet.Include(product => product.OrderProduct).ThenInclude(order=>order.Order).FirstAsync(p => p.Id == id);
        }
    }
}