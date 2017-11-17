using System.Linq;
using AutoMapper;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DTOLib;

namespace WebAPITestApp.ServiceLayer.Model.MappingProfile
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<int, OrderProduct>().
                ForMember(dst=> dst.ProductId, opt=> opt.
                ResolveUsing(x => x));
            CreateMap<OrderDto, Order>().
                ForMember(dst => dst.
                OrderProduct, opt => opt.
                ResolveUsing(s => s.ProductsIds));
            CreateMap<Order, OrderDto>().
                ForMember(dto => dto.
                Products, opt => opt.
                MapFrom(x => x.OrderProduct.
                Select(y=> y.Product).ToList())).
                        ForMember(dto => dto.UserFirstName, opt => opt.
                        MapFrom(x => x.User.UserName)); 
        }
    }
}
