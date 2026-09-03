using DevFlow.Projects.Domain.Projects;

namespace DevFlow.Projects.Application.Abstractions.Repositories;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid projectId, CancellationToken cancellationToken);
    Task<bool> SlugExistsInWorkspaceAsync(Guid workspaceId, string slug, CancellationToken cancellationToken);
    void Add(Project project);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
