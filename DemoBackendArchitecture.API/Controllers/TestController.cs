using Microsoft.AspNetCore.Mvc;

namespace DemoBackendArchitecture.API.Controllers;

public class TestController(IConfiguration configuration) : BaseController
{
    private readonly IConfiguration _configuration = configuration;

    //an api test to check api is working and show the configuration value
    [HttpGet]
    public IActionResult Test()
    {
        // Print all the configuration values
        var result = "";
        foreach (var item in _configuration.AsEnumerable())
        {
            result += item.Key + " : " + item.Value + "\n";
        }
        return Ok(result);
    }
    
}