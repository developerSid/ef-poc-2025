# matthew-jackson_j

### Index
Coding standards `docs/CODING_STANDARDS.md`
Database migrations `docs/DB_MIGRATIONS.md` 
Scope `docs/STATEMENT_OF_WORK.md`
Test report format `docs/testing.md`

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
- Quick start:
  1. `cd src/PayerEdi.S3Service`
  2. `.\run_phase2_once.ps1`
  3. Expected outcome:
     - moto S3 starts
     - sample `.edi` files are uploaded to `inbound/`
     - files are asynchronously processed
     - files are moved to `processed/`


## EdiFabric Serial Key Authentication
Follow EdiFabric's Serial Key Authentication guide to obtain a serial key and apply it in code:
https://support.edifabric.com/hc/en-us/articles/10993195863709-Serial-Key-Authentication

## Phase 1 Decisions
- We chose .NET 10 as a design decision for this POC.
- EDI reader settings detection/configuration is intentionally deferred for the Phase 1 POC (no current requirements).
- EDI reader factory remains X12-only with minimal surface area (avoid premature multi-standard strategy until needed).
- During ingestion, model types not mapped in `Hipaa837pDbContext` are skipped to allow persistence of supported entities without failing the entire transaction.
- Console logging uses Serilog with the console sink to provide structured runtime diagnostics for the ingestion flow.
- ISA/GS envelope segments are required for interchange parsing but are intentionally not persisted; Phase 1 persistence focuses on claim transaction records (for example, `TS837P`) and related claim data.

## Known Limitations (Phase 1 POC)
- Runtime target is `.NET 10` rather than `.NET 8` from the original SOW.
- The ingestion path currently targets X12/837 processing only; other EDI standards are not implemented end-to-end.
- Unmapped parsed item types are intentionally skipped during persistence instead of failing ingestion.
- Phase 3 scope item (SNIP validation levels) is not implemented in this phase.