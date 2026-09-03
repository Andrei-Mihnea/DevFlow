using DevFlow.BuildingBlocks.Messaging;
using DevFlow.Projects.Application.DTOs;

namespace DevFlow.Projects.Application.Projects;

public sealed record CreateProjectCommand(
    Guid WorkspaceId,
    string Name,
    string Slug,
    string? Description,
    Guid CreatedByUserId) : IRequest<ProjectDto>;
