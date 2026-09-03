namespace DevFlow.Projects.Domain.Projects;

public class ProjectTask
{
    public Guid Id { get; private set; }
    public Guid ProjectId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public ProjectTaskStatus Status { get; private set; }
    public ProjectTaskPriority Priority { get; private set; }
    public Guid CreatedByUserId { get; private set; }
    public Guid? AssignedToUserId { get; private set; }
    public DateTime? DueDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private ProjectTask()
    {
        Title = null!;
    } // EF Core

    public ProjectTask(
        Guid projectId,
        string title,
        string? description,
        Guid createdByUserId,
        Guid? assignedToUserId,
        DateTime? dueDate,
        ProjectTaskPriority priority = ProjectTaskPriority.Medium)
    {
        Id = Guid.NewGuid();
        ProjectId = projectId;
        Title = title;
        Description = description;
        CreatedByUserId = createdByUserId;
        AssignedToUserId = assignedToUserId;
        DueDate = dueDate;
        Priority = priority;
        Status = ProjectTaskStatus.ToDo;
        CreatedAt = DateTime.UtcNow;
    }

    public void AssignTo(Guid userId)
    {
        AssignedToUserId = userId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Unassign()
    {
        AssignedToUserId = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeStatus(ProjectTaskStatus status)
    {
        if (Status == status)
        {
            return;
        }

        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }
}
