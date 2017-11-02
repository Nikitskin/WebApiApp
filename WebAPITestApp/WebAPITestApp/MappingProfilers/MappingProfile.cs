using System.Linq;
using AutoMapper;
using DTOLib.DatabaseModels;
using WebAPITestApp.Models.OrderControllers;
using WebAPITestApp.Models.ProductControllers;

namespace WebAPITestApp.MappingProfilers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, ProductModel>();
            CreateMap<ProductModel, ProductDto>().ForMember(dto => dto.Orders,
                opt => opt.MapFrom(x => x.Orders.Select(y => y.Products).ToList())); ;
            CreateMap<OrderDto, OrderModel>();
            CreateMap<OrderModel, OrderDto>().ForMember(dto => dto.Products,
                opt => opt.MapFrom(x => x.Products.Select(y => y.Orders).ToList()));
        }
    }
}
