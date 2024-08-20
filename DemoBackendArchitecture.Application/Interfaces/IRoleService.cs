using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Application.Interfaces
{
    public interface IRoleService
    {
        Role? GetRoleByName(string roleName);
    }
};

