# DevFlow.Workspaces.Api

The HTTP entry point for the Workspaces service. It currently configures controllers, the Workspaces Oracle `DbContext`, Swagger, and `/health`.

The service is packaged by [Dockerfile](Dockerfile). In the combined development Compose stack it listens on `http://localhost:8082`; Swagger is available at `/swagger` when `ASPNETCORE_ENVIRONMENT` is `Development`.

No workspace controller or application use case has been added yet. This is the place where the HTTP contract and DI registration for future workspace commands will live.
