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
        //Implement GetById method
        return context.Products.Find(id);
    }

    public void Update(Product product)
    {
        //Implement Update method
        context.Products.Update(product);
        context.SaveChanges();
    }

    public void Delete(Product product)
    {
        //Implement Delete method
        context.Products.Remove(product);
        context.SaveChanges();
    }
}