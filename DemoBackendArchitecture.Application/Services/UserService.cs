using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace DemoBackendArchitecture.Application.Services;

public class UserService(IUserRepository userRepository, IConfiguration configuration,IPasswordHasher<User> passwordHasher, IMapper mapper, IRoleService roleService) : IUserService
{
}