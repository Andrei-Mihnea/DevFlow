using DevFlow.BuildingBlocks.Results;

namespace DevFlow.BuildingBlocks.Messaging;

public interface IPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<Result<TResponse>> HandleAsync(
        TRequest request,
        Func<Task<Result<TResponse>>> next,
        CancellationToken cancellationToken);
}
