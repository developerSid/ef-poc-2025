---
name: map-837-to-domain
description: Map EdiFabric X12 healthcare transactions to the existing PayerEDI.Data domain models and factories. Use when adding, reviewing, or explaining mappings for 837P, 837D, or another supported transaction where loop and segment variants must be identified from context rather than assumed.
---

# Map EDI X12 to domain models

Map parsed EdiFabric transactions into the domain records under `src/PayerEDI.Data/Models` without silently losing data.

## Scope

The current domain model represents:

- Shared claim metadata through `HealthCareClaim`.
- Professional claims through `ProfessionalCareClaim`.
- Dental claims through `DentalCareClaim`.
- Submitters through `ClaimSubmitter`.
- Subscribers and dependents through `Subscriber`.
- People and organizations through `IndividualOrOrganization`.
- Providers through the polymorphic `HealthcareProvider` hierarchy.

`Procedure` represents mapped service-line data and is attached to claim records through the claim factories. Do not invent additional procedure or service-line fields; report source values as unmapped unless the user explicitly requests a domain-model expansion.

## Workflow

1. Inspect the parsed EdiFabric type before inspecting segment names. Start with `TS837P` or `TS837D`; do not assume a service-line segment from the claim family alone.
2. Identify the loop and entity context for each value. A segment's meaning depends on its loop, qualifier, and surrounding structure.
3. Search the entire `src/PayerEDI.Data/Models` tree—including all files under `Factory` and `Claims/Factory`—for an existing target model, factory method, extension method, overload, or related mapping pattern before writing code. The currently known claim, submitter, subscriber, provider, and identity factories are useful starting points, not an exhaustive list.
4. Reuse the closest existing factory method or mapping pattern when one exists, regardless of which factory file contains it. Add a narrowly scoped overload or helper only when the search shows that no suitable mapping exists or when the EdiFabric template exposes a genuinely distinct loop type.
5. Preserve transaction-specific behavior. Keep `TS837P` and `TS837D` mappings separate where their generated template types or loop structures differ.
6. Use the existing `RequireNm1`-style validation conventions for required identity elements. Keep optional values nullable and trim values consistently with neighboring factories.
7. Preserve repeated loops as collections. Do not use `First()` or overwrite earlier values when the EDI permits multiple subscribers, dependents, providers, claims, or loop occurrences.
8. Produce a mapping report with:
   - source transaction type;
   - source loop/segment/element for every mapped field;
   - target domain property and factory used;
   - unsupported or unmapped structures;
   - validation failures and assumptions.
9. Add or update focused xUnit tests beside the relevant feature. Test successful mapping, missing required values, optional values, repeated loops, and both supported claim families when applicable.

## Segment and service-line guidance

Do not treat `SV1` and `SV3` as universal rules. Determine the service-line representation from the parsed transaction type, implementation-guide/template loop, and actual EdiFabric object available in the input. Other claim families or variants may use different service-line structures or may not expose one in the same location.

For this iteration, service-line data is an explicit audit item: identify it, state why it is or is not represented by the current domain model, and report it as unmapped when no target property exists. Never silently drop a non-empty loop or segment.

## Expected implementation shape

Top-level mapping should continue to look like:

```csharp
ProfessionalCareClaim.New(groupDate, groupTime, ts837P)
DentalCareClaim.New(groupDate, groupTime, ts837D)
```

Nested mapping should remain composable through the existing factories, for example:

```csharp
var submitter = ClaimSubmitter.New(claim);
var subscribers = Subscriber.New(claim);
var providers = HealthcareProvider.New(claim);
```

Avoid putting raw EDI traversal throughout the processor or persistence service. Keep EDI-to-domain translation in `Models/Factory` and `Models/Claims/Factory`.

When mapping repeated EDI loops into records, separate collection traversal from record construction. The array/collection pipeline may use `SelectMany`, `Where`, and a short `Select`, but must delegate each source item to a dedicated static `New` mapping method. Do not put a large object initializer that instantiates the target record inline inside the traversal `Select`; keep transaction-specific overloads such as the 837P and 837D procedure mappings in their own `New` methods. `src/PayerEDI.Data/Models/Factory/Procedure.Factory.cs` is the reference pattern to follow, and its former inline `Select` initializer is an anti-pattern.

## Completion checklist

Before declaring a mapping complete, verify:

- The transaction type and loop context are documented.
- The entire models/factories area was searched, existing factories were reused where appropriate, or the reason for a new factory is recorded.
- 837P and 837D differences are handled explicitly.
- Required and optional element behavior is defined.
- Repeated loops are preserved.
- Unmapped segments and unsupported variants are reported.
- Domain-model gaps and any unmapped procedure/service-line fields are called out.
- Focused tests pass, followed by the project test command when the change affects shared mapping behavior.
