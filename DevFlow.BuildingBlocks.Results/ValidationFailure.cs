namespace DevFlow.BuildingBlocks.Results;

public sealed record ValidationFailure(string PropertyName, string ErrorMessage);
