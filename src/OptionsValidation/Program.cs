using FluentValidation;
using Microsoft.Extensions.Options;
using OptionsValidation;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

// You can manually register the validator as singleton can use AddValidatorsFromAssemblyContaining for the rest to register as scoped
//builder.Services.AddSingleton<IValidator<ExampleOptions>, ExampleOptionsValidator>();

builder.Services
    .AddOptions<ExampleOptions>()
    .Bind(config.GetSection(ExampleOptions.SectionName))
    //.Validate(x => x.Retries is > 0 and <= 10)
    //.ValidateDataAnnotations()
    .ValidateFluently()
    .ValidateOnStart();

var app = builder.Build();

app.MapGet("home", (IOptions<ExampleOptions> opt) => opt.Value);

app.Run();