using System.Diagnostics.CodeAnalysis;

namespace DevFlow.BuildingBlocks.Results;

[SuppressMessage(
    "Naming",
    "CA1716:Identifiers should not match keywords",
    Justification = "Error is the established domain-result vocabulary exposed by this application API.")]
public sealed record Error(
    string Code,
    string Message,
    ErrorType Type = ErrorType.Failure);
