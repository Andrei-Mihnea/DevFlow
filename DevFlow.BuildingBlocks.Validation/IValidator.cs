namespace DevFlow.BuildingBlocks.Validation;

public interface IValidator<in T>
{
    ValidationResult Validate(T instance);
}
