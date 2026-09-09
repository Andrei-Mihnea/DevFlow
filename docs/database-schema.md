# Database Schema

Each microservice owns a separate Oracle database container. Foreign keys exist only within the owning service database. IDs that point to data owned by another service are logical references, not database constraints.

## Auth Database

```mermaid
erDiagram
    USERS ||--o{ REFRESH_TOKENS : owns

    USERS {
        guid Id PK
        string Email UK
        string PasswordHash
        string FirstName
        string LastName
        boolean IsActive
        string Role
        datetime CreatedAt
        datetime UpdatedAt
    }

    REFRESH_TOKENS {
        guid Id PK
        guid UserId FK
        string TokenHash UK
        datetime ExpiresAt
        datetime CreatedAt
        datetime RevokedAt
    }
```

## Workspaces Database

```mermaid
erDiagram
    WORKSPACES ||--o{ WORKSPACE_MEMBERS : contains

    WORKSPACES {
        guid Id PK
        string Name
        string Slug UK
        guid CreatedByUserId
        datetime CreatedAt
        datetime UpdatedAt
    }

    WORKSPACE_MEMBERS {
        guid WorkspaceId PK,FK
        guid UserId PK
        string Role
        datetime JoinedAt
    }
```

`CreatedByUserId` and `WorkspaceMembers.UserId` are logical references to `Auth.USERS.Id`.

## Projects Database

```mermaid
erDiagram
    PROJECTS ||--o{ PROJECT_MEMBERS : contains
    PROJECTS ||--o{ PROJECT_TASKS : contains

    PROJECTS {
        guid Id PK
        guid WorkspaceId
        string Name
        string Slug
        string Description
        string Status
        guid CreatedByUserId
        datetime CreatedAt
        datetime UpdatedAt
    }

    PROJECT_MEMBERS {
        guid ProjectId PK,FK
        guid UserId PK
        string Role
        datetime JoinedAt
    }

    PROJECT_TASKS {
        guid Id PK
        guid ProjectId FK
        string Title
        string Description
        string Status
        string Priority
        guid CreatedByUserId
        guid AssignedToUserId
        datetime DueDate
        datetime CreatedAt
        datetime UpdatedAt
    }
```

`WorkspaceId` is a logical reference to `Workspaces.WORKSPACES.Id`. `CreatedByUserId`, `ProjectMembers.UserId`, `ProjectTasks.CreatedByUserId`, and `ProjectTasks.AssignedToUserId` are logical references to `Auth.USERS.Id`. `WorkspaceId` and `Slug` have a composite unique index, so the same slug may exist in different workspaces.

## Service Ownership

```mermaid
flowchart LR
    auth[Auth database<br/>USERS, REFRESH_TOKENS]
    workspaces[Workspaces database<br/>WORKSPACES, WORKSPACE_MEMBERS]
    projects[Projects database<br/>PROJECTS, PROJECT_MEMBERS, PROJECT_TASKS]

    workspaces -. UserId logical reference .-> auth
    projects -. UserId logical reference .-> auth
    projects -. WorkspaceId logical reference .-> workspaces
```
