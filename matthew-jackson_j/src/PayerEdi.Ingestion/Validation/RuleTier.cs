namespace PayerEdi.Ingestion.Validation;

/// <summary>
/// Defines the single rule policy tier selected for a validation run.
/// </summary>
/// <remarks>
/// Ordinal model only; do not combine values with bitwise operations.
/// A rule executes at most once per run for the selected tier.
/// If repeated execution is needed, configure multiple rule instances explicitly.
/// </remarks>
public enum RuleTier : int
{
    /// <summary>No tier selected.</summary>
    None = 0,
    /// <summary>Tier 1 policy.</summary>
    Tier1 = 1,
    /// <summary>Tier 2 policy.</summary>
    Tier2 = 2,
    /// <summary>Tier 3 policy.</summary>
    Tier3 = 3,
    /// <summary>Tier 4 policy.</summary>
    Tier4 = 4,
    /// <summary>Tier 5 policy.</summary>
    Tier5 = 5,
    /// <summary>Tier 6 policy.</summary>
    Tier6 = 6,
    /// <summary>Tier 7 policy.</summary>
    Tier7 = 7
}
