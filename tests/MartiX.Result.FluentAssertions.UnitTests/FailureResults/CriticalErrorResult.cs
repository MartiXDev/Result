using Xunit;
using static MartiX.Result.Result;
using static MartiX.Result.FluentAssertions.UnitTests.Utils.Constants;

namespace MartiX.Result.FluentAssertions.UnitTests.FailureResults;

public class CriticalErrorResult
{
    [Fact]
    public void ShouldBeFailure()
    {
        CriticalError().ShouldBeFailure();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeFailureWithErrorMessages()
    {
        CriticalError(ErrorMessage).ShouldBeFailure(ErrorMessage);
    }

    [Fact]
    public void ShouldBeCriticalError()
    {
        CriticalError().ShouldBeCriticalError();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeCriticalError()
    {
        CriticalError(ErrorMessage).ShouldBeCriticalError();
    }

    [Fact]
    public void ShouldBeCriticalErrorWithErrorMessages()
    {
        CriticalError(ErrorMessage).ShouldBeCriticalError(ErrorMessage);
    }
}