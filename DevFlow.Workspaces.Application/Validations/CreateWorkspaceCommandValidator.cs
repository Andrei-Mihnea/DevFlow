using DevFlow.BuildingBlocks.Validation;
using DevFlow.Workspaces.Application.Workspaces;

namespace DevFlow.Workspaces.Application.Validations;

public sealed class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
{
    public CreateWorkspaceCommandValidator()
    {
        RuleFor(
            request => request.Name,
            nameof(CreateWorkspaceCommand.Name),
            value => !string.IsNullOrWhiteSpace(value),
            "Workspace name is required.");

        RuleFor(
            request => request.Slug,
            nameof(CreateWorkspaceCommand.Slug),
            value => !string.IsNullOrWhiteSpace(value),
            "Workspace slug is required.");

        RuleFor(
            request => request.CreatedByUserId,
            nameof(CreateWorkspaceCommand.CreatedByUserId),
            value => value != Guid.Empty,
            "Created by user id is required.");
    }
}
