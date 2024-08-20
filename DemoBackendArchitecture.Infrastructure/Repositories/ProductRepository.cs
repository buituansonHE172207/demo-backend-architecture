using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;
using DemoBackendArchitecture.Infrastructure.Data;

namespace DemoBackendArchitecture.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    //inherit Interface of domain layer
    public void Add(Product product)
    {
        //Implement Add method
        context.Add(product);
        context.SaveChanges();
    }
    
    public Product? GetById(int id)
    {
        return context.Products.Find(id);
    }
}