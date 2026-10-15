# DevFlow.Auth.Api

The HTTP entry point for the Auth service. It configures dependency injection, Oracle persistence, the custom mediator pipeline, Swagger, and health checks.

The service is packaged by [Dockerfile](Dockerfile). In the combined development Compose stack it listens on `http://localhost:8081`; Swagger is available at `/swagger` when `ASPNETCORE_ENVIRONMENT` is `Development`.

Current endpoints:

- `POST /api/auth/register`
- `GET /health`

This project depends on the Auth Application and Infrastructure layers plus the Messaging, Validation, and Web building blocks. It does not contain authentication business rules.
