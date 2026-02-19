namespace PayerEdi.Ingestion.Validation.x12._837p;

/// <summary>
/// Executes EdiFabric SNIP 2 validation for <see cref="TS837P"/>.
/// </summary>
public sealed class TS837PSnip2Validator : X12SnipValidatorBase<TS837P>
{
    /// <inheritdoc />
    protected override RuleTier Tier => RuleTier.SNIP2;
}
