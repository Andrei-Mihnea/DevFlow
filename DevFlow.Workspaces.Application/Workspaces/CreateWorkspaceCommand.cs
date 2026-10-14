using DevFlow.BuildingBlocks.Messaging;
using DevFlow.Workspaces.Application.DTOs;

namespace DevFlow.Workspaces.Application.Workspaces;

public sealed record CreateWorkspaceCommand(
    string Name,
    string Slug,
    Guid CreatedByUserId) : IRequest<WorkspaceDto>;
