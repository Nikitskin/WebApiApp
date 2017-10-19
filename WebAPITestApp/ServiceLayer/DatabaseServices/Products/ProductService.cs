using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.UnitOfWork;

namespace ServiceLayer.DatabaseServices.Products
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProduct(Product product)
        {
            _unitOfWork.ProductsRepository.Create(product);
            Save();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork.ProductsRepository.GetItem(id);
        }

        public void Remove(int id)
        {
            var product = _unitOfWork.ProductsRepository.GetItem(id);
            _unitOfWork.ProductsRepository.Delete(product.Result);
            Save();
        }

        public Task<List<Product>> GetAllProducts()
        {
            return _unitOfWork.ProductsRepository.GetAll();
        }

        public void Update(Product product)
        {
            _unitOfWork.ProductsRepository.Update(product);
            Save();
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
