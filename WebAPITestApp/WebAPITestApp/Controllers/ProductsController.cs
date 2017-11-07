using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DatabaseServices.Products;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;
using WebAPITestApp.Attributes;
using WebAPITestApp.Models.ProductControllers;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<ProductFullModel>> Get()
        {
            var list = await _service.GetAllProducts();
            return AutoMapper.Mapper.Map<List<ProductDto>, List<ProductFullModel>>(list);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ProductFullModel> Get(int id)
        {
            var product = await _service.GetProduct(id);
            return AutoMapper.Mapper.Map<ProductDto, ProductFullModel> (product);
        }

        [Authorize]
        [HttpPost]
        [ValidateModel]
        public async Task Post([FromBody]ProductCoreModel value)
        {
            await _service.AddProduct(AutoMapper.Mapper.Map<ProductCoreModel, ProductDto>(value));
        }

        [Authorize]
        [HttpPut]
        [ValidateModel]
        public async Task Put([FromBody]ProductFullModel value)
        {
            await _service.Update(AutoMapper.Mapper.Map<ProductFullModel, ProductDto>(value));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Remove(id);
        }
    }
}
