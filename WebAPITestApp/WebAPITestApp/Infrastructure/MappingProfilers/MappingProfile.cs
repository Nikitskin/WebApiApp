using AutoMapper;
using DBLayer.DbData;
using DTOLib;
using WebAPITestApp.Models.AuthModels;
using WebAPITestApp.Models.Order;
using WebAPITestApp.Models.Product;

namespace WebAPITestApp.Infrastructure.MappingProfilers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, ProductFullModel>();
            CreateMap<ProductDto, ProductCoreModel>();
            CreateMap<ProductCoreModel, ProductDto>();
            CreateMap<ProductFullModel, ProductDto>();
            CreateMap<UserModel, User>();

            //CreateMap<OrderDto, OrderCoreModel>();
            CreateMap<OrderDto, OrderResponseModel>().ForMember(dst => dst.ProductModels,
                opt => opt.MapFrom(src => src.Products));
            //CreateMap<OrderCoreModel, OrderDto>();
            CreateMap<OrderEditModel, OrderDto>().ForMember(dst => dst.ProductsIds,
                opt => opt.ResolveUsing((src,dst) => src.ProductIds));
        }
    }
}
