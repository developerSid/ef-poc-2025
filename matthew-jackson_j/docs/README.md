# matthew-jackson_j

### Index
Coding standards `docs/CODING_STANDARDS.md`
Database migrations `docs/DB_MIGRATIONS.md` 
Scope `docs/STATEMENT_OF_WORK.md`

## Ingestion POC
1. Set `EDIFABRIC_SERIAL_KEY` (machine environment variable).
2. Optional: set `HIPAA_DB_CONNECTION` (machine environment variable). If not set, the console uses `.\SQLEXPRESS` and database `PayerEdiPharmacy`.
3. Run `dotnet run --project src/PayerEdi.EdiFabric.Console`.
4. The app ingests `samples/837p-sample.edi` and persists it to SQL Server Express.


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
- Phase 2 and Phase 3 scope items (S3 async ingestion and SNIP validation levels) are not implemented in this phase.