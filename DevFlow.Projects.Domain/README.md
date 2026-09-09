# DevFlow.Projects.Domain

Contains the Projects business model: `Project`, `ProjectMember`, `ProjectTask`, and their status, priority, and role enums.

`WorkspaceId` and user IDs are logical references to other services. The domain deliberately has no direct relationship or foreign key to Auth or Workspaces databases.
