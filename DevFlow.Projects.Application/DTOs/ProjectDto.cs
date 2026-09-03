namespace DevFlow.Projects.Application.DTOs;

public sealed record ProjectDto(
    Guid ProjectId,
    Guid WorkspaceId,
    string Name,
    string Slug,
    string? Description,
    Guid CreatedByUserId,
    DateTime CreatedAt);
