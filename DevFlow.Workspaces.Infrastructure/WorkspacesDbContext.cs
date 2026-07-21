using DevFlow.Workspaces.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Workspaces.Infrastructure;

public class WorkspacesDbContext(DbContextOptions<WorkspacesDbContext> options) : DbContext(options)
{
    public DbSet<WorkSpace> WorkSpaces => Set<WorkSpace>();
    public DbSet<WorkSpaceMember> WorkSpaceMembers => Set<WorkSpaceMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkspacesDbContext).Assembly);
    }
}
