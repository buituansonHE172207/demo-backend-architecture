using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Domain.Entities;
using AutoMapper;

namespace DemoBackendArchitecture.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}

