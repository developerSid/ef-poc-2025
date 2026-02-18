# Phase 3 Ingestion + Validation Findings

## Scope
Findings captured from reviewing current read/ingestion flow and discussing how to introduce SNIP validation in Phase 3 without overengineering.

## Current Ingestion Pattern
- Reader selection and stream handling are clean for POC:
  - `src/PayerEdi.Ingestion/Reader/EdiReaderFactory.cs`
  - `src/PayerEdi.Ingestion/Sniffing/EdiReaderSniffer.cs`
- `Hipaa837pIngestionService` currently:
  1. Initializes EdiFabric token.
  2. Reads all parsed items from stream.
  3. Starts DB transaction.
  4. Persists EF-mapped items.
  5. Commits transaction.
  - File: `src/PayerEdi.Pharmacy/Services/Hipaa837pIngestionService.cs`

## Recommended Validation Insertion Point
Add validation immediately after read and before starting DB transaction:

1. `var items = reader.ReadAll();`
2. Validate parsed transaction messages.
3. If blocking mode and errors exist, stop before persistence.
4. Otherwise continue current persistence flow.

This preserves current architecture and adds a clear Phase 3 seam.

## EdiFabric Validation API Findings
- For consumption of validation results, use `IsValid(..., out MessageErrorContext, ValidationSettings)`.
- `ValidationContext` is primarily for custom validator logic, not the main result object to process.
- Practical split:
  - SNIP 1: parse/read errors
  - SNIP 2-4: built-in `IsValid` with `ValidationSettings`
  - SNIP 6/7-like partner rules: custom validators (where `ValidationContext` becomes relevant)

## Hierarchy Understanding
- Validation is hierarchical at two levels:
  - SNIP levels increase strictness.
  - Error locations are hierarchical (transaction -> segment -> element/composite context).
- Operationally: validate once at transaction root, then consume context-rich errors.

## POC Tradeoff
- `ReadAll()` buffering is acceptable for this POC.
- For larger production payloads, chunked/streamed processing would be the next evolution, but it is not required for current scope.

## Persistence Modeling Note
- Current generated schema uses `int` identities broadly (visible in migrations).
- For long-lived national-scale persistence, a domain-owned model and key strategy (`bigint`/GUID where appropriate) is safer than relying on transit-shaped template defaults.

## External References (Annotated)
- EdiFabric SNIP guidance:
  - https://support.edifabric.com/hc/en-us/articles/360000361352-How-to-validate-HIPAA-SNIP-levels
  - Why it mattered: baseline mapping of SNIP levels to EdiFabric validation configuration and usage.
- EdiFabric validation configuration:
  - https://support.edifabric.com/hc/en-us/articles/360026390531-How-to-configure-EDI-validation
  - Why it mattered: practical `ValidationSettings` usage and `IsValid(..., out MessageErrorContext, settings)` pattern.
- EdiFabric validation result model and extension hooks:
  - https://support.edifabric.com/hc/en-us/articles/360000373811-Validate-EDI-with-templates
  - Why it mattered: confirms `MessageErrorContext` structure and where custom validation hooks use `ValidationContext`.
- EdiFabric template/persistence examples:
  - https://support.edifabric.com/hc/en-us/articles/360000368612-HIPAA-5010-837P-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360000368872-X12-850-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360000369092-EDIFACT-ORDERS-EDI-Template
  - https://support.edifabric.com/hc/en-us/articles/360029265372-EDI-to-DB
  - Why it mattered: examples commonly show `int` key usage, which informed the key-type scalability discussion.
