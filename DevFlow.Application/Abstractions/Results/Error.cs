using Application.Abstractions.Validations;

namespace Application.Abstractions.Results;

public sealed record Error(
    string Code, 
    string Message, 
    ErrorType Type = ErrorType.Failure);