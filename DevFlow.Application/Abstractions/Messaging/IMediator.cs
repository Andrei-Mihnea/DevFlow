using Application.Abstractions.Results;

namespace Application.Abstractions.Messaging;

public interface IMediator
{
    Task<Result<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}
