﻿using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using DemoBackendArchitecture.Application.Common.Interfaces;
using DemoBackendArchitecture.Application.Common.Model.Product;
using DemoBackendArchitecture.Application.Common.Model.User;
using DemoBackendArchitecture.Application.Common.Utilities;
using DemoBackendArchitecture.Application.Services;
using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;
using DemoBackendArchitecture.Infrastructure.Data;
using DemoBackendArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DemoBackendArchitecture.API.Configs;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void ConfigureLayersServices(this IServiceCollection services, IConfiguration configuration)
    {

        // Register services for Application layer
        services.AddScoped<IAuthService, AuthService>();
        // Register services for Infrastructure layer
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        
        // Register services for Web layer
        services.AddSingleton<ICookieService, CookieService>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
    }

    public static void ConfigurePasswordHasher(this IServiceCollection services, IConfiguration configuration)
    {
        // Register PasswordHasher
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure Automapper
        services.AddAutoMapper(typeof(Product).Assembly, typeof(ProductDto).Assembly);
        services.AddAutoMapper(typeof(User).Assembly, typeof(UserSignInRequest).Assembly);
        services.AddAutoMapper(typeof(User).Assembly, typeof(UserSignInResponse).Assembly);
        services.AddAutoMapper(typeof(User).Assembly, typeof(UserSignUpRequest).Assembly);
        services.AddAutoMapper(typeof(User).Assembly, typeof(UserSignUpResponse).Assembly);
    }

    public static void ConfigureJwtBearer(this IServiceCollection services, IConfiguration configuration)
    {
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
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty))
                };
            });
    }

    public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure Authorization
        services.AddAuthorizationBuilder()
            // Configure Authorization
            .AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"))
            .AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
    }

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure controllers and other services
        services.AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; });
        // Add HttpContextAccessor
        services.AddHttpContextAccessor();
        // Add Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}