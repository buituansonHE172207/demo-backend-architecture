using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetUserByEmailAsync(string email);
}