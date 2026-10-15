# DevFlow.Workspaces.Api

The HTTP entry point for the Workspaces service. It configures controllers, the Workspaces Oracle `DbContext`, the mediator and validation pipeline, Swagger, and `/health`.

The service is packaged by [Dockerfile](Dockerfile). In the combined development Compose stack it listens on `http://localhost:8082`; Swagger is available at `/swagger` when `ASPNETCORE_ENVIRONMENT` is `Development`.

Current endpoints:

- `POST /api/workspaces`
- `GET /health`

Controllers translate HTTP requests into commands and map `Result<T>` through the shared Web building block.
