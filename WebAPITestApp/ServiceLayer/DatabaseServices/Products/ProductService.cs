using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.UnitOfWork;
using AutoMapper;
using DTOLib.DatabaseModels;

namespace ServiceLayer.DatabaseServices.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProduct(ProductDto product)
        {
            var dbProduct = Mapper.Map<ProductDto, Product>(product);
            _unitOfWork.ProductsRepository.Create(dbProduct);
            Save();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var productItem = await _unitOfWork.ProductsRepository.GetItem(id);
            var product = Mapper.Map<Product, ProductDto>(productItem);
            return product;
        }

        public void Remove(int id)
        {
            var product = _unitOfWork.ProductsRepository.GetItem(id);
            _unitOfWork.ProductsRepository.Delete(product.Result);
            Save();
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var list = await _unitOfWork.ProductsRepository.GetAll();
            return Mapper.Map<List<Product>, List<ProductDto>>(list);
        }

        public void Update(ProductDto product)
        {
            var dbProduct = Mapper.Map<ProductDto, Product>(product);
            _unitOfWork.ProductsRepository.Update(dbProduct);
            Save();
        }

        private void Save()
        {
            _unitOfWork.Save();
        }
    }
}
