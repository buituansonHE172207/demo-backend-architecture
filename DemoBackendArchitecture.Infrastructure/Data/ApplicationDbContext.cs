using DemoBackendArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoBackendArchitecture.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    //Config database connection
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    
    //Declare tables
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}