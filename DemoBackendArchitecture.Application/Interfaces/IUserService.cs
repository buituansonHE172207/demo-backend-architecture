using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Application.Interfaces;

public interface IUserService
{
    string? Authenticate(UserDto userDto);
    User Register(UserDto userDto);
}