using DevFlow.Workspaces.Application.Abstractions.Repositories;
using DevFlow.Workspaces.Application.Workspaces;
using DevFlow.Workspaces.Domain;
using DevFlow.Workspaces.Domain.Roles;

namespace DevFlow.Workspaces.Application.Tests;

public sealed class CreateWorkspaceCommandHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenSlugIsAvailable_CreatesWorkspaceAndOwnerMembership()
    {
        var repository = new FakeWorkspaceRepository();
        var handler = new CreateWorkspaceCommandHandler(repository);
        var ownerId = Guid.NewGuid();

        var result = await handler.HandleAsync(
            new CreateWorkspaceCommand("Engineering", "engineering", ownerId),
            CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.True(repository.SaveChangesCalled);

        WorkSpace workspace = Assert.Single(repository.Workspaces);
        Assert.Equal("Engineering", workspace.Name);
        Assert.Equal("engineering", workspace.Slug);
        Assert.Equal(ownerId, workspace.CreatedByUserId);

        WorkSpaceMember member = Assert.Single(workspace.Members);
        Assert.Equal(ownerId, member.UserId);
        Assert.Equal(WorkSpaceRole.Owner, member.Role);
    }

    [Fact]
    public async Task HandleAsync_WhenSlugExists_ReturnsConflictWithoutSaving()
    {
        var repository = new FakeWorkspaceRepository { SlugExists = true };
        var handler = new CreateWorkspaceCommandHandler(repository);

        var result = await handler.HandleAsync(
            new CreateWorkspaceCommand("Engineering", "engineering", Guid.NewGuid()),
            CancellationToken.None);

        Assert.True(result.IsFailure);
        Assert.Equal("Workspaces.SlugAlreadyExists", result.Error?.Code);
        Assert.False(repository.SaveChangesCalled);
        Assert.Empty(repository.Workspaces);
    }

    private sealed class FakeWorkspaceRepository : IWorkspaceRepository
    {
        public bool SlugExists { get; init; }
        public bool SaveChangesCalled { get; private set; }
        public List<WorkSpace> Workspaces { get; } = [];

        public Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken)
        {
            return Task.FromResult(SlugExists);
        }

        public void Add(WorkSpace workspace)
        {
            Workspaces.Add(workspace);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            SaveChangesCalled = true;
            return Task.CompletedTask;
        }
    }
}
