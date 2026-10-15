using DevFlow.Workspaces.Application.Validations;
using DevFlow.Workspaces.Application.Workspaces;

namespace DevFlow.Workspaces.Application.Tests;

public sealed class CreateWorkspaceCommandValidatorTests
{
    [Fact]
    public void Validate_WhenRequiredValuesAreMissing_ReturnsAllValidationFailures()
    {
        var validator = new CreateWorkspaceCommandValidator();

        var result = validator.Validate(new CreateWorkspaceCommand("", "", Guid.Empty));

        Assert.False(result.IsValid);
        Assert.Collection(
            result.Errors,
            failure => Assert.Equal("Name", failure.PropertyName),
            failure => Assert.Equal("Slug", failure.PropertyName),
            failure => Assert.Equal("CreatedByUserId", failure.PropertyName));
    }
}
