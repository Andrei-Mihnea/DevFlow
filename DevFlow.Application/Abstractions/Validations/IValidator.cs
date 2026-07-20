namespace Application.Abstractions.Validations;

public interface IValidator<in T>
{
    ValidationResult Validate(T instance);
}