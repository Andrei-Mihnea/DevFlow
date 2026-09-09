# DevFlow.Projects.Application

Contains project and task use cases. Current commands are `CreateProjectCommand` and `CreateProjectTaskCommand`, each with a handler and validator.

Persistence is defined through `IProjectRepository`. The project depends on Projects Domain plus Messaging, Results, and Validation building blocks, never on EF Core or Oracle.
