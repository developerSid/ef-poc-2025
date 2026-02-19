namespace PayerEdi.Ingestion.Validation;

public record X12ValidationHierarchyKey(RuleTier Tier, RuleScope Scope, string Key, Type type);