using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;

namespace DemoBackendArchitecture.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void CreateProduct(ProductDto productDto)
    {
        var product = new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock,
            Description = productDto.Description,
            ImageUrl = productDto.ImageUrl,
            CreatedAt = productDto.CreatedAt,
            UpdatedAt = productDto.UpdatedAt
        };
        _productRepository.Add(product);
    }

    public ProductDto? GetProductById(int id)
    {
        var product = _productRepository.GetById(id);
        if(product == null)
        {
            return null;
        }
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}