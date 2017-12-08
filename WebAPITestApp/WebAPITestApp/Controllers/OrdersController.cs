using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.DTOLib;
using WebAPITestApp.NLogger;
using WebAPITestApp.ServiceLayer.DatabaseServices.Orders;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Infrastructure.MappingProfilers;
using WebAPITestApp.Web.Models.Order;

namespace WebAPITestApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrdersService _service;
        private readonly IMap _mapper;

        public OrdersController(IOrdersService service, ILoggerService logger, IMap mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<OrderResponseModel>> Get()
        {
            var list = await _service.GetAllOrders();
            return _mapper.Map<List<OrderDto>, List<OrderResponseModel>>(list);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<OrderResponseModel> Get(int id)
        {
            var order = await _service.GetOrder(id);
            return _mapper.Map<OrderDto, OrderResponseModel>(order);

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public async Task Post([FromBody]OrderEditModel value)
        {
            var order = _mapper.Map<OrderEditModel, OrderDto>(value);
            order.UserFirstName = User.Identity.Name;
            await _service.AddOrder(order);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ValidateModel]
        public async Task Put(int id, [FromBody]OrderEditModel value)
        {
            var order = _mapper.Map<OrderEditModel, OrderDto>(value);
            order.UserFirstName = User.Identity.Name;
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
