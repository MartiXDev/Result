using FastEndpoints;
using MartiX.Result.Sample.Core.DTOs;
using MartiX.Result.Sample.Core.Model;
using MartiX.Result.Sample.Core.Services;

namespace MartiX.Result.SampleWeb.WeatherForecastFeature;

public class ForecastEndpoint : Endpoint<ForecastRequestDto, IEnumerable<WeatherForecast>>
{
    private readonly WeatherService _weatherService;

    public ForecastEndpoint(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public override void Configure()
    {
        Post("/Forecast/New");
        AllowAnonymous();
    }

    /// <summary>
    /// This uses an extension method to convert to an ActionResult
    /// </summary>
    /// <param name="req"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public override async Task HandleAsync(ForecastRequestDto req, CancellationToken ct)
    {
        Result<IEnumerable<WeatherForecast>> result = _weatherService.GetForecast(req);

        if (result.IsSuccess)
        {
            await SendAsync(result.Value, cancellation: ct);
        }
        else
        {
            // Map result status to HTTP status code
            var statusCode = result.Status switch
            {
                ResultStatus.NotFound => 404,
                ResultStatus.Invalid => 400,
                ResultStatus.Error => 500,
                ResultStatus.Forbidden => 403,
                ResultStatus.Unauthorized => 401,
                ResultStatus.Unavailable => 503,
                _ => 400
            };

            foreach (var error in result.Errors)
            {
                AddError(error);
            }

            await SendErrorsAsync(statusCode, ct);
        }
    }
}
