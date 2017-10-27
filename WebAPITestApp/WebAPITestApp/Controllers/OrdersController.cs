using System.Collections.Generic;
using System.Threading.Tasks;
using DTOLib.DatabaseModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLogger;
using ServiceLayer.DatabaseServices.Orders;
using WebAPITestApp.Models;

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
            var order = AutoMapper.Mapper.Map<List<OrderDto>,List<OrderModel>> (list);
            return order;
        }

        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<OrderModel> Get(int id)
        {
            var order = await _service.GetOrder(id);
            return AutoMapper.Mapper.Map<OrderDto, OrderModel>(order);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Post([FromBody]OrderModel value)
        {
            if (!ModelState.IsValid)
            {
                _logger.Info("User entered incorrect model in OrderController model - ", value);
                return;
            }
            _service.AddOrder(AutoMapper.Mapper.Map<OrderModel, OrderDto>(value));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Put([FromBody]OrderModel value)
        {
            if (!ModelState.IsValid)
            {
                _logger.Info("User entered incorrect model in OrderController model - ", value);
                return;
            }
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
