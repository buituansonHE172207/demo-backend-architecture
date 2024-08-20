using AutoMapper;
using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;

namespace DemoBackendArchitecture.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    public void CreateProduct(ProductDto productDto)
    {
        //Mapping the productDto to a Product entity
        var product = mapper.Map<Product>(productDto);
        //Setting the CreatedAt and UpdatedAt properties of the product
        product.CreatedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;
        //Calling the Add method of the productRepository
        productRepository.Add(product);
    }

    public ProductDto? GetProductById(int id)
    {
        //Calling the GetById method of the productRepository
        var product = productRepository.GetById(id);
        //Returning the product if it is not null, otherwise returning null
        return product == null ? null : mapper.Map<ProductDto>(product);
    }

    public void UpdateProduct(int id, ProductDto productDto)
    {
        //Calling the GetById method of the productRepository
        var product = productRepository.GetById(id);
        //Returning if the product is null
        if(product == null)
        {
            return;
        }
        //Mapping the properties of the productDto to the product
        mapper.Map(productDto, product);
        //Setting other properties of the product
        product.UpdatedAt = DateTime.UtcNow;
        //Calling the Update method of the productRepository
        productRepository.Update(product);
}
}