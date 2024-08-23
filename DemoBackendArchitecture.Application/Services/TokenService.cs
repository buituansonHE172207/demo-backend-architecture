using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DemoBackendArchitecture.Application.Common.Interfaces;
using DemoBackendArchitecture.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DemoBackendArchitecture.Application.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;
    public string GenerateToken(User user)
    {
        // Generate token
        // Get the security key from the appsettings.json
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        // Get the credentials
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        // Create the claims
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        // Create the token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: _configuration["Jwt:Expires"] == "0" ? DateTime.Now.AddMinutes(10) : DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:Expires"])),
            signingCredentials: credentials
        );
        // Return the token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}