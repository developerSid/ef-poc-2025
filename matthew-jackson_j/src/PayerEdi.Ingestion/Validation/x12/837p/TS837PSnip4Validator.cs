namespace PayerEdi.Ingestion.Validation.x12._837p;

/// <summary>
/// Executes EdiFabric SNIP 4 validation for <see cref="TS837P"/>.
/// </summary>
public sealed class TS837PSnip4Validator : X12SnipValidatorBase<TS837P>
{
    /// <inheritdoc />
    protected override RuleTier Tier => RuleTier.SNIP4;
}
