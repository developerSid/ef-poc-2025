# PayerEDI Processor Cli Tool

Terminal tool to process an EDI File

## Setup
```shell
dotnet add src/PayerEDI.Processor.Console package Microsoft.Extensions.Hosting
dotnet add src/PayerEDI.Processor.Console package Microsoft.Extensions.Configuration.EnvironmentVariables
dotnet add src/PayerEDI.Processor.Console package Serilog
dotnet add src/PayerEDI.Processor.Console package Serilog.Sinks.Console
dotnet add src/PayerEDI.Processor.Console package Serilog.Extensions.Hosting
dotnet add src/PayerEDI.Processor.Console package Serilog.Settings.Configuration
dotnet add src/PayerEDI.Processor.Console package Serilog.Expressions
dotnet add src/PayerEDI.Processor.Console package Serilog.Formatting.Compact
dotnet add src/PayerEDI.Processor.Console package Serilog.Enrichers.Environment
dotnet add src/PayerEDI.Processor.Console package Serilog.Enrichers.Thread
dotnet add src/PayerEDI.Processor.Console package Serilog.Enrichers.Context
dotnet add src/PayerEDI.Processor.Console package CommandLineParser
```

## Running

Launch Settings has been defined in this project under _Properties/launchSettings.json_ with two profiles
* dental which will execute using the [samples/EDI/837d-sample-3.edi](../../samples/EDI/837d-sample-3.edi)
  * From gary-m directory root: `dotnet run --project src/PayerEDI.Processor.Console --launch-profile dental`
* professional which will execute using the [samples/EDI/837p-sample.edi](../../samples/EDI/837p-sample.edi)
    * From gary-m directory root: `dotnet run --project src/PayerEDI.Processor.Console --launch-profile professional`

### Dental