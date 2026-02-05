using FastEndpoints;
using MartiX.Result.Sample.Core.Services;

namespace MartiX.Result.SampleWeb.PersonFeature;

public class PersonEndpoint : Endpoint<PersonDeleteRequest>
{
    private readonly PersonService _personService;

    public PersonEndpoint(PersonService personService)
    {
        _personService = personService;
    }

    public override void Configure()
    {
        Delete("/Person/Delete/{id}");
        AllowAnonymous();
    }

    /// <summary>
    /// This uses an extension method to convert to an ActionResult
    /// </summary>
    /// <returns></returns>
    public override async Task HandleAsync(PersonDeleteRequest req, CancellationToken ct)
    {
        Result result = _personService.Remove(req.Id);

        if (result.IsSuccess)
        {
            await SendNoContentAsync(ct);
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

public class PersonDeleteRequest
{
    public int Id { get; set; }
}
