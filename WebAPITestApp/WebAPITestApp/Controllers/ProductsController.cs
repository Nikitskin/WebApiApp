using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DatabaseServices.Products;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;
using NLogger;
using WebAPITestApp.Models;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductService _service;
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
        public Task<ProductDto> Get(int id)
        {
            return _service.GetProduct(id);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody]ProductModel value)
        {
            if (!ModelState.IsValid)
            {
                _logger.Info("User entered incorrect model in ProductController model - ", value);
                return;
            }
            _service.AddProduct(AutoMapper.Mapper.Map<ProductModel, ProductDto>(value));
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put([FromBody]ProductModel value)
        {
            if (!ModelState.IsValid)
            {
                _logger.Info("User entered incorrect model in ProductController model - ", value);
                return;
            }
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
