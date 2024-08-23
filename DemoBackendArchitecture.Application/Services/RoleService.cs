using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;

namespace DemoBackendArchitecture.Application.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
}