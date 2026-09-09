using DevFlow.Workspaces.Domain.Roles;

namespace DevFlow.Workspaces.Domain;

public class WorkSpace
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public Guid CreatedByUserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private readonly List<WorkSpaceMember> _members = [];
    public IReadOnlyCollection<WorkSpaceMember> Members => _members;

    private WorkSpace()
    {
        Name = null!;
        Slug = null!;
    } //EF Core

    public WorkSpace(string name, string slug, Guid createdByUserId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Slug = slug;
        CreatedByUserId = createdByUserId;
        CreatedAt = DateTime.UtcNow;

        _members.Add(new WorkSpaceMember(Id, createdByUserId, WorkSpaceRole.Owner));
    }
}
