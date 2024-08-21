using DemoBackendArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoBackendArchitecture.Infrastructure.Mappings;

public class RefreshTokenEntityTypeConfiguration :IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.Id);
        // Mapped the ID property to the primary key column
        builder.Property(rt => rt.Id).UseIdentityColumn();
        builder.Property(rt => rt.Token).IsRequired();
        builder.Property(rt => rt.ExpiryTime).IsRequired();
        // Define the relationship between the RefreshToken and User entities
        builder.HasOne(rt => rt.User)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(rt => rt.UserId);
        // Mapped the RefreshToken entity to the RefreshTokens table
        builder.ToTable("RefreshTokens");
    }
}