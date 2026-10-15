# DevFlow.BuildingBlocks.Results

Provides the application-level result pattern.

`Result<T>` represents a successful value or a typed failure. `Error`, `ErrorType`, and `ValidationFailure` carry expected failures through handlers without using exceptions for normal control flow.

The behavior is covered by [unit tests](../tests/DevFlow.BuildingBlocks.Results.Tests/ResultTests.cs) for successful, failed, typed, and invalid-value-access results.
