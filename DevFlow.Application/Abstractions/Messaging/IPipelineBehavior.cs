using Application.Abstractions.Results;

namespace Application.Abstractions.Messaging;

public interface IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<Result<TResponse>> HandleAsync(
        TRequest request,
        Func<Task<Result<TResponse>>> next,
        CancellationToken cancellationToken);
}
