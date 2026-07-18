using Application.Abstractions.Messaging;

namespace Application.Messaging;

public class Mediator(IServiceProvider serviceProvider) : IMediator
{
    public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        
        // get the handler type (we use reflection here to get it)
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(
            request.GetType(),
            typeof(TResponse));

        var handler = serviceProvider.GetService(handlerType);
        var method = handlerType.GetMethod(nameof(IRequestHandler<IRequest<TResponse>, TResponse>.HandleAsync));

        if (method is null)
        {
            throw new InvalidOperationException($"Handler for {request.GetType()} is not found.");
        }
        
        return (Task<TResponse>)method.Invoke(handler, [request, cancellationToken])!;
    }
}