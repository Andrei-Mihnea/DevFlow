namespace DevFlow.Workspaces.Application.DTOs;

public sealed record WorkspaceDto(
    Guid WorkspaceId,
    string Name,
    string Slug,
    Guid CreatedByUserId,
    DateTime CreatedAt);
