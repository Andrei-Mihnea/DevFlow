namespace DevFlow.Projects.Domain.Projects;

public class ProjectMember
{
    public Guid ProjectId { get; private set; }
    public Guid UserId { get; private set; }
    public ProjectMemberRole Role { get; private set; }
    public DateTime JoinedAt { get; private set; }

    private ProjectMember()
    {
    } // EF Core

    public ProjectMember(Guid projectId, Guid userId, ProjectMemberRole role)
    {
        ProjectId = projectId;
        UserId = userId;
        Role = role;
        JoinedAt = DateTime.UtcNow;
    }

    public void ChangeRole(ProjectMemberRole role)
    {
        if (Role == role)
        {
            return;
        }

        Role = role;
    }
}
