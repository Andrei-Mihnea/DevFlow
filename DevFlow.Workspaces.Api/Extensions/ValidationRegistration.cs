using DevFlow.BuildingBlocks.Validation;
using DevFlow.Workspaces.Application.Validations;
using DevFlow.Workspaces.Application.Workspaces;

namespace DevFlow.Workspaces.Api.Extensions;

public static class ValidationRegistration
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
        => services.AddTransient<IValidator<CreateWorkspaceCommand>, CreateWorkspaceCommandValidator>();
}
