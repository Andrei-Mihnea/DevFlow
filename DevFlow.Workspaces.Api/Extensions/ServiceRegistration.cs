using DevFlow.BuildingBlocks.Messaging;
using DevFlow.Workspaces.Application.DTOs;
using DevFlow.Workspaces.Application.Workspaces;

namespace DevFlow.Workspaces.Api.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddMediatorServices(this IServiceCollection services)
        => services.AddTransient<IRequestHandler<CreateWorkspaceCommand, WorkspaceDto>, CreateWorkspaceCommandHandler>();
}
