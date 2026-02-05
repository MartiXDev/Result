using Xunit;
using static MartiX.Result.Result;
using static MartiX.Result.FluentAssertions.UnitTests.Utils.Constants;

namespace MartiX.Result.FluentAssertions.UnitTests.FailureResults;

public class UnavailableResult
{
    [Fact]
    public void ShouldBeFailure()
    {
        Unavailable().ShouldBeFailure();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeFailureWithErrorMessages()
    {
        Unavailable(ErrorMessage).ShouldBeFailure(ErrorMessage);
    }

    [Fact]
    public void ShouldBeUnavailable()
    {
        Unavailable().ShouldBeUnavailable();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeUnavailableWithErrorMessages()
    {
        Unavailable(ErrorMessage).ShouldBeUnavailable(ErrorMessage);
    }

    [Fact]
    public void WithErrorMessages_ShouldBeUnavailable()
    {
        Unavailable(ErrorMessage).ShouldBeUnavailable();
    }
}