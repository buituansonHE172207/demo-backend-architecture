using System.ComponentModel.DataAnnotations;
namespace DemoBackendArchitecture.API.Models;

public class CreateProductRequest
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Price is required")] 
        [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Stock is required")]
        [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    
    public string? Description { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
}