using System.Collections.Generic;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;

namespace ServiceLayer.DatabaseServices.Products
{
    public interface IProductService
    {
        Task AddProduct(ProductDto product);
        Task<ProductDto> GetProduct(int id);
        Task Remove(int id);
        Task<List<ProductDto>> GetAllProducts();
        Task Update(ProductDto product);
    }
}
