using DemoBackendArchitecture.Application.Common.Interfaces;
using DemoBackendArchitecture.Application.Common.Model.User;
using Microsoft.AspNetCore.Mvc;

namespace DemoBackendArchitecture.API.Controllers;

public class AuthController(IAuthService authService) : BaseController
{
    private readonly IAuthService _authService = authService;
    
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] UserSignInRequest request) 
        => Ok(await _authService.SignIn(request));
}