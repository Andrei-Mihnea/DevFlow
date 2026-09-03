using DevFlow.BuildingBlocks.Messaging;
using DevFlow.Projects.Application.DTOs;
using DevFlow.Projects.Application.Projects;
using DevFlow.Projects.Application.ProjectTasks;

namespace DevFlow.Projects.Api.ServiceRegistrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddMediatorServices(this IServiceCollection services)
        => services
            .AddTransient<IRequestHandler<CreateProjectCommand, ProjectDto>, CreateProjectCommandHandler>()
            .AddTransient<IRequestHandler<CreateProjectTaskCommand, ProjectTaskDto>, CreateProjectTaskCommandHandler>();
}
