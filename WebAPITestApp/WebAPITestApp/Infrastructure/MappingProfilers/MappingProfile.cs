using System;
using AutoMapper;
using DevOne.Security.Cryptography.BCrypt;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DTOLib;
using WebAPITestApp.Web.Models.AuthModels;
using WebAPITestApp.Web.Models.Order;
using WebAPITestApp.Web.Models.Product;

namespace WebAPITestApp.Web.Infrastructure.MappingProfilers
{
    public class MappingProfile : Profile
    {
        private const string _salt = "$2a$10$rBV2JDeWW3.vKyeQcM8fFO";

        public MappingProfile()
        {
            CreateMap<ProductDto, ProductFullModel>();
            CreateMap<ProductDto, ProductCoreModel>();
            CreateMap<ProductCoreModel, ProductDto>();
            CreateMap<ProductFullModel, ProductDto>();

            //todo make it clear
            CreateMap<UserModel, User>();
            
                //todo remove if normalized
            //CreateMap<UserModel, User>().ForMember(dst => dst.PasswordHash , 
            //    opt => opt.MapFrom(src => BCryptHelper.
            //    HashPassword(src.Password, _salt))).
            //    ForMember(dst => dst.LastPasswordChangedDate, opt => opt.MapFrom(src => DateTime.Now.ToShortDateString()));

            //CreateMap<OrderDto, OrderCoreModel>();
            CreateMap<OrderDto, OrderResponseModel>().ForMember(dst => dst.ProductModels,
                opt => opt.MapFrom(src => src.Products));
            //CreateMap<OrderCoreModel, OrderDto>();
            CreateMap<OrderEditModel, OrderDto>().ForMember(dst => dst.ProductsIds,
                opt => opt.ResolveUsing((src,dst) => src.ProductIds));
        }
    }
}

