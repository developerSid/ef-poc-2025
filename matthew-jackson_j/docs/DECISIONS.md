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
- For Phase 2 local runs in Visual Studio, run `PayerEdi.S3Service` and `PayerEdi.EdiFabric.MotoConsole` together so S3 ingestion executes against a live mock endpoint while SQL persistence is validated in the same run.
- Add optional moto lifecycle control inside `.NET` console entry points (`StartMoto`, `KillExistingMoto`, `KillMotoOnExit`) while keeping default behavior as external moto management.
- Keep `PayerEdi.EdiFabric.MotoConsole` and `PayerEdi.EdiFabric.ValidatedConsole` bootstrapping/runners intentionally similar to make transition-stage behavior explicit in code review and demos.

## Phase 3 Decisions
- Build a configurable SNIP validation pipeline rather than hard-coding validation levels.
- Limit initial Phase 3 implementation scope to `837P`.
- Treat current runtime-configurable scope as SNIP 1-4 (`SnipValidation:Level`) with cumulative execution.
- Treat SNIP levels 5-7 as extension/customization work (not first-class runtime support in this phase).
- Use a hybrid approach: EdiFabric built-in validation for baseline standards compliance plus project-defined typed rules for partner/business constraints.
- Treat `ValidationHierarchy` as a build-time mutable object and avoid using it directly as a hash key after mutation; use a derived immutable lookup key or canonical key snapshot for in-memory rule indexing.
- Use `ValidationHierarchyKey` as the canonical key type for all rule lookup/indexing; treat `ValidationHierarchy` as construction context only.
- Within each `ValidationHierarchyKey` grouping, execute validation rules in the order returned by the configured rule source.
- Decouple rule lookup from transaction traversal: transactional processing owns construction of the exact lookup context/key for the current ISA/GS/ST, and lookup consumes that preconstructed context without implicitly selecting segments.
- Defer `ValidationHierarchy` key-generation optimization (for example, caching) until rules-engine key construction and ownership are finalized; optimize only with profiling evidence.
- Treat `Scope` and `Tier` as first-class validation selectors for X12 processing modes; rules-engine lookup and execution design must preserve both dimensions intentionally.
