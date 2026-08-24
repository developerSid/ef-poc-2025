# Repository Guidelines

## Project Structure & Module Organization

- `src/PayerEDI.Data/` contains EdiFabric models, persistence entities, repositories, services, EF Core configuration, and migrations.
- `src/PayerEDI.Processor.Console/` contains the command-line entry point, configuration, launch profiles, and processing workflow.
- `tests/PayerEDI.Tests/` contains xUnit tests for parsing, models, helpers, and persistence mappings.
- `samples/EDI/` contains sample 837 input files; `docs/` contains onboarding and EDI/EF Core notes.
- `.helpers/` contains scripts for database lifecycle, profiles, and formatting.

Use `./.helpers/db-start` and `./.helpers/db-migrate` to start the local SQL Server and apply EF migrations. Use `./.helpers/pretty-code` to format `src/` and `tests/`. Database reset and truncate helpers are destructive; review their confirmation flags before use.

## Coding Style & Naming Conventions

Use nullable-enabled C# with four-space indentation, file-scoped namespaces, records for database table entities, and primary constructors where they improve clarity. Use PascalCase for types and members, camelCase for locals and parameters, and descriptive `*Table`, `*Repository`, `*Service`, and `*Extensions` names. Keep EF configuration in `PayerEdiDbContext` and use async database operations with cancellation tokens.

Before adding an extension method, first grep the entire codebase for an existing method that provides the same behavior or targets the same type; reuse or extend the existing implementation when appropriate instead of creating a duplicate. Extension methods for standard-library classes belong under `src/PayerEDI.Data/Helpers/` and must be placed in a file named `{StdlibClassName}Extensions.cs` (for example, `StringExtensions.cs`).

### C# and .NET Version

Before adding or changing C# code, inspect `global.json` and use syntax supported by its selected .NET SDK. This repository selects the .NET 10 SDK (`10.0.*`), whose corresponding default language version is C# 14; C# 14 syntax may be used when it improves clarity. Do not use syntax from a newer or preview language version unless the project explicitly opts into it. Also verify the project’s target framework and existing language-version settings, since a project-level setting takes precedence over the SDK default.

## Testing Guidelines

Tests use xUnit and follow descriptive `Method_Scenario_ExpectedResult` names. Add focused tests beside the relevant feature area, and include parser, mapping, null, and persistence edge cases where applicable. Run the full `dotnet test` command before submitting changes.

## Branch Difference Summaries

When describing the differences between a branch and the current branch, begin with a concise overview of the work completed. Follow it with detailed bullet points covering every meaningful change, including source behavior, database schema or migration changes, tests, configuration, documentation, and validation performed. Keep the summary factual and focused on differences rather than proposing commit or pull-request practices.

## Security & Configuration Tips

Do not commit connection strings, EdiFabric keys, generated secrets, or production data. Use the `EDI_PROCESSOR_` environment-variable prefix and the example appsettings/launch profiles for local configuration. Database migrations require `EDI_PROCESSOR_CONNECTIONSTRINGS__MIGRATION`; normal processing uses `EDI_PROCESSOR_CONNECTIONSTRINGS__DEFAULT` and `EDI_PROCESSOR_KEY__EDIFABRIC`.

## Agent Restrictions

Agents must not modify the contents or history of this Git repository unless the user explicitly requests the specific change. This includes, but is not limited to, running `git commit`, `git push`, `git merge`, `git rebase`, or destructive reset/checkout commands. Agents may prepare requested working-tree changes and report them for user review.

## Response Style
- **Be concise**: Answer directly without preamble, affirmations, or commentary on ideas.
- **Skip summaries**: After editing or creating code, do not explain what you did unless asked.
- **No flattery**: Do not praise the user's choices, questions, or code.
- **Language**: Always answer in English
