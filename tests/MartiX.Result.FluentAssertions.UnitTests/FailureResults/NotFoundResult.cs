using Xunit;
using static MartiX.Result.Result;
using static MartiX.Result.FluentAssertions.UnitTests.Utils.Constants;

namespace MartiX.Result.FluentAssertions.UnitTests.FailureResults;

public class NotFoundResult
{
    [Fact]
    public void ShouldBeFailure()
    {
        NotFound().ShouldBeFailure();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeFailureWithErrorMessages()
    {
        NotFound(ErrorMessage).ShouldBeFailure(ErrorMessage);
    }

    [Fact]
    public void ShouldBeNotFound()
    {
        NotFound().ShouldBeNotFound();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeNotFound()
    {
        NotFound(ErrorMessage).ShouldBeNotFound();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeNotFoundWithErrorMessages()
    {
        NotFound(ErrorMessage).ShouldBeNotFound(ErrorMessage);
    }
}