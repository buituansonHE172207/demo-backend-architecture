using System.Security.Claims;
using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Application.Common.Interfaces;

public interface ITokenService
{
    public string GenerateToken(User user);
    ClaimsPrincipal ValidateToken(string jwtCookie);
}