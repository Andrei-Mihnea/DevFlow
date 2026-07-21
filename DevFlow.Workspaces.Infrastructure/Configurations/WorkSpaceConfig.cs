using DevFlow.Workspaces.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFlow.Workspaces.Infrastructure.Configurations;

public class WorkSpaceConfig : IEntityTypeConfiguration<WorkSpace>
{
    public void Configure(EntityTypeBuilder<WorkSpace> builder)
    {
        builder.ToTable("WORKSPACES");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Slug)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.HasIndex(x => x.Slug)
            .IsUnique();

        builder.HasMany(x => x.Members)
            .WithOne()
            .HasForeignKey(x => x.WorkspaceId);
    }
}
