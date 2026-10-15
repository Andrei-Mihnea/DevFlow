using DevFlow.Workspaces.Domain;

namespace DevFlow.Workspaces.Application.Abstractions.Repositories;

public interface IWorkspaceRepository
{
    Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken);
    void Add(WorkSpace workspace);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
