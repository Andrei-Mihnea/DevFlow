using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Messaging.Behaviours;

namespace DevFlow.Workspaces.Api.Extensions;

public static class PipelineRegistration
{
    public static IServiceCollection AddPipelineBehavior(this IServiceCollection services)
        => services.AddTransient<IMediator, Mediator>()
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
}
