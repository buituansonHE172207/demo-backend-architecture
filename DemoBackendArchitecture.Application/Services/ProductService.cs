using AutoMapper;
using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;

namespace DemoBackendArchitecture.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    
}