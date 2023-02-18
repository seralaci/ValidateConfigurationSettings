using Microsoft.Extensions.Options;
using OptionsValidation;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services
    .AddOptions<ExampleOptions>()
    .Bind(config.GetSection(ExampleOptions.SectionName))
    .Validate(x => x.Retries is > 0 and <= 10)
    .ValidateOnStart();

var app = builder.Build();

app.MapGet("home", (IOptions<ExampleOptions> opt) => opt.Value);

app.Run();