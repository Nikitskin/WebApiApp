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
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddProduct(ProductDto product)
        {
            var dbProduct = Mapper.Map<ProductDto, Product>(product);
            _unitOfWork.ProductsRepository.Create(dbProduct);
            Save();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO GetItem is async method so use await and after awaiting map to dto model
            var productItem = _unitOfWork.ProductsRepository.GetItem(id);
            // TODO You have added _mapper field, but still don't use it.
            var product = Mapper.Map<Task<Product>, Task<ProductDto>>(productItem);
            return await product;
        }

        public void Remove(int id)
        {
            var product = _unitOfWork.ProductsRepository.GetItem(id);
            _unitOfWork.ProductsRepository.Delete(product.Result);
            Save();
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var list = _unitOfWork.ProductsRepository.GetAll();
            return await Mapper.Map<Task<List<Product>>, Task<List<ProductDto>>>(list);
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
