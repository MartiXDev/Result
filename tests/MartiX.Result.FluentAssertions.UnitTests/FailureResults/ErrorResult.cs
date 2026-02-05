using Xunit;
using static MartiX.Result.Result;
using static MartiX.Result.FluentAssertions.UnitTests.Utils.Constants;

namespace MartiX.Result.FluentAssertions.UnitTests.FailureResults;

public class ErrorResult
{
    [Fact]
    public void ShouldBeFailure()
    {
        Error().ShouldBeFailure();
    }

    [Fact]
    public void WithErrorMessages_ShouldBeFailureWithErrorMessages()
    {
        Error(ErrorMessage).ShouldBeFailure(ErrorMessage);
    }

    [Fact]
    public void ShouldBeError()
    {
        Error().ShouldBeError();
    }

    [Fact]
    public void ShouldBeErrorWithErrorMessage()
    {
        Error(ErrorMessage).ShouldBeError(ErrorMessage);
    }

    [Fact]
    public void WithErrorMessages_ShouldBeError()
    {
        Error(ErrorMessage).ShouldBeError();
    }

    [Fact]
    public void ShouldBeErrorWithErrorList()
    {
        var errorList = new ErrorList([ErrorMessage], "CorrelationId");

        Error(errorList).ShouldBeError(errorList);
    }

    [Fact]
    public void ShouldBeErrorWithErrorMessagesAndCorrelationId()
    {
        var errorList = new ErrorList([ErrorMessage], "CorrelationId");

        Error(errorList).ShouldBeError([ErrorMessage], "CorrelationId");
    }
}