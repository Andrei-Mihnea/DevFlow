using System.Diagnostics.CodeAnalysis;

namespace DevFlow.BuildingBlocks.Results;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; }

    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(Error error) => new(false, error);
}

[SuppressMessage(
    "Design",
    "CA1000:Do not declare static members on generic types",
    Justification = "Typed Success, Failure, and ValidationFailure factories are the intentional public Result API.")]
public class Result<T>
{
    private readonly T? _value;
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; }
    public IReadOnlyList<ValidationFailure> ValidationFailures { get; }

    public T Value =>
        IsSuccess ? _value! : throw new InvalidOperationException("Cannot access value of an failed result");

    protected Result(T? value)
    {
        IsSuccess = true;
        _value = value;
        Error = null;
        ValidationFailures = [];
    }

    protected Result(Error error, IReadOnlyList<ValidationFailure>? validationFailures = null)
    {
        IsSuccess = false;
        Error = error;
        ValidationFailures = validationFailures ?? [];
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(Error error) => new(error);
    public static Result<T> ValidationFailure(IReadOnlyList<ValidationFailure> validationFailures) =>
        new(
            new Error(
                "Validation.Failed",
                "One or more validation errors occurred.",
                ErrorType.Validation),
            validationFailures);
}
