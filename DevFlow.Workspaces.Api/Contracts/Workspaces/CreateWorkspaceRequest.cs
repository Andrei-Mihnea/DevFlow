namespace DevFlow.Workspaces.Api.Contracts.Workspaces;

public sealed record CreateWorkspaceRequest(
    string Name,
    string Slug,
    Guid CreatedByUserId);
