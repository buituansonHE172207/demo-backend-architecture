using System.ComponentModel.DataAnnotations;

namespace DemoBackendArchitecture.API.Models.AuthenticationRequest;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}