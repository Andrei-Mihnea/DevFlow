# DevFlow.BuildingBlocks.Messaging

Provides the custom mediator used by application commands.

Key pieces are `IRequest<T>`, `IRequestHandler<TRequest, TResponse>`, `IMediator`, `Mediator`, and `IPipelineBehavior<TRequest, TResponse>`. The included `ValidationBehaviour` runs registered validators before command handlers.
