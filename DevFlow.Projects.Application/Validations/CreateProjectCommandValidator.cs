using DevFlow.BuildingBlocks.Validation;
using DevFlow.Projects.Application.Projects;

namespace DevFlow.Projects.Application.Validations;

public sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(
            request => request.WorkspaceId,
            nameof(CreateProjectCommand.WorkspaceId),
            value => value != Guid.Empty,
            "Workspace id is required.");

        RuleFor(
            request => request.Name,
            nameof(CreateProjectCommand.Name),
            value => !string.IsNullOrWhiteSpace(value),
            "Project name is required.");

        RuleFor(
            request => request.Slug,
            nameof(CreateProjectCommand.Slug),
            value => !string.IsNullOrWhiteSpace(value),
            "Project slug is required.");

        RuleFor(
            request => request.CreatedByUserId,
            nameof(CreateProjectCommand.CreatedByUserId),
            value => value != Guid.Empty,
            "Created by user id is required.");
    }
}
