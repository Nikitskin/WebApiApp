using System.Collections.Generic;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLogger;
using ServiceLayer.DatabaseServices.Orders;
using WebAPITestApp.Attributes;
using WebAPITestApp.Models.OrderControllers;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrdersService _service;

        public OrdersController(IOrdersService service, ILoggerService logger)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<OrderFullModel>> Get()
        {
            var list = await _service.GetAllOrders();
            return AutoMapper.Mapper.Map<List<OrderDto>, List<OrderFullModel>>(list);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<OrderCoreModel> Get(int id)
        {
            var order = await _service.GetOrder(id);
            return AutoMapper.Mapper.Map<OrderDto, OrderCoreModel>(order);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public async Task Post([FromBody]OrderCoreModel value)
        {
            value.UserName = User.Identity.Name;
            await _service.AddOrder(AutoMapper.Mapper.Map<OrderCoreModel, OrderDto>(value));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public async Task Put([FromBody]OrderFullModel value)
        {
            value.UserName = User.Identity.Name;
            await _service.Update(AutoMapper.Mapper.Map<OrderFullModel, OrderDto>(value));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Delete(int id)
        {
            await _service.Remove(id);
        }
    }
}
