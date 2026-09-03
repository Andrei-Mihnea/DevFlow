using DevFlow.Projects.Domain.Projects;

namespace DevFlow.Projects.Application.DTOs;

public sealed record ProjectTaskDto(
    Guid TaskId,
    Guid ProjectId,
    string Title,
    string? Description,
    ProjectTaskStatus Status,
    ProjectTaskPriority Priority,
    Guid CreatedByUserId,
    Guid? AssignedToUserId,
    DateTime? DueDate,
    DateTime CreatedAt);
