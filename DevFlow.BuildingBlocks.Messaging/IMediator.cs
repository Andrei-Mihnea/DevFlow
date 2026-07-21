using DevFlow.BuildingBlocks.Results;

namespace DevFlow.BuildingBlocks.Messaging;

public interface IMediator
{
    Task<Result<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}
