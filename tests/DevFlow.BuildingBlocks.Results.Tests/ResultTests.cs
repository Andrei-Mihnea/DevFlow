namespace DevFlow.BuildingBlocks.Results.Tests;

public sealed class ResultTests
{
    [Fact]
    public void Success_WhenCalled_ReturnsSuccessfulResult()
    {
        Result result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Failure_WhenCalled_ReturnsFailedResultWithGivenError()
    {
        Error error = new(
            "Users.NotFound",
            "The user was not found.",
            ErrorType.NotFound);

        Result result = Result.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Same(error, result.Error);
    }

    [Fact]
    public void SuccessOfT_WhenCalled_ExposesTheValue()
    {
        Result<string> result = Result<string>.Success("DevFlow");

        Assert.True(result.IsSuccess);
        Assert.Equal("DevFlow", result.Value);
    }

    [Fact]
    public void Value_WhenResultIsFailure_ThrowsInvalidOperationException()
    {
        Result<string> result = Result<string>.Failure(
            new Error("Test.Failure", "A test failure occurred."));

        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }
}
