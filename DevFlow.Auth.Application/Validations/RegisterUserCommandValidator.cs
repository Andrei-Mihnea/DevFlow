using DevFlow.Auth.Application.Register;
using DevFlow.BuildingBlocks.Results;
using DevFlow.BuildingBlocks.Validation;

namespace DevFlow.Auth.Application.Validations;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(
            request => request.Email,
            nameof(RegisterUserCommand.Email),
            value => !string.IsNullOrWhiteSpace(value),
            "Email is required.");

        RuleFor(
            request => request.Email,
            nameof(RegisterUserCommand.Email),
            value => value is not null && value.Contains('@'),
            "Email must be valid.");

        RuleFor(
            request => request.Password,
            nameof(RegisterUserCommand.Password),
            value => value is { Length: >= 8 },
            "Password must be at least 8 characters.");

        RuleFor(
            request => request.ReTypedPassword,
            nameof(RegisterUserCommand.ReTypedPassword),
            value => !string.IsNullOrWhiteSpace(value),
            "Password confirmation is required.");

        RuleFor(
            request => (request.ReTypedPassword, request.Password),
            nameof(RegisterUserCommand.ReTypedPassword),
            value => value.Password == value.ReTypedPassword,
            "Passwords do not match."
            );

        RuleFor(
            request => request.FirstName,
            nameof(RegisterUserCommand.FirstName),
            value => !string.IsNullOrWhiteSpace(value),
            "First name is required.");

        RuleFor(
            request => request.LastName,
            nameof(RegisterUserCommand.LastName),
            value => !string.IsNullOrWhiteSpace(value),
            "Last name is required.");
    }

    public override ValidationResult Validate(RegisterUserCommand instance)
    {
        var result = base.Validate(instance);
        var failures = result.Errors.ToList();

        if (instance.Password != instance.ReTypedPassword)
        {
            failures.Add(new ValidationFailure(
                nameof(RegisterUserCommand.ReTypedPassword),
                "Passwords do not match."));
        }

        return failures.Count == 0
            ? ValidationResult.Success
            : new ValidationResult(failures);
    }
}
