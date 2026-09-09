using DevFlow.BuildingBlocks.Results;

namespace DevFlow.BuildingBlocks.Validation;

public abstract class AbstractValidator<T> : IValidator<T>
{
    private readonly List<Func<T, ValidationFailure?>> _rules = [];

    public void RuleFor<TProperty>(
        Func<T, TProperty?> propertySelector,
        string propertyName,
        Func<TProperty?, bool> predicate,
        string errorMessage
    )
    {
        _rules.Add(instance =>
            {
                var value = propertySelector(instance);

                return predicate(value) ? null : new ValidationFailure(propertyName, errorMessage);
            }
            );
    }

    public virtual ValidationResult Validate(T instance)
    {
        var errors = _rules
            .Select(rule => rule(instance))
            .Where(error => error is not null)
            .Cast<ValidationFailure>()
            .ToList();

        return errors.Count == 0 ?
            ValidationResult.Success :
            new ValidationResult(errors);
    }
}
