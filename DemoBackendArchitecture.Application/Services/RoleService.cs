using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;

namespace DemoBackendArchitecture.Application.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public Role? GetRoleByName(string roleName)
    {
        //Call the repository to get the role by name
        return roleRepository.GetRoleByName(roleName);
    }
}