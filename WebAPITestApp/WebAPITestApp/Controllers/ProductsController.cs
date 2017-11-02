using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DatabaseServices.Products;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;
using NLogger;
using WebAPITestApp.Attributes;
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

        //TODO Remove comment
        //[Authorize]
        [HttpPost]
        [ValidateModel]
        public async Task Post([FromBody]ProductModel value)
        {
            await _service.AddProduct(AutoMapper.Mapper.Map<ProductModel, ProductDto>(value));
        }

        [Authorize]
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task Put([FromBody]ProductModel value)
        {
            await _service.Update(AutoMapper.Mapper.Map<ProductModel, ProductDto>(value));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Remove(id);
        }
    }
}
