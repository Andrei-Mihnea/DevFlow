using DevFlow.BuildingBlocks.Results;
using DevFlow.BuildingBlocks.Validation;

namespace DevFlow.BuildingBlocks.Messaging.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<Result<TResponse>> HandleAsync(
        TRequest request,
        Func<Task<Result<TResponse>>> nextHandler,
        CancellationToken cancellationToken)
    {
        var failures = validators
            .SelectMany(validator => validator.Validate(request).Errors)
            .ToList();

        return failures.Count > 0
            ? Task.FromResult(Result<TResponse>.ValidationFailure(failures))
            : nextHandler();
    }
}
