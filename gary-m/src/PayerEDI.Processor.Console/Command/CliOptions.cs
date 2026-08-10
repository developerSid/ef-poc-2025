using CommandLine;

namespace PayerEDI.Processor.Console.Command;

public class CliOptions
{
    [Value(0, Required = true, HelpText = "The file to parse")]
    public required string EdiFile { get; set; }
}
