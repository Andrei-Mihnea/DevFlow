using DevFlow.Workspaces.Domain.Roles;

namespace DevFlow.Workspaces.Domain;

public class WorkSpaceMember
{
    public Guid WorkspaceId { get; private set; }
    public Guid UserId { get; private set; }
    public WorkSpaceRole Role { get; private set; }
    public DateTime JoinedAt { get; private set; }
    
    private WorkSpaceMember() { } // EF Core

    public WorkSpaceMember(Guid workspaceId, Guid userId, WorkSpaceRole role)
    {
        WorkspaceId = workspaceId;
        UserId = userId;
        Role = role;
        JoinedAt = DateTime.UtcNow;
    }

    public void ChangeRole(WorkSpaceRole role)
    {
        if (role == Role)
            return;

        Role = role;
    }
}
