﻿namespace DemoBackendArchitecture.API.Models;

public class CreateProductRequest
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}