using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using DemoBackendArchitecture.API.Mappings;
using DemoBackendArchitecture.Application.Interfaces;
using DemoBackendArchitecture.Application.Mappings;
using DemoBackendArchitecture.Application.Services;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;
using DemoBackendArchitecture.Infrastructure.Data;
using DemoBackendArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DemoBackendArchitecture.API.Configurations;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        // Register services for Application layer
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        // Register services for Infrastructure layer
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        // Register PasswordHasher
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        // Configure Automapper
        services.AddAutoMapper(typeof(ProductMappingProfile).Assembly, typeof(ProductMapping).Assembly);
        services.AddAutoMapper(typeof(UserMappingProfile).Assembly, typeof(UserMapping).Assembly);
        // Configure controllers and other services
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
        //Configure JwtBearer
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty))
                };
            });
        // Configure Authorization
        services.AddAuthorizationBuilder()
            // Configure Authorization
            .AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"))
            .AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
        
        // Add Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}