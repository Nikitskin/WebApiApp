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
            CreateMap<Product, ProductDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>().ForMember(dto => dto.OrderProduct,
                opt => opt.MapFrom(x=>x.OrderProduct.Select(y=>y.Product).ToList())); 
        }
    }
}
