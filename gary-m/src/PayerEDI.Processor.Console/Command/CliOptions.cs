using CommandLine;

namespace PayerEDI.Processor.Console.Command;

public class CliOptions
{
    [Value(0, Required = true, HelpText = "The file to parse")]
    public required string EdiFile { get; set; }

    [Option(
        "save",
        Required = false,
        Default = false,
        HelpText = "Save processed claims to the database"
    )]
    public bool Save { get; set; }
}
