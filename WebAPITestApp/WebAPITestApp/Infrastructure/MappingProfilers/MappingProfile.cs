using System.Linq;
using AutoMapper;
using DTOLib.DatabaseModels;
using WebAPITestApp.Models.OrderControllers;
using WebAPITestApp.Models.ProductControllers;

namespace WebAPITestApp.Infrastructure.MappingProfilers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, ProductFullModel>().ForMember(fullmodel => fullmodel.OrderIds, 
                dto=>dto.MapFrom(d=>d.Orders.Select(y=>y.Id).ToList()));
            CreateMap<ProductCoreModel, ProductDto>();
            CreateMap<ProductFullModel, ProductDto>();

            //TODO refactor as neede when have time
            CreateMap<OrderDto, OrderFullModel>();
            CreateMap<OrderCoreModel, OrderDto>();
            CreateMap<OrderFullModel, OrderDto>().ForMember(dto => dto.Products,
                opt => opt.MapFrom(x => x.Products.Select(y => y).ToList()));
        }
    }
}
