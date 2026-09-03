using DevFlow.Projects.Application.Abstractions.Repositories;
using DevFlow.Projects.Domain.Projects;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Projects.Infrastructure.Repositories;

public sealed class ProjectRepository(ProjectsDbContext dbContext) : IProjectRepository
{
    public Task<Project?> GetByIdAsync(Guid projectId, CancellationToken cancellationToken)
    {
        return dbContext.Projects
            .Include(project => project.Members)
            .Include(project => project.Tasks)
            .FirstOrDefaultAsync(project => project.Id == projectId, cancellationToken);
    }

    public Task<bool> SlugExistsInWorkspaceAsync(Guid workspaceId, string slug, CancellationToken cancellationToken)
    {
        return dbContext.Projects.AnyAsync(
            project => project.WorkspaceId == workspaceId && project.Slug == slug,
            cancellationToken);
    }

    public void Add(Project project)
    {
        dbContext.Projects.Add(project);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}
