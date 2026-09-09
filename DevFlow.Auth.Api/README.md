# DevFlow.Auth.Api

The HTTP entry point for the Auth service. It configures dependency injection, Oracle persistence, the custom mediator pipeline, Swagger, and health checks.

Current endpoints:

- `POST /api/auth/register`
- `GET /health`

This project depends on the Auth Application and Infrastructure layers plus the Messaging, Validation, and Web building blocks. It does not contain authentication business rules.
