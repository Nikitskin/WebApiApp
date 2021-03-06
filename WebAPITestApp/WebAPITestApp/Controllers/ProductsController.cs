﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.DTOLib;
using WebAPITestApp.ServiceLayer.DatabaseServices.Products;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Models.Product;

namespace WebAPITestApp.Web.Controllers
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ProductCoreModel> Get(int id)
        {
            var product = await _service.GetProduct(id);
            return AutoMapper.Mapper.Map<ProductDto, ProductCoreModel>(product);
        }

        [Authorize]
        [HttpPost]
        [ValidateModel]
        public async Task Post([FromBody]ProductCoreModel value)
        {
            await _service.AddProduct(AutoMapper.Mapper.Map<ProductCoreModel, ProductDto>(value));
        }

        [Authorize]
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task Put(int id, [FromBody]ProductCoreModel value)
        {
            var product = AutoMapper.Mapper.Map<ProductCoreModel, ProductDto>(value);
            product.Id = id;
            await _service.Update(product);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Remove(id);
        }
    }
}
