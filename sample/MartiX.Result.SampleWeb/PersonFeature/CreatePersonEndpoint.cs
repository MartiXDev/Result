using FastEndpoints;
using MartiX.Result.Sample.Core.Services;
using MartiX.Result.Sample.Core.DTOs;
using MartiX.Result.Sample.Core.Model;

namespace MartiX.Result.SampleWeb.PersonFeature;

public class CreatePersonEndpoint : Endpoint<CreatePersonRequestDto, Person>
{
    private readonly PersonService _personService;

    public CreatePersonEndpoint(PersonService personService)
    {
        _personService = personService;
    }

    public override void Configure()
    {
        Post("/Person/Create/");
        AllowAnonymous();
    }

    /// <summary>
    /// This uses an extension method to convert to an ActionResult
    /// </summary>
    /// <returns></returns>
    public override async Task HandleAsync(CreatePersonRequestDto req, CancellationToken ct)
    {
        Result<Person> result = _personService.Create(req.FirstName, req.LastName);

        if (result.IsSuccess)
        {
            await SendCreatedAtAsync<CreatePersonEndpoint>(null, result.Value, cancellation: ct);
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
