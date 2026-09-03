namespace DevFlow.Projects.Domain.Projects;

public class Project
{
    public Guid Id { get; private set; }
    public Guid WorkspaceId { get; private set; }
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public string? Description { get; private set; }
    public ProjectStatus Status { get; private set; }
    public Guid CreatedByUserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private readonly List<ProjectMember> _members = [];
    public IReadOnlyCollection<ProjectMember> Members => _members;

    private readonly List<ProjectTask> _tasks = [];
    public IReadOnlyCollection<ProjectTask> Tasks => _tasks;

    private Project()
    {
        Name = null!;
        Slug = null!;
    } // EF Core

    public Project(Guid workspaceId, string name, string slug, string? description, Guid createdByUserId)
    {
        Id = Guid.NewGuid();
        WorkspaceId = workspaceId;
        Name = name;
        Slug = slug;
        Description = description;
        CreatedByUserId = createdByUserId;
        Status = ProjectStatus.Active;
        CreatedAt = DateTime.UtcNow;

        _members.Add(new ProjectMember(Id, createdByUserId, ProjectMemberRole.Owner));
    }

    public void AddMember(Guid userId, ProjectMemberRole role)
    {
        if (_members.Any(member => member.UserId == userId))
        {
            return;
        }

        _members.Add(new ProjectMember(Id, userId, role));
        UpdatedAt = DateTime.UtcNow;
    }

    public ProjectTask CreateTask(
        string title,
        string? description,
        Guid createdByUserId,
        Guid? assignedToUserId,
        DateTime? dueDate,
        ProjectTaskPriority priority)
    {
        var task = new ProjectTask(
            Id,
            title,
            description,
            createdByUserId,
            assignedToUserId,
            dueDate,
            priority);

        _tasks.Add(task);
        UpdatedAt = DateTime.UtcNow;

        return task;
    }

    public void Archive()
    {
        if (Status == ProjectStatus.Archived)
        {
            return;
        }

        Status = ProjectStatus.Archived;
        UpdatedAt = DateTime.UtcNow;
    }
}
