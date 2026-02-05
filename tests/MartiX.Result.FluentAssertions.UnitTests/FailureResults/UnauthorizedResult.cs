using Xunit;
using static MartiX.Result.Result;
using static MartiX.Result.FluentAssertions.UnitTests.Utils.Constants;

namespace MartiX.Result.FluentAssertions.UnitTests.FailureResults;

public class UnauthorizedResult
{
    [Fact]
    public void ShouldBeFailure()
    {
        Unauthorized().ShouldBeFailure();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeFailureWithErrorMessages()
    {
        Unauthorized(ErrorMessage).ShouldBeFailure(ErrorMessage);
    }

    [Fact]
    public void WithErrorMessages_ShouldBeUnauthorized()
    {
        Unauthorized(ErrorMessage).ShouldBeUnauthorized();
    }

    [Fact]
    public void ShouldBeUnauthorized()
    {
        Unauthorized().ShouldBeUnauthorized();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeUnauthorizedWithErrorMessages()
    {
        Unauthorized(ErrorMessage).ShouldBeUnauthorized(ErrorMessage);
    }
}