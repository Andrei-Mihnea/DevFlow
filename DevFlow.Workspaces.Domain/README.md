# DevFlow.Workspaces.Domain

Contains the workspace business model: `WorkSpace`, `WorkSpaceMember`, and `WorkSpaceRole`.

Workspaces own broad team membership. User IDs are logical references to the Auth service, so this project does not reference Auth Domain or its database.
