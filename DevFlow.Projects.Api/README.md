# DevFlow.Projects.Api

The HTTP entry point for the Projects service. It configures the Projects database, mediator, validation pipeline, Swagger, and `/health`.

Current endpoints:

- `POST /api/projects`
- `POST /api/projects/{projectId}/tasks`

Controllers translate HTTP requests into commands and map `Result<T>` through the shared Web building block.
