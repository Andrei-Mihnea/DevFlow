using DevFlow.BuildingBlocks.Validation;
using DevFlow.Projects.Application.ProjectTasks;

namespace DevFlow.Projects.Application.Validations;

public sealed class CreateProjectTaskCommandValidator : AbstractValidator<CreateProjectTaskCommand>
{
    public CreateProjectTaskCommandValidator()
    {
        RuleFor(
            request => request.ProjectId,
            nameof(CreateProjectTaskCommand.ProjectId),
            value => value != Guid.Empty,
            "Project id is required.");

        RuleFor(
            request => request.Title,
            nameof(CreateProjectTaskCommand.Title),
            value => !string.IsNullOrWhiteSpace(value),
            "Task title is required.");

        RuleFor(
            request => request.CreatedByUserId,
            nameof(CreateProjectTaskCommand.CreatedByUserId),
            value => value != Guid.Empty,
            "Created by user id is required.");
    }
}
