using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DTOLib.DatabaseModels;

namespace ServiceLayer.DatabaseServices.Products
{
    public interface IProductService
    {
        void AddProduct(ProductDto product);
        Task<ProductDto> GetProduct(int id);
        void Remove(int id);
        Task<List<ProductDto>> GetAllProducts();
        void Update(ProductDto product);
    }
}
