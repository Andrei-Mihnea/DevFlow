using DevFlow.Projects.Domain.Projects;

namespace DevFlow.Projects.Api.Contracts.ProjectTasks;

public sealed record CreateProjectTaskRequest(
    string Title,
    string? Description,
    Guid CreatedByUserId,
    Guid? AssignedToUserId,
    DateTime? DueDate,
    ProjectTaskPriority Priority);
