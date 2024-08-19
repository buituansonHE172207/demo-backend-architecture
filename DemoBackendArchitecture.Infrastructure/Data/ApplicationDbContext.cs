using DemoBackendArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoBackendArchitecture.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    //Config database connection

    //Declare tables
    public DbSet<User> Users { get; init; }
    public DbSet<Product> Products { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}