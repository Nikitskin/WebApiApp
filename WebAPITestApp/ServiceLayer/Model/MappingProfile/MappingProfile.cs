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
            // TODO You can simply map List<Product> to List<ProductDto> or Product to ProductDto. Do not map Tasks
            CreateMap<Task<Product>, Task<ProductDto>>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<Task<List<Order>>, Task<List<OrderDto>>>();
            CreateMap<Task<Order>, Task<OrderDto>>();
        }
    }
}
