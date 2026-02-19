namespace PayerEdi.Ingestion.Validation;

public record ValidationHierarchyKey(RuleTier Tier, RuleScope Scope, string Key);