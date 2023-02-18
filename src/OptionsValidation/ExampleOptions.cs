namespace OptionsValidation;

public class ExampleOptions
{
    public const string SectionName = "Example";

    public required string LogLevel { get; init; }
    
    public required int Retries { get; init; }
}