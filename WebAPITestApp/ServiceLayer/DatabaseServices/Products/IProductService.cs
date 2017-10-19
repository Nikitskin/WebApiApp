using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using ServiceLayer.Models;

namespace ServiceLayer.DatabaseServices.Products
{
    public interface IProductService
    {
        void AddProduct(ProductControllerModel product);
        Task<ProductControllerModel> GetProduct(int id);
        void Remove(int id);
        Task<List<ProductControllerModel>> GetAllProducts();
        void Update(ProductControllerModel product);
    }
}
