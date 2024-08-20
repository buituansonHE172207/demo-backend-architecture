using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoBackendArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductDto productDto)
    {
        productService.CreateProduct(productDto);
        return Ok();
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType<ProductDto>(StatusCodes.Status200OK)]
    public IActionResult GetProductById(int id)
    {
        var product = productService.GetProductById(id);
        if(product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}