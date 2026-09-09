# DevFlow.Workspaces.Api

The HTTP entry point for the Workspaces service. It currently configures controllers, the Workspaces Oracle `DbContext`, Swagger, and `/health`.

No workspace controller or application use case has been added yet. This is the place where the HTTP contract and DI registration for future workspace commands will live.
