using DevFlow.BuildingBlocks.Results;

namespace DevFlow.BuildingBlocks.Messaging;

public class Mediator(IServiceProvider serviceProvider) : IMediator
{
    public Task<Result<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(
            request.GetType(),
            typeof(TResponse));

        var handler = serviceProvider.GetService(handlerType) ?? throw new InvalidOperationException($"Handler for {request.GetType().Name} is not registered.");

        var method = handlerType.GetMethod(nameof(IRequestHandler<,>.HandleAsync)) ?? throw new InvalidOperationException($"Handler for {request.GetType().Name} is invalid.");
        Func<Task<Result<TResponse>>> pipeline = () =>
            (Task<Result<TResponse>>)method.Invoke(handler, [request, cancellationToken])!;

        var behaviorType = typeof(IPipelineBehavior<,>).MakeGenericType(
            request.GetType(),
            typeof(TResponse));

        var behaviors = GetServices(behaviorType);

        foreach (var behavior in behaviors.Reverse())
        {
            var next = pipeline;
            var behaviorMethod = behaviorType.GetMethod(nameof(IPipelineBehavior<,>.HandleAsync)) ?? throw new InvalidOperationException($"Behavior {behavior.GetType().Name} is invalid.");
            pipeline = () =>
                (Task<Result<TResponse>>)behaviorMethod.Invoke(behavior, [request, next, cancellationToken])!;
        }

        return pipeline();
    }

    private IEnumerable<object> GetServices(Type serviceType)
    {
        var enumerableType = typeof(IEnumerable<>).MakeGenericType(serviceType);
        var services = serviceProvider.GetService(enumerableType);

        return services is null
            ? []
            : ((IEnumerable<object>)services);
    }
}
