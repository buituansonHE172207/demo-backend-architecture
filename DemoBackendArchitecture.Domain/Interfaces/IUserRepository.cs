using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Domain.Interfaces;

public interface IUserRepository
{
    User? GetUserByEmail(string? userEmail);
    User Add(User user);
}