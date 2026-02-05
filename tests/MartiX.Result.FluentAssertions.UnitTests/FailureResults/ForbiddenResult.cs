using Xunit;
using static MartiX.Result.Result;
using static MartiX.Result.FluentAssertions.UnitTests.Utils.Constants;

namespace MartiX.Result.FluentAssertions.UnitTests.FailureResults;

public class ForbiddenResult
{
    [Fact]
    public void ShouldBeFailure()
    {
        Forbidden().ShouldBeFailure();
    }

    [Fact]
    public void ShouldBeFailureWithMessage()
    {
        Forbidden(ErrorMessage).ShouldBeFailure(ErrorMessage);
    }

    [Fact]
    public void ShouldBeForbidden()
    {
        Forbidden().ShouldBeForbidden();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeForbidden()
    {
        Forbidden(ErrorMessage).ShouldBeForbidden();
    }

    [Fact]
    public void ShouldBeForbiddenWithMessage()
    {
        Forbidden(ErrorMessage).ShouldBeForbidden(ErrorMessage);
    }
}