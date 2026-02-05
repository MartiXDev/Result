using System.Linq;
using MartiX.Result.Sample.Core.Services;
using FluentAssertions;
using Xunit;

namespace MartiX.Result.Sample.UnitTests.ServiceTests;

public class BadResultService_ReturnResultWithError
{
    [Fact]
    public void ReturnsErrorResultGivenMessage()
    {
        var service = new BadResultService();

        var result = service.ReturnErrorWithMessage("Some error message");

        result.Status.Should().Be(ResultStatus.Error);
        result.Errors.Single().Should().Be("Some error message");
    }
}
