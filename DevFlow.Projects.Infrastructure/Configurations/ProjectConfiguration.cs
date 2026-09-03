using DevFlow.Projects.Domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFlow.Projects.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("PROJECTS");

        builder.HasKey(project => project.Id);

        builder.Property(project => project.WorkspaceId)
            .IsRequired();

        builder.Property(project => project.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(project => project.Slug)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(project => project.Description)
            .HasMaxLength(1000);

        builder.Property(project => project.Status)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(project => project.CreatedByUserId)
            .IsRequired();

        builder.Property(project => project.CreatedAt)
            .IsRequired();

        builder.HasIndex(project => new
            {
                project.WorkspaceId,
                project.Slug
            })
            .IsUnique();

        builder.HasMany(project => project.Members)
            .WithOne()
            .HasForeignKey(member => member.ProjectId);

        builder.HasMany(project => project.Tasks)
            .WithOne()
            .HasForeignKey(task => task.ProjectId);
    }
}
