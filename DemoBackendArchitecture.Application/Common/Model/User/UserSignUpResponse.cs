namespace DemoBackendArchitecture.Application.Common.Model.User;

public class UserSignUpResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; }
}