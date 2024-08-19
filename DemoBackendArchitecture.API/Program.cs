using DemoBackendArchitecture.API.Mappings;
using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Application.Mappings;
using DemoBackendArchitecture.Application.Services;
using DemoBackendArchitecture.Domain.Interfaces;
using DemoBackendArchitecture.Infrastructure.Data;
using DemoBackendArchitecture.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add DBContext with EF Core

//Register services for Application layer
builder.Services.AddScoped<IProductService, ProductService>();
//Register services for Infrastructure layer
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//Configure Automapper
builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly, typeof(ProductMapping).Assembly);
//Configure controllers and other services
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
