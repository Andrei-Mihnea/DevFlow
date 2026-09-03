using DevFlow.Projects.Domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFlow.Projects.Infrastructure.Configurations;

public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder)
    {
        builder.ToTable("PROJECT_MEMBERS");

        builder.HasKey(member => new
        {
            member.ProjectId,
            member.UserId
        });

        builder.Property(member => member.Role)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(member => member.JoinedAt)
            .IsRequired();

        builder.HasIndex(member => member.UserId);
    }
}
