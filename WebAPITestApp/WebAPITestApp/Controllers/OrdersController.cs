using System.Collections.Generic;
using System.Threading.Tasks;
using DTOLib;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLogger;
using ServiceLayer.DatabaseServices.Orders;
using WebAPITestApp.Infrastructure.Attributes;
using WebAPITestApp.Models.Order;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrdersService _service;

        public OrdersController(IOrdersService service, ILoggerService logger)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<OrderResponseModel>> Get()
        {
            var list = await _service.GetAllOrders();
            return AutoMapper.Mapper.Map<List<OrderDto>, List<OrderResponseModel>>(list);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<OrderResponseModel> Get(int id)
        {
            var order = await _service.GetOrder(id);
            return AutoMapper.Mapper.Map<OrderDto, OrderResponseModel>(order);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public async Task Post([FromBody]OrderEditModel value)
        {
            var order = AutoMapper.Mapper.Map<OrderEditModel, OrderDto>(value);
            order.UserName = User.Identity.Name;
            await _service.AddOrder(order);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public async Task Put(int id, [FromBody]OrderEditModel value)
        {
            var order = AutoMapper.Mapper.Map<OrderEditModel, OrderDto>(value);
            order.UserName = User.Identity.Name;
            order.Id = id;
            await _service.Update(order);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Delete(int id)
        {
            await _service.Remove(id);
        }
    }
}
