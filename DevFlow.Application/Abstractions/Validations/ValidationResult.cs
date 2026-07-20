using Application.Abstractions.Results;

namespace Application.Abstractions.Validations;

public class ValidationResult(IReadOnlyList<ValidationFailure> errors)
{
    public IReadOnlyList<ValidationFailure> Errors { get; } = errors;
    public bool IsValid => Errors.Count == 0;
    public static ValidationResult Success => new([]);
}