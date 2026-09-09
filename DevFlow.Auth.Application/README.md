# DevFlow.Auth.Application

Contains Auth use cases and their orchestration. The current use case is `RegisterUserCommand`, handled through the custom mediator and checked by `RegisterUserCommandValidator`.

It depends on Auth Domain and shared Messaging, Results, and Validation building blocks. Persistence is accessed through `IUserRepository`; the concrete EF Core implementation belongs in Infrastructure.
