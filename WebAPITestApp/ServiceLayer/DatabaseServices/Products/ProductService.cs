using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.UnitOfWork;
using ServiceLayer.Models;
using AutoMapper;

namespace ServiceLayer.DatabaseServices.Products
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProduct(ProductControllerModel product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductControllerModel, Product>());
            var dbProduct = Mapper.Map<ProductControllerModel, Product>(product);
            _unitOfWork.ProductsRepository.Create(dbProduct);
            Save();
        }

        public async Task<ProductControllerModel> GetProduct(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task<ProductControllerModel>, Task<Product>>());
            var productItem = _unitOfWork.ProductsRepository.GetItem(id);
            var product = Mapper.Map<Task<Product>, Task<ProductControllerModel>>(productItem);
            return await product;
        }

        public void Remove(int id)
        {
            var product = _unitOfWork.ProductsRepository.GetItem(id);
            _unitOfWork.ProductsRepository.Delete(product.Result);
            Save();
        }

        public async Task<List<ProductControllerModel>> GetAllProducts()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task<List<ProductControllerModel>>, Task<List<Product>>>());
            var list = _unitOfWork.ProductsRepository.GetAll();
            return await Mapper.Map<Task<List<Product>>, Task<List<ProductControllerModel>>>(list);
        }

        public void Update(ProductControllerModel product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductControllerModel, Product>());
            var dbProduct = Mapper.Map<ProductControllerModel, Product>(product);
            _unitOfWork.ProductsRepository.Update(dbProduct);
            Save();
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
