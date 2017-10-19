using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;

namespace ServiceLayer.DatabaseServices.Products
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Task<Product> GetProduct(int id);
        void Remove(int id);
        Task<List<Product>> GetAllProducts();
        void Update(Product product);
    }
}
