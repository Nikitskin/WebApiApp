using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DBLayer.UnitOfWork;
using WebAPITestApp.DTOLib;

namespace WebAPITestApp.ServiceLayer.DatabaseServices.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProduct(ProductDto product)
        {
            var dbProduct = Mapper.Map<ProductDto, Product>(product);
            _unitOfWork.ProductsRepository.Create(dbProduct);
            await Save();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var productItem = await _unitOfWork.ProductsRepository.GetItem(id);
            var product = Mapper.Map<Product, ProductDto>(productItem);
            return product;
        }

        public async Task Remove(int id)
        {
            var product = await _unitOfWork.ProductsRepository.GetItem(id);
            _unitOfWork.ProductsRepository.Delete(product);
            await Save();
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var list = await _unitOfWork.ProductsRepository.GetAll();
            return Mapper.Map<List<Product>, List<ProductDto>>(list);
        }

        public async Task Update(ProductDto product)
        {
            var dbProduct = Mapper.Map<ProductDto, Product>(product);
            _unitOfWork.ProductsRepository.Update(dbProduct);
            await Save();
        }

        private async Task Save()
        {
            await _unitOfWork.Save();
        }
    }
}
