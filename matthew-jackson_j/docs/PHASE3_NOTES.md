# Phase 3 SNIP Validation Notes

Single source of truth for Phase 3 planning, findings, and decisions.

## Scope
- Phase 3 requirement in `docs/STATEMENT_OF_WORK.md` is high-level: add SNIP validation.
- Initial implementation scope: `837P` only.
- SNIP 1-6: configurable support.
- SNIP 7: custom-rule extension point only (not full trading-partner logic).

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
  - `SnipValidation:Levels` (example: `1,2,3`)
  - `SnipValidation:FailOnError`
  - `SnipValidation:MaxErrors`
- Processing semantics:
  - `FailOnError=true`: block persistence on validation errors.
  - `FailOnError=false`: allow persistence and capture validation output.

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
- Non-blocking mode allows persistence and records validation output.

## Open Questions
- Which SNIP levels are mandatory for acceptance?
- Minimum invalid-file scenarios required for tests?
- Persist validation outcomes to SQL, logs, or both?
- Warning vs error acceptance threshold?

## External References
- SNIP levels: https://support.edifabric.com/hc/en-us/articles/360000361352-How-to-validate-HIPAA-SNIP-levels
- Validation config: https://support.edifabric.com/hc/en-us/articles/360026390531-How-to-configure-EDI-validation
- Validation result model/hooks: https://support.edifabric.com/hc/en-us/articles/360000373811-Validate-EDI-with-templates
- Template/persistence examples:
  - https://support.edifabric.com/hc/en-us/articles/360000368612-HIPAA-5010-837P-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360000368872-X12-850-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360000369092-EDIFACT-ORDERS-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360029265372-EDI-to-DB
