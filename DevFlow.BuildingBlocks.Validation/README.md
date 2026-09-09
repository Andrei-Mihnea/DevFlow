# DevFlow.BuildingBlocks.Validation

Provides the custom validation abstraction used by the mediator pipeline.

Create validators by deriving from `AbstractValidator<T>`. The validator returns a `ValidationResult`, which the Messaging validation behavior converts to a failed `Result<T>`.
