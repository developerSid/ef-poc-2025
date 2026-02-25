# matthew-jackson_j

### Index
Coding standards `docs/CODING_STANDARDS.md`
Configuration reference `docs/CONFIGURATION.md`
Database migrations `docs/DB_MIGRATIONS.md` 
DbContext metadata reporter `docs/DBCONTEXT_METADATA_REPORTER.md`
Scope `docs/STATEMENT_OF_WORK.md`
Test report format `docs/testing.md`
Decision log `docs/DECISIONS.md`
Phase 3 planning notes `docs/PHASE3_NOTES.md`
EdiFabric SNIP levels `docs/EDIFABRIC_SNIP_LEVELS.md`

## Setup Prerequisites
1. Install `.NET SDK 10.x`.
2. Install `SQL Server Express` and ensure an instance is available (default expected instance is `.\SQLEXPRESS`).
3. Install `Python 3.12+` for Phase 2 S3 integration scripts.
4. Obtain an EdiFabric serial key.

## Configuration
1. Configure application settings in the repository root `appsettings.json`.
2. Required keys for local ingestion:
   - `EdiFabric:SerialKey`
   - `ConnectionStrings:HipaaDb`
3. See `docs/CONFIGURATION.md` for the full key reference in colon notation.

## Phase 1 Run (SQL + Ingestion)
1. `dotnet restore`
2. `dotnet run --project src/PayerEdi.EdiFabric.Console`
3. Expected outcome:
   - database migrations are applied
   - `samples/837p-sample.edi` is ingested
   - claim data is persisted to SQL Server Express

## Run Tests
1. Ensure prerequisites are in place for the full test suite:
   - `SQL Server Express` is running.
   - `EdiFabric:SerialKey` is set in `appsettings.json`.
   - `src/PayerEdi.S3Service/.venv` exists (run `cd src/PayerEdi.S3Service; .\setup.ps1` once).
2. Run `dotnet test` from repo root.
3. Record summary results in `docs/testing.md` (do not paste full raw console logs).

## Quality Gates
1. CI workflow: `.github/workflows/ci.yml`
2. PR checklist: `.github/pull_request_template.md`
3. Local format check:
   - `dotnet format src/PayerEdi.EdiFabric.Console/PayerEdi.EdiFabric.Console.csproj --verify-no-changes`
   - `dotnet format tests/PayerEdi.Pharmacy.Tests/PayerEdi.Pharmacy.Tests.csproj --verify-no-changes`

## Phase 2 S3 Integration
- Python service docs: `docs/S3_SERVICE.md`
- Mode A (`PayerEdi.S3Service` only): run Python end-to-end processing (moto + seed + async processing).
- Mode B (`PayerEdi.S3Service` + `PayerEdi.EdiFabric.MotoConsole`): run the mock S3 service and .NET ingestion validation together.
- See `docs/S3_SERVICE.md` for detailed steps for both modes.


## EdiFabric Serial Key Authentication
Follow EdiFabric's Serial Key Authentication guide to obtain a serial key and apply it in code:
https://support.edifabric.com/hc/en-us/articles/10993195863709-Serial-Key-Authentication

## Phase 3 Planning Notes
- See `docs/PHASE3_NOTES.md` for consolidated Phase 3 direction, findings, decisions, and open questions.

## Decisions
- See `docs/DECISIONS.md` for phase-specific architectural decisions and rationale.

## Known Limitations (Phase 1 POC)
- Runtime target is `.NET 10` rather than `.NET 8` from the original SOW.
- The ingestion path currently targets X12/837 processing only; other EDI standards are not implemented end-to-end.
- Unmapped parsed item types are intentionally skipped during persistence instead of failing ingestion.
- Phase 3 scope item (SNIP validation levels) is not implemented in this phase.
