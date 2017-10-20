﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DatabaseServices.Products;
using System.Threading.Tasks;
using DBLayer.DbData;
using ServiceLayer.Models;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public Task<List<ProductDto>> Get()
        {
            return _service.GetAllProducts();
        }

        [Authorize]
        [HttpGet("{id}")]
        public Task<ProductDto> Get(int id)
        {
            return _service.GetProduct(id);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody]ProductDto value)
        {
            _service.Update(value);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put([FromBody]ProductDto value)
        {
            _service.AddProduct(value);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
    }
}
