namespace PayerEdi.Ingestion.Validation;

/// <summary>
/// Defines the single validation policy tier selected for a run.
/// </summary>
/// <remarks>
/// Tier members (<see cref="Tier1"/> through <see cref="Tier7"/>) are generic policy tiers used by the rules engine.
/// SNIP members (<see cref="SNIP1"/> through <see cref="SNIP7"/>) are HIPAA SNIP aliases that map to the same numeric values.
/// This is an ordinal model only; do not combine values with bitwise operations.
/// A rule executes at most once per run for the selected tier unless configured otherwise.
/// </remarks>
public enum RuleTier : int
{
    /// <summary>No tier selected.</summary>
    None = 0,
    /// <summary>Generic tier 1 policy level.</summary>
    Tier1 = 1,
    /// <summary>HIPAA SNIP level 1 policy alias.</summary>
    SNIP1 = Tier1,
    /// <summary>Generic tier 2 policy level.</summary>
    Tier2 = 2,
    /// <summary>HIPAA SNIP level 2 policy alias.</summary>
    SNIP2 = Tier2,
    /// <summary>Generic tier 3 policy level.</summary>
    Tier3 = 3,
    /// <summary>HIPAA SNIP level 3 policy alias.</summary>
    SNIP3 = Tier3,
    /// <summary>Generic tier 4 policy level.</summary>
    Tier4 = 4,
    /// <summary>HIPAA SNIP level 4 policy alias.</summary>
    SNIP4 = Tier4,
    /// <summary>Generic tier 5 policy level.</summary>
    Tier5 = 5,
    /// <summary>HIPAA SNIP level 5 policy alias.</summary>
    SNIP5 = Tier5,
    /// <summary>Generic tier 6 policy level.</summary>
    Tier6 = 6,
    /// <summary>HIPAA SNIP level 6 policy alias.</summary>
    SNIP6 = Tier6,
    /// <summary>Generic tier 7 policy level.</summary>
    Tier7 = 7,
    /// <summary>HIPAA SNIP level 7 policy alias.</summary>
    SNIP7 = Tier7
}
