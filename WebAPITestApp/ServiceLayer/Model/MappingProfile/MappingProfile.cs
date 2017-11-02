using System.Linq;
using AutoMapper;
using DBLayer.DbData;
using DTOLib.DatabaseModels;

namespace ServiceLayer.Model.MappingProfile
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>().ForMember(dto => dto.Orders,
                opt => opt.MapFrom(x => x.OrderProduct.Select(y => y.Order).ToList())); ;
            CreateMap<OrderDto, Order>().ForMember(order=>order.User.FirstName, dto=>dto.MapFrom(d=>d.UserName));
            CreateMap<Order, OrderDto>().ForMember(dto => dto.Products,
                opt => opt.MapFrom(x=>x.OrderProduct.Select(y=>y.Product).ToList())); 
        }
    }
}
