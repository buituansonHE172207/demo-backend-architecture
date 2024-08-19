using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoBackendArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }   
    
    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductDto productDto)
    {
        _productService.CreateProduct(productDto);
        return Ok();
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType<ProductDto>(StatusCodes.Status200OK)]
    public IActionResult GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        if(product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}