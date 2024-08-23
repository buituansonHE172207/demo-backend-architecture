using DemoBackendArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoBackendArchitecture.API.Controllers;

public class AuthenticationController(IAuthService authService) : BaseController
{
    private readonly IAuthService _authService = authService;
    
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        var result = await _authService.SignInAsync(request);
        return Ok(result);
    }
}