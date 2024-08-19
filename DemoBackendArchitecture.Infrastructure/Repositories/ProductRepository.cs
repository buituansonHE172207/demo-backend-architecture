using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;
using DemoBackendArchitecture.Infrastructure.Data;

namespace DemoBackendArchitecture.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    //inherit Interface of domain layer
    public void Add(Product product)
    {
        //Implement Add method
        _context.Add(product);
        _context.SaveChanges();
    }
    
    public Product? GetById(int id)
    {
        return _context.Products.Find(id);
    }
}