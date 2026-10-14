using DevFlow.Workspaces.Application.Abstractions.Repositories;
using DevFlow.Workspaces.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Workspaces.Infrastructure.Repositories;

public sealed class WorkspaceRepository(WorkspacesDbContext dbContext) : IWorkspaceRepository
{
    public Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken)
    {
        return dbContext.WorkSpaces.AnyAsync(workspace => workspace.Slug == slug, cancellationToken);
    }

    public void Add(WorkSpace workspace)
    {
        dbContext.WorkSpaces.Add(workspace);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}
