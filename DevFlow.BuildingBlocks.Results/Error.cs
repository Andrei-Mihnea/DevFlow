namespace DevFlow.BuildingBlocks.Results;

public sealed record Error(
    string Code, 
    string Message, 
    ErrorType Type = ErrorType.Failure);
