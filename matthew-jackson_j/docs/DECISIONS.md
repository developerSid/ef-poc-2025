# Decisions

This log tracks phase-scoped architecture and implementation decisions for the POC.

## Phase 1 Decisions
- Use `.NET 10` for the POC runtime to align with the current project baseline and available tooling.
- Keep the reader factory X12-only to avoid premature multi-standard abstraction before requirements exist.
- Defer EDI reader settings auto-detection/configuration because no current requirement depends on configurable reader settings.
- Skip parsed model types not mapped in `Hipaa837pDbContext` so supported records can still be persisted.
- Use Serilog console logging to provide structured diagnostics for ingestion flow troubleshooting.
- Require ISA/GS for interchange parsing but do not persist them because persistence scope is claim transaction data (for example, `TS837P`).

## Phase 2 Decisions
- Manage moto lifecycle outside `.NET` console apps (fixture/script/manual) to keep `PayerEdi.EdiFabric.MotoConsole` focused on S3 ingest and SQL validation.
- For Phase 2 local runs in Visual Studio, run `PayerEdi.S3Service` and `PayerEdi.EdiFabric.MotoConsole` together so S3 ingestion executes against a live mock endpoint while SQL persistence is validated in the same run.

## Phase 3 Planning Decisions (Draft)
- Build a configurable SNIP validation pipeline rather than hard-coding validation levels.
- Limit initial Phase 3 implementation scope to `837P`.
- Treat SNIP levels 1-6 as configurable and supported as a subset selected by settings.
- Treat SNIP level 7 as a custom-rule extension point instead of claiming complete provider-to-provider rule coverage.
- Use a hybrid approach: EdiFabric built-in validation for baseline standards compliance plus project-defined typed rules for partner/business constraints.
