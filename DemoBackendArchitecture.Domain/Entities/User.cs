namespace DemoBackendArchitecture.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    
    public ICollection<RefreshToken>? RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}