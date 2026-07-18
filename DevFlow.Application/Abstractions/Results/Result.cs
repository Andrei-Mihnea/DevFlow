namespace Application.Abstractions.Results;

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

public class Result<T>
{
    private readonly T? _value;
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; }

    public T Value =>
        IsSuccess ? _value! : throw new InvalidOperationException("Cannot access value of an failed result");

    protected Result(T? value)
    {
        IsSuccess = true;
        _value = value;
        Error = null;
    }

    protected Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(Error error) => new(error);
}