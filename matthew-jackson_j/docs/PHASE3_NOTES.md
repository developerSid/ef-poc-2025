# Phase 3 SNIP Validation Notes (Draft)

This document records current planning decisions and open questions for Phase 3 while requirements are refined.

## Current Understanding
- The Phase 3 requirement in `docs/STATEMENT_OF_WORK.md` is intentionally high-level and needs implementation boundaries to be testable.
- Full SNIP level 7 coverage is not practical as a generic implementation because it is trading-partner/provider specific.
- The 837 transaction family is broad; this phase should keep a tight initial scope.

## Draft Decisions
- Validation behavior should be configurable by settings, not hard-coded.
- Initial transaction scope should be `837P` only.
- SNIP levels 1-6 should be supported as a configurable subset.
- SNIP level 7 should be modeled as a custom-rule extension point with optional simple scenarios, not full provider-to-provider logic.
- Implementation should use a hybrid approach:
  - EdiFabric built-in validation as the standards baseline.
  - Project-defined typed rules over EdiFabric model classes for partner/business-specific constraints.

## Configuration Direction (Draft)
- `SnipValidation:Enabled`
- `SnipValidation:Levels` (example: `1,2,3`)
- `SnipValidation:FailOnError`
- `SnipValidation:MaxErrors`

## Processing Semantics To Finalize
- If `FailOnError=true`, validation errors should block persistence.
- If `FailOnError=false`, persistence may proceed while capturing validation results.
- Validation output format should be explicit and testable (severity, code, message, segment/context).

## Open Questions
- Which SNIP levels are mandatory for Phase 3 acceptance?
- Are there minimum required invalid-file scenarios for tests?
- Should validation outcomes be persisted to SQL, logged only, or both?
- What is the acceptance threshold for warnings vs errors?

## Suggested Acceptance Criteria (Draft)
- A valid `837P` file passes configured SNIP levels and persists successfully.
- An invalid `837P` file produces structured validation results.
- Blocking mode (`FailOnError=true`) prevents persistence on validation error.
- Non-blocking mode (`FailOnError=false`) allows persistence and records validation output.
