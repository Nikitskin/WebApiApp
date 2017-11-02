using System.Collections.Generic;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NLogger;
using ServiceLayer.DatabaseServices.Orders;
using WebAPITestApp.Attributes;
using WebAPITestApp.Models;
using WebAPITestApp.Models.OrderControllers;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrdersService _service;
        private ILoggerService _logger;

        public OrdersController(IOrdersService service, ILoggerService logger)
        {
            _service = service;
            _logger = logger;
        }

        //TODO remove comments as they were used for debug
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<OrderModel>> Get()
        {
            var list = await _service.GetAllOrders();
            return AutoMapper.Mapper.Map<List<OrderDto>, List<OrderModel>>(list);
        }

        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<OrderModel> Get(int id)
        {
            var order = await _service.GetOrder(id);
            return AutoMapper.Mapper.Map<OrderDto, OrderModel>(order);
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public async void Post([Bind("ordered_date")]OrderModel value)
        {
            _service.AddOrder(AutoMapper.Mapper.Map<OrderModel, OrderDto>(value));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public void Put([FromBody]OrderModel value)
        {
            _service.Update(AutoMapper.Mapper.Map<OrderModel, OrderDto>(value));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
    }
}
