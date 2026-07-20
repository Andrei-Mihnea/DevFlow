using Application.Abstractions.Messaging;
using Application.Abstractions.Results;
using Application.Abstractions.Validations;

namespace Application.Abstractions.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<Result<TResponse>> HandleAsync(
        TRequest request,
        Func<Task<Result<TResponse>>> next,
        CancellationToken cancellationToken)
    {
        var failures = validators
            .SelectMany(validator => validator.Validate(request).Errors)
            .ToList();

        return failures.Count > 0
            ? Task.FromResult(Result<TResponse>.ValidationFailure(failures))
            : next();
    }
}
