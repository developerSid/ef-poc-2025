using PayerEdi.Ingestion.Validation;

namespace PayerEdi.Pharmacy.Services;

/// <summary>
/// Configuration for optional SNIP validation in the ingestion pre-save stage.
/// </summary>
public sealed class SnipValidationOptions
{
    public const string SectionName = "SnipValidation";

    public bool Enabled { get; set; } = true;

    public RuleTier Level { get; set; } = RuleTier.SNIP4;
}
