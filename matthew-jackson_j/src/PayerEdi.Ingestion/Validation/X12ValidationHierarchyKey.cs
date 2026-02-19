namespace PayerEdi.Ingestion.Validation;

/// <summary>
/// Immutable key used for X12 validator lookup by policy tier, scope, canonical context, and model type.
/// </summary>
public record X12ValidationHierarchyKey(RuleTier Tier, RuleScope Scope, string Key, Type type);
