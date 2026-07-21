using DevFlow.Auth.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFlow.Auth.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("USERS");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(256);
        
        builder.HasIndex(x => x.Email)
            .IsUnique();
        
        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(40);
        
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(40);
        
        builder.Property(x => x.IsActive)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.Role)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.HasMany(user => user.RefreshTokens)
            .WithOne()
            .HasForeignKey(x => x.UserId);
    }
}
