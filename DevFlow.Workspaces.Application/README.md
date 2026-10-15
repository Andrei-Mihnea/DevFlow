# DevFlow.Workspaces.Application

Contains workspace use cases, handlers, DTOs, repository abstractions, and validation.

Current use case:

- `CreateWorkspaceCommand` creates a workspace and its owner's membership after ensuring the slug is unique.

The next use case can be membership management, beginning with `AddWorkspaceMemberCommand`.
