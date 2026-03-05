# Phase 3 SNIP Validation Notes

Single source of truth for Phase 3 implementation status, findings, and decisions.

## Scope
- Phase 3 requirement in `docs/STATEMENT_OF_WORK.md` is high-level: add SNIP validation.
- Initial implementation scope: `837P` only.
- Current implemented runtime support: configurable `SNIP1` through `SNIP4`.
- SNIP 5-7 remain extension/customization work.

## Current Implementation Status
- `PayerEdi.EdiFabric.MotoConsole` and `PayerEdi.EdiFabric.ValidatedConsole` intentionally retain parallel flow structure to document transition over time (baseline flow vs validated flow).
- Implemented pre-save validation hook:
  - `src/PayerEdi.Pharmacy/Services/X12SnipValidationPreSaveHook.cs`
- Implemented options binding:
  - `src/PayerEdi.Pharmacy/Services/SnipValidationOptions.cs`
  - `src/PayerEdi.Pharmacy/Extensions/Startup.cs`
- Implemented TS837P validator registrations:
  - `src/PayerEdi.Ingestion/Validation/x12/837p/*.cs`
- Implemented validated runtime entry point:
  - `src/PayerEdi.EdiFabric.ValidatedConsole/Program.cs`
- Unit test coverage exists for hook behavior, cache registration, and composition:
  - `tests/PayerEdi.Pharmacy.Tests/Ingestion/*Snip*Tests.cs`

## Current Ingestion Pattern
- Reader setup and standard detection are clean for POC:
  - `src/PayerEdi.Ingestion/Reader/EdiReaderFactory.cs`
  - `src/PayerEdi.Ingestion/Sniffing/EdiReaderSniffer.cs`
- Ingestion flow in `src/PayerEdi.Pharmacy/Services/Hipaa837pIngestionService.cs`:
  1. Initialize token
  2. Read parsed items (`reader.ReadAll()`)
  3. Begin DB transaction
  4. Persist EF-mapped items
  5. Commit

## Validation Insertion Point
Run validation after read and before DB transaction:

1. `var items = reader.ReadAll();`
2. Validate parsed transactions.
3. If blocking mode and errors exist, stop.
4. Otherwise continue persistence.

This keeps parsing, validation, and persistence concerns separated.

## Validation Direction
- Behavior should be configurable, not hard-coded.
- Configuration keys:
  - `SnipValidation:Enabled`
  - `SnipValidation:Level` (`SNIP1`..`SNIP4`)
- Processing semantics:
  - Current behavior is blocking for validation failures (throws before persistence).

## API Findings
- Use `IsValid(..., out MessageErrorContext, ValidationSettings)` for consuming validation results.
- `ValidationContext` is mainly relevant for custom validator logic.
- Practical split:
  - SNIP 1: parse/read errors
  - SNIP 2-4: built-in validation via `ValidationSettings`
  - SNIP 6/7-like partner rules: custom validators

## Hierarchy Notes
- Validation is hierarchical in strictness (SNIP levels).
- Validation output is hierarchical by message structure (transaction -> segment -> element/composite).
- For rule design, `item` is required and hierarchy/context may be optional depending on rule type.

## Naming Decision
- Validation implementations use prefix-only naming (no per-standard folders yet).
- Examples:
  - `X12ClaimLevelValidator`
  - `EdifactInvoiceLevelValidator`
  - `Hl7MessageLevelValidator`
- Rationale:
  - Team uses search-first navigation.
  - Lower overhead for current Phase 3 scale.
- Revisit when validator count grows enough that discoverability/registration becomes noisy.

## POC Tradeoff
- `ReadAll()` buffering is acceptable for current POC.
- Chunked/streamed processing is a future optimization, not Phase 3-required.

## Persistence Modeling Note
- Current generated schema uses many `int` identity keys.
- For long-lived national-scale persistence, domain-owned models and key strategy (`bigint`/GUID where appropriate) are safer than transit-shaped template defaults.

## Suggested Acceptance Criteria
- Valid `837P` file passes configured SNIP levels and persists.
- Invalid `837P` file yields structured validation results.
- Blocking mode prevents persistence on validation error.
- Non-blocking mode is not implemented in current scope.

## Phase Closeout
- Implemented and validated scope for this phase: configurable blocking SNIP pre-save validation for `TS837P` at levels `SNIP1` through `SNIP4`.
- Deferred scope remains explicit: SNIP 5-7 extension work and non-blocking validation/reporting mode.

## External References
- SNIP levels: https://support.edifabric.com/hc/en-us/articles/360000361352-How-to-validate-HIPAA-SNIP-levels
- Validation config: https://support.edifabric.com/hc/en-us/articles/360026390531-How-to-configure-EDI-validation
- Validation result model/hooks: https://support.edifabric.com/hc/en-us/articles/360000373811-Validate-EDI-with-templates
- Template/persistence examples:
  - https://support.edifabric.com/hc/en-us/articles/360000368612-HIPAA-5010-837P-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360000368872-X12-850-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360000369092-EDIFACT-ORDERS-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360029265372-EDI-to-DB
