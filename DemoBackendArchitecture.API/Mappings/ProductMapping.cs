using AutoMapper;
using DemoBackendArchitecture.API.Models;
using DemoBackendArchitecture.Application.DTOs;

namespace DemoBackendArchitecture.API.Mappings;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductRequest, ProductDto>().ReverseMap();
        CreateMap<UpdateProductRequest, ProductDto>().ReverseMap();
    }
}