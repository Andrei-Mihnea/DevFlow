namespace DevFlow.Projects.Api.Contracts.Projects;

public sealed record CreateProjectRequest(
    Guid WorkspaceId,
    string Name,
    string Slug,
    string? Description,
    Guid CreatedByUserId);
