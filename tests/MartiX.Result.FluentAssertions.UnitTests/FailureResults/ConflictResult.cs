using Xunit;
using static MartiX.Result.Result;
using static MartiX.Result.FluentAssertions.UnitTests.Utils.Constants;

namespace MartiX.Result.FluentAssertions.UnitTests.FailureResults;

public class ConflictResult
{
    [Fact]
    public void ShouldBeFailure()
    {
        Conflict().ShouldBeFailure();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeFailureWithErrorMessages()
    {
        Conflict(ErrorMessage).ShouldBeFailure(ErrorMessage);
    }

    [Fact]
    public void ShouldBeConflict()
    {
        Conflict().ShouldBeConflict();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeConflict()
    {
        Conflict(ErrorMessage).ShouldBeConflict();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeConflictWithErrorMessages()
    {
        Conflict(ErrorMessage).ShouldBeConflict(ErrorMessage);
    }
}