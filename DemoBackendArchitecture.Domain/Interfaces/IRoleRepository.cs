using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Domain.Interfaces;

public interface IRoleRepository
{
    Role? GetRoleByName(string roleName);
}