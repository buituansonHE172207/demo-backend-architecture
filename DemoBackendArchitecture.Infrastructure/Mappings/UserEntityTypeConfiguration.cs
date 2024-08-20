using DemoBackendArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoBackendArchitecture.Infrastructure.Mappings;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).UseIdentityColumn();
        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired();
        // Define the relationship between the User and Role entities
        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
        // Mapped foreign key RoleId to the Role entity
        builder.HasIndex(u => u.RoleId);
        // Mapped the User entity to the Users table
        builder.ToTable("Users");
    }
}