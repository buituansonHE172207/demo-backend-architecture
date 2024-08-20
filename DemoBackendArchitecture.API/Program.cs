using DemoBackendArchitecture.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//
// // Register services for Application layer
// builder.Services.AddScoped<IProductService, ProductService>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IRoleService, RoleService>();
// // Register services for Infrastructure layer
// builder.Services.AddScoped<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IRoleRepository, RoleRepository>();
// // Register PasswordHasher
// builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
// // Configure Automapper
// builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly, typeof(ProductMapping).Assembly);
// builder.Services.AddAutoMapper(typeof(UserMappingProfile).Assembly, typeof(UserMapping).Assembly);
// // Configure controllers and other services
// builder.Services.AddControllers()
//     .AddJsonOptions(options =>
//     {
//         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//     });
// //Configure JwtBearer
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidateIssuerSigningKey = true,
//             ValidIssuer = builder.Configuration["Jwt:Issuer"],
//             ValidAudience = builder.Configuration["Jwt:Audience"],
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))
//         };
//     });
// // Configure Authorization
// builder.Services.AddAuthorizationBuilder()
//     // Configure Authorization
//     .AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"))
//     .AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
//
// app.UseAuthentication();
// app.UseAuthorization();
//
// app.MapControllers();
//
// await app.RunAsync();

//Configure services
builder.Services.ConfigureServices(builder.Configuration);


var app = builder.Build();

//Configure middleware
app.ConfigureMiddleware(app.Environment);

//Run the application
await app.RunAsync();