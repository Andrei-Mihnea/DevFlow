using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Results;
using DevFlow.Workspaces.Application.Abstractions.Repositories;
using DevFlow.Workspaces.Application.DTOs;
using DevFlow.Workspaces.Domain;

namespace DevFlow.Workspaces.Application.Workspaces;

public sealed class CreateWorkspaceCommandHandler(IWorkspaceRepository workspaceRepository)
    : IRequestHandler<CreateWorkspaceCommand, WorkspaceDto>
{
    public async Task<Result<WorkspaceDto>> HandleAsync(
        CreateWorkspaceCommand request,
        CancellationToken cancellationToken)
    {
        var slugExists = await workspaceRepository.SlugExistsAsync(request.Slug, cancellationToken);

        if (slugExists)
        {
            return Result<WorkspaceDto>.Failure(
                new Error(
                    "Workspaces.SlugAlreadyExists",
                    "A workspace with this slug already exists.",
                    ErrorType.Conflict));
        }

        var workspace = new WorkSpace(
            request.Name,
            request.Slug,
            request.CreatedByUserId);

        workspaceRepository.Add(workspace);
        await workspaceRepository.SaveChangesAsync(cancellationToken);

        return Result<WorkspaceDto>.Success(
            new WorkspaceDto(
                workspace.Id,
                workspace.Name,
                workspace.Slug,
                workspace.CreatedByUserId,
                workspace.CreatedAt));
    }
}
