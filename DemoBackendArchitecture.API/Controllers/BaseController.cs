using Microsoft.AspNetCore.Mvc;

namespace DemoBackendArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("API is working!");
    }
}