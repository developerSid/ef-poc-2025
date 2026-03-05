namespace PayerEdi.Ingestion.Validation.x12._837p;

/// <summary>
/// Executes EdiFabric SNIP 1 validation for <see cref="TS837P"/>.
/// </summary>
public sealed class TS837PSnip1Validator : X12SnipValidatorBase<TS837P>
{
    /// <inheritdoc />
    protected override RuleTier Tier => RuleTier.SNIP1;
}
