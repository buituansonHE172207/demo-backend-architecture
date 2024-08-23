using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Application.Common.Model.User;

public class UserSignInResponse
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; }
    public string Token { get; set; } = string.Empty;
}