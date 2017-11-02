using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DatabaseServices.Products;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;
using Microsoft.AspNetCore.Http;
using NLogger;
using WebAPITestApp.Attributes;
using WebAPITestApp.Models;
using WebAPITestApp.Models.ProductControllers;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ILoggerService _logger;

        public ProductsController(IProductService service, ILoggerService logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<ProductModel>> Get()
        {
            var list = await _service.GetAllProducts();
            return AutoMapper.Mapper.Map<List<ProductDto>, List<ProductModel>>(list);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _service.GetProduct(id);
        }

        [Authorize]
        [HttpPost]
        [ValidateModel]
        public async void Post([FromBody]ProductModel value)
        {
            _service.AddProduct(AutoMapper.Mapper.Map<ProductModel, ProductDto>(value));
        }

        [Authorize]
        [HttpPut("{id}")]
        [ValidateModel]
        public async void Put([FromBody]ProductModel value)
        {
            _service.Update(AutoMapper.Mapper.Map<ProductModel, ProductDto>(value));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
    }
}
