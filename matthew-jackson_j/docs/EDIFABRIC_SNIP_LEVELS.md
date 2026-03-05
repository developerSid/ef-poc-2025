# EdiFabric HIPAA SNIP Levels

## Purpose
This document summarizes how EdiFabric defines and implements HIPAA SNIP validation levels for X12 HIPAA transactions, based on current EdiFabric documentation.

Last reviewed: February 19, 2026

## Executive Summary
- EdiFabric documents support for SNIP levels 1 through 7.
- Built-in `ValidationSettings.ValidationLevel` is currently modeled through SNIP 4:
  - `SyntaxOnly_SNIP1`
  - `LimitsAndCodes_SNIP2`
  - `Balancing_SNIP3`
  - `InterSegment_SNIP4`
- SNIP 5 through SNIP 7 are handled via template customization, code maps, and custom validation extensions (not additional `ValidationLevel` enum values).

## SNIP Level Matrix in EdiFabric
| SNIP | EdiFabric support | Primary execution path | How it is configured |
|---|---|---|---|
| 1 | Yes | During translation/parsing (`EdiReader`) | Template structure plus validation settings |
| 2 | Yes | `IsValid(...)` | Template validation attributes plus optional custom validation |
| 3 | Yes | `IsValid(...)` | Built-in balancing logic in specific HIPAA templates |
| 4 | Yes | `IsValid(...)` | Conditional/syntax-note attributes; situational rules are custom |
| 5 | Yes | `IsValid(...)` | External code sets via maps or partner template variants |
| 6 | Yes | `IsValid(...)` with extensions | Template hierarchy plus custom rules/validators |
| 7 | Yes | `IsValid(...)` with partner customizations | Partner-specific templates and rules |

## Level-by-Level Findings

## SNIP 1: Syntax Integrity
- Checked while translating EDI into template objects.
- EdiFabric supports partial parsing, so invalid files can still produce objects.
- Practical gate: check `EdiMessage.HasErrors == false` for syntax integrity.
- Header/trailer control checks and trailer counts are not fully covered by parsing alone; run `IsValid(...)` when those checks are required.

## SNIP 2: IG Syntax, Usage, Limits, and Codes
- Executed via `IsValid(...)`.
- Covers core template-driven rules such as required usage, sequence/position, repeat counts, string length, data type, code sets, and HL/LX/ENT structural checks.
- By default, the validation level behavior is cumulative and defaults to SNIP 2.

## SNIP 3: Balancing
- Executed via `IsValid(...)`.
- EdiFabric documentation lists balancing support for HIPAA 5010 transactions including `820`, `835`, `837D`, `837I`, and `837P`.
- Balancing behavior is implemented in templates and custom validator logic for those transactions.

## SNIP 4: Inter-Segment and Situational Logic
- Executed via `IsValid(...)`.
- Built-in conditional attributes support HIPAA syntax-note style inter-segment constraints.
- Important boundary: EdiFabric explicitly states situational rules are not automatically validated out-of-the-box and should be implemented manually.
- Recommended EdiFabric extension approaches:
  - Custom attributes derived from `ValidationAttribute`
  - Custom validators via `IEdiValidator`

## SNIP 5: External Code Sets
- Executed via `IsValid(...)`.
- Implemented through one of these approaches:
  - Partner-specific template variants (static)
  - `DataElementTypeMap` (static type mapping)
  - `DataElementCodesMap` (dynamic runtime code-list injection)
- Dynamic map loading supports runtime code updates without redeploying templates.

## SNIP 6: Product Type or Service-Type Rules
- Implemented through template structure plus custom rule extensions.
- EdiFabric positions this level as requiring domain-specific template placement and additional validation logic where needed.

## SNIP 7: Trading Partner Specific Rules
- Implemented through partner-specific template and rule customization.
- EdiFabric indicates ISA/GS behavior can also be customized for partner requirements.

## How `IsValid(...)` Returns Results
- `IsValid(out MessageErrorContext, ValidationSettings)` returns:
  - `true` when no validation errors are found
  - `false` when errors are found
- Error details are returned through `MessageErrorContext`, with nested segment and data-element contexts used for detailed diagnostics and acknowledgments.

## Practical Configuration Notes
- `ValidationSettings.ValidationLevel` is cumulative from 1 upward.
- Available enum options are documented only up to SNIP 4.
- Typical knobs relevant to SNIP configuration and tuning:
  - `ValidationLevel`
  - `SkipTrailerValidation`
  - `DataElementCodesMap`
  - `DataElementTypeMap`
  - `SyntaxSet`
  - HL/LX/ENT sequence-related flags

## Example Configuration Pattern
```csharp
var settings = new ValidationSettings
{
    ValidationLevel = ValidationLevel.InterSegment_SNIP4,
    SkipTrailerValidation = false,
    DataElementCodesMap = externalCodes // optional for SNIP 5 style behavior
};

MessageErrorContext errorContext;
var isValid = ediMessage.IsValid(out errorContext, settings);
```

## Documentation Reviewed
- How to validate HIPAA SNIP levels (updated January 22, 2026)
  - https://support.edifabric.com/hc/en-us/articles/360000361352-How-to-validate-HIPAA-SNIP-levels
- How to configure EDI validation (updated January 23, 2026)
  - https://support.edifabric.com/hc/en-us/articles/360026390531-How-to-configure-EDI-validation
- How to validate HIPAA situational rules (updated January 23, 2026)
  - https://support.edifabric.com/hc/en-us/articles/360013637597-How-to-validate-HIPAA-situational-rules
- Validate EDI with templates (updated April 24, 2023)
  - https://support.edifabric.com/hc/en-us/articles/360000373811-Validate-EDI-with-templates

## Notes for This Repository
- This write-up is informational and does not change runtime behavior.
- If implementation proceeds, SNIP 1-4 can be controlled directly with `ValidationSettings.ValidationLevel`, while SNIP 5-7 should be treated as extension/customization work.
