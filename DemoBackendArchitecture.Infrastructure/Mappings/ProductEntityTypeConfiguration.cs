using DemoBackendArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoBackendArchitecture.Infrastructure.Mappings;

public class ProductEntityTypeConfiguration :IEntityTypeConfiguration<Product>
{
    // This class will be used to configure the entity type for the Product entity
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Define constraints
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
        builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Stock).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p=> p.CreatedAt).IsRequired();
        builder.Property(p=> p.UpdatedAt).IsRequired();
    }
}