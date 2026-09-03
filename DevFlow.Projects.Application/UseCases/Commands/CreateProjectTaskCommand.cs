using DevFlow.BuildingBlocks.Messaging;
using DevFlow.Projects.Application.DTOs;
using DevFlow.Projects.Domain.Projects;

namespace DevFlow.Projects.Application.ProjectTasks;

public sealed record CreateProjectTaskCommand(
    Guid ProjectId,
    string Title,
    string? Description,
    Guid CreatedByUserId,
    Guid? AssignedToUserId,
    DateTime? DueDate,
    ProjectTaskPriority Priority) : IRequest<ProjectTaskDto>;
