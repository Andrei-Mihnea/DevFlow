using DevFlow.Workspaces.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFlow.Workspaces.Infrastructure.Configurations;

public class WorkSpaceMemberConfig : IEntityTypeConfiguration<WorkSpaceMember>
{
    public void Configure(EntityTypeBuilder<WorkSpaceMember> builder)
    {
        builder.ToTable("WORKSPACE_MEMBERS");

        builder.HasKey(x => new
        {
            x.WorkspaceId,
            x.UserId
        });

        builder.Property(x => x.Role)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.JoinedAt)
            .IsRequired();
    }
}
