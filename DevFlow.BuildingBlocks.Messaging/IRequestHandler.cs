using DevFlow.BuildingBlocks.Results;

namespace DevFlow.BuildingBlocks.Messaging;

public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
}
