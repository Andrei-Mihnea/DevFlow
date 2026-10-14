# DevFlow.Projects.Api

The HTTP entry point for the Projects service. It configures the Projects database, mediator, validation pipeline, Swagger, and `/health`.

The service is packaged by [Dockerfile](Dockerfile). In the combined development Compose stack it listens on `http://localhost:8083`; Swagger is available at `/swagger` when `ASPNETCORE_ENVIRONMENT` is `Development`.

Current endpoints:

- `POST /api/projects`
- `POST /api/projects/{projectId}/tasks`

Controllers translate HTTP requests into commands and map `Result<T>` through the shared Web building block.
