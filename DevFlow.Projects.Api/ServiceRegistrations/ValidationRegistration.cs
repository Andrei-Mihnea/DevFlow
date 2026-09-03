using DevFlow.BuildingBlocks.Validation;
using DevFlow.Projects.Application.Projects;
using DevFlow.Projects.Application.ProjectTasks;
using DevFlow.Projects.Application.Validations;

namespace DevFlow.Projects.Api.ServiceRegistrations;

public static class ValidationRegistration
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
        => services
            .AddTransient<IValidator<CreateProjectCommand>, CreateProjectCommandValidator>()
            .AddTransient<IValidator<CreateProjectTaskCommand>, CreateProjectTaskCommandValidator>();
}
