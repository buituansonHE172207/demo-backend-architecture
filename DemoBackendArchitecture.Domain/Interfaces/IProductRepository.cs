using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Domain.Interfaces;

public interface IProductRepository
{
    void Add(Product product);
    Product? GetById(int id);
    void Update(Product product);
}