using System.Linq;
using AutoMapper;
using DTOLib;
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

            CreateMap<OrderDto, OrderCoreModel>().ForMember(dto =>
                dto.ProductsIds, opt => 
                opt.MapFrom(x => 
                     x.ProductsDto.Select(product => 
                         product.Id).ToList()));
            CreateMap<OrderDto, OrderFullModel>().ForMember(dto => 
                dto.ProductsIds, opt => 
                    opt.MapFrom(x => 
                        x.ProductsDto.Select(product => 
                            product.Id).ToList()));
            CreateMap<OrderCoreModel, OrderDto>().ForMember(dto =>
             dto.ProductsDto, opt =>
                opt.MapFrom(x =>
                 x.ProductsIds.ToList())).AfterMap((src, dst) =>
                    Mapper.Map(src.ProductsIds, dst.ProductsDto.Select(prod =>
                     prod.Id)));
            CreateMap<OrderFullModel, OrderDto>();
        }
    }
}
