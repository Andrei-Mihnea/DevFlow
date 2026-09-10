using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Results;
using DevFlow.Projects.Application.Abstractions.Repositories;
using DevFlow.Projects.Application.DTOs;
using DevFlow.Projects.Domain.Projects;

namespace DevFlow.Projects.Application.Projects;

public sealed class CreateProjectCommandHandler(IProjectRepository projectRepository)
    : IRequestHandler<CreateProjectCommand, ProjectDto>
{
    public async Task<Result<ProjectDto>> HandleAsync(
        CreateProjectCommand request,
        CancellationToken cancellationToken)
    {
        var slugExists = await projectRepository.SlugExistsInWorkspaceAsync(
            request.WorkspaceId,
            request.Slug,
            cancellationToken);

        if (slugExists)
        {
            return Result<ProjectDto>.Failure(
                new Error(
                    "Projects.SlugAlreadyExists",
                    "A project with this slug already exists in this workspace.",
                    ErrorType.Conflict));
        }

        var project = new Project(
            request.WorkspaceId,
            request.Name,
            request.Slug,
            request.Description,
            request.CreatedByUserId);

        projectRepository.Add(project);
        await projectRepository.SaveChangesAsync(cancellationToken);

        return Result<ProjectDto>.Success(
            new ProjectDto(
                project.Id,
                project.WorkspaceId,
                project.Name,
                project.Slug,
                project.Description,
                project.CreatedByUserId,
                project.CreatedAt));
    }
}
