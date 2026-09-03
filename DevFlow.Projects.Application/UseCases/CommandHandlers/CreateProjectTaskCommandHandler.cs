using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Results;
using DevFlow.Projects.Application.Abstractions.Repositories;
using DevFlow.Projects.Application.DTOs;

namespace DevFlow.Projects.Application.ProjectTasks;

public sealed class CreateProjectTaskCommandHandler(IProjectRepository projectRepository)
    : IRequestHandler<CreateProjectTaskCommand, ProjectTaskDto>
{
    public async Task<Result<ProjectTaskDto>> HandleAsync(
        CreateProjectTaskCommand request,
        CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetByIdAsync(request.ProjectId, cancellationToken);

        if (project is null)
        {
            return Result<ProjectTaskDto>.Failure(
                new Error(
                    "Projects.NotFound",
                    "The project was not found.",
                    ErrorType.NotFound));
        }

        var task = project.CreateTask(
            request.Title,
            request.Description,
            request.CreatedByUserId,
            request.AssignedToUserId,
            request.DueDate,
            request.Priority);

        await projectRepository.SaveChangesAsync(cancellationToken);

        return Result<ProjectTaskDto>.Success(
            new ProjectTaskDto(
                task.Id,
                task.ProjectId,
                task.Title,
                task.Description,
                task.Status,
                task.Priority,
                task.CreatedByUserId,
                task.AssignedToUserId,
                task.DueDate,
                task.CreatedAt));
    }
}
