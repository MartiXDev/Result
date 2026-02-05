using FastEndpoints;
using FastEndpoints.Swagger;
using MartiX.Result;
using MartiX.Result.AspNetCore;
using MartiX.Result.Sample.Core.Services;
using MartiX.Result.SampleWeb.MediatrApi;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var webAssembly = typeof(Program).Assembly;
builder.Services.AddMediatR(webAssembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

// Add FastEndpoints
builder.Services.AddFastEndpoints();

// Keep Controllers for backward compatibility with existing controllers
builder.Services.AddControllers(mvcOptions => mvcOptions
    .AddResultConvention(resultStatusMap => resultStatusMap
        .AddDefaultMap()
        .For(ResultStatus.Ok, HttpStatusCode.OK, resultStatusOptions => resultStatusOptions
            .For("POST", HttpStatusCode.Created)
            .For("DELETE", HttpStatusCode.NoContent))
        .Remove(ResultStatus.Forbidden)
        .Remove(ResultStatus.Unauthorized)
    ));

builder.Services.AddRazorPages();
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
        };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Configure Swagger with FastEndpoints support
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "My API V1";
        s.Version = "v1";
    };
});

builder.Services.AddTransient<PersonService>();
builder.Services.AddTransient<WeatherService>();
builder.Services.AddTransient<WeatherServiceWithExceptions>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

// Add FastEndpoints middleware
app.UseFastEndpoints();

// Configure Swagger UI
app.UseSwaggerGen();

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options!.Value);

app.MapControllers();
app.MapRazorPages();

app.Run();