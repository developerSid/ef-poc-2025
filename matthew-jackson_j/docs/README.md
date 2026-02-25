# matthew-jackson_j

## Index
Coding standards `docs/CODING_STANDARDS.md`
Configuration reference `docs/CONFIGURATION.md`
Database migrations `docs/DB_MIGRATIONS.md`
DbContext metadata reporter `docs/DBCONTEXT_METADATA_REPORTER.md`
Scope `docs/STATEMENT_OF_WORK.md`
Decision log `docs/DECISIONS.md`
Phase 3 notes `docs/PHASE3_NOTES.md`
EdiFabric SNIP levels `docs/EDIFABRIC_SNIP_LEVELS.md`

## Setup Prerequisites
1. Install `.NET SDK 10.x`.
2. Install `SQL Server Express` and ensure an instance is available (default expected instance is `.\SQLEXPRESS`).
3. Install `Python 3.12+` for Phase 2 S3 integration scripts.
4. Obtain an EdiFabric serial key.
5. Optional for local workflow: Visual Studio 2022 17.10+ (solution launch profile support).

## Configuration
1. Configure repository root `appsettings.json`.
2. Required keys for local ingestion:
   - `EdiFabric:SerialKey`
   - `ConnectionStrings:HipaaDb`
3. Optional SNIP validation keys:
   - `SnipValidation:Enabled` (default `true`)
   - `SnipValidation:Level` (`SNIP1` to `SNIP4`, default `SNIP4`)
4. See `docs/CONFIGURATION.md` for the full key reference.

## Startup Project Configurations (Visual Studio)
The solution uses `PayerEdi.Pharmacy.slnLaunch` profiles:

1. `Console`
   - Starts `src/PayerEdi.EdiFabric.Console/PayerEdi.EdiFabric.Console.csproj`
2. `MotoConsole`
   - Starts `src/PayerEdi.EdiFabric.MotoConsole/PayerEdi.EdiFabric.MotoConsole.csproj`
   - Starts `src/PayerEdi.S3Service/PayerEdi.S3Service.pyproj`
3. `ValidatedConsole`
   - Starts `src/PayerEdi.EdiFabric.ValidatedConsole/PayerEdi.EdiFabric.ValidatedConsole.csproj`
   - Starts `src/PayerEdi.S3Service/PayerEdi.S3Service.pyproj`

Per-project debug profiles are set in each `*.csproj.user` file to the matching project profile.

## Run Modes
1. Local SQL ingestion (`Console`):
   - `dotnet restore`
   - `dotnet run --project src/PayerEdi.EdiFabric.Console`
2. S3 + SQL ingestion (`MotoConsole`):
   - `dotnet run --project src/PayerEdi.EdiFabric.MotoConsole`
3. S3 + SQL ingestion with SNIP pre-save validation (`ValidatedConsole`):
   - `dotnet run --project src/PayerEdi.EdiFabric.ValidatedConsole`

## Run Tests
1. Ensure prerequisites are in place for the full test suite:
   - `SQL Server Express` is running.
   - `EdiFabric:SerialKey` is set in `appsettings.json`.
   - `src/PayerEdi.S3Service/.venv` exists (run `cd src/PayerEdi.S3Service; .\setup.ps1` once).
2. Run `dotnet test` from repo root.

## Quality Gates
1. CI workflow: `.github/workflows/ci.yml`
2. PR checklist: `.github/pull_request_template.md`
3. Local format check:
   - `dotnet format src/PayerEdi.EdiFabric.Console/PayerEdi.EdiFabric.Console.csproj --verify-no-changes`
   - `dotnet format tests/PayerEdi.Pharmacy.Tests/PayerEdi.Pharmacy.Tests.csproj --verify-no-changes`

## Phase 2 S3 Integration
- Python service docs: `docs/S3_SERVICE.md`
- Mode A (`PayerEdi.S3Service` only): Python-only local processing.
- Mode B (`PayerEdi.S3Service` + `PayerEdi.EdiFabric.MotoConsole`): mock S3 plus .NET SQL validation.
- Mode C (`PayerEdi.S3Service` + `PayerEdi.EdiFabric.ValidatedConsole`): mock S3 plus .NET SQL validation with SNIP pre-save validation.

## EdiFabric Serial Key Authentication
Follow EdiFabric's Serial Key Authentication guide:
https://support.edifabric.com/hc/en-us/articles/10993195863709-Serial-Key-Authentication

## Phase 3 Notes
See `docs/PHASE3_NOTES.md` for implemented scope and remaining gaps.

## Decisions
See `docs/DECISIONS.md` for phase-specific architecture and implementation decisions.

## Known Limitations
- Runtime target is `.NET 10` rather than `.NET 8` from the original SOW.
- Ingestion is currently X12/837-focused; other EDI standards are not implemented end-to-end.
- Unmapped parsed item types are intentionally skipped during persistence instead of failing ingestion.
- SNIP pre-save validation currently supports `SNIP1` through `SNIP4` only.
