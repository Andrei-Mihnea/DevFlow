namespace Application.Abstractions.Validations;

public sealed record ValidationFailure(string PropertyName, string ErrorMessage);