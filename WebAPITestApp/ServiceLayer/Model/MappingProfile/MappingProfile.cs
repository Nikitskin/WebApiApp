using AutoMapper;
using DBLayer.DbData;
using ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Model.MappingProfile
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<Task<List<Product>>, Task<List<ProductDto>>>();
            CreateMap<Task<Product>, Task<ProductDto>>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<Task<List<Order>>, Task<List<OrderDto>>>();
            CreateMap<Task<Order>, Task<OrderDto>>();
        }
    }
}
