# matthew-jackson_j

### Index
Coding standards `docs/CODING_STANDARDS.md`
Database migrations `docs/DB_MIGRATIONS.md` 
DbContext metadata reporter `docs/DBCONTEXT_METADATA_REPORTER.md`
Scope `docs/STATEMENT_OF_WORK.md`
Test report format `docs/testing.md`
Decision log `docs/DECISIONS.md`
Phase 3 planning notes `docs/PHASE3_NOTES.md`

## Setup Prerequisites
1. Install `.NET SDK 10.x`.
2. Install `SQL Server Express` and ensure an instance is available (default expected instance is `.\SQLEXPRESS`).
3. Install `Python 3.12+` for Phase 2 S3 integration scripts.
4. Obtain an EdiFabric serial key.

## Required Environment Variables
1. Set `EDIFABRIC_SERIAL_KEY` as a machine environment variable (required for ingestion).
2. Optional: set `HIPAA_DB_CONNECTION` as a machine environment variable if you do not want default SQL settings.
3. If `HIPAA_DB_CONNECTION` is not set, the app uses:
   `Server=.\SQLEXPRESS;Database=PayerEdiPharmacy;Trusted_Connection=True;TrustServerCertificate=True;`

PowerShell example:

```powershell
setx EDIFABRIC_SERIAL_KEY "<your-serial-key>" /M
setx HIPAA_DB_CONNECTION "Server=.\SQLEXPRESS;Database=PayerEdiPharmacy;Trusted_Connection=True;TrustServerCertificate=True;" /M
```

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
   - `EDIFABRIC_SERIAL_KEY` is set.
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
- See `docs/PHASE3_NOTES.md` for current SNIP validation direction, scoped assumptions, and open questions.

## Decisions
- See `docs/DECISIONS.md` for phase-specific architectural decisions and rationale.

## Known Limitations (Phase 1 POC)
- Runtime target is `.NET 10` rather than `.NET 8` from the original SOW.
- The ingestion path currently targets X12/837 processing only; other EDI standards are not implemented end-to-end.
- Unmapped parsed item types are intentionally skipped during persistence instead of failing ingestion.
- Phase 3 scope item (SNIP validation levels) is not implemented in this phase.
