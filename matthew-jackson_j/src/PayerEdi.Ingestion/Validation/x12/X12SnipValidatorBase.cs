using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.X12;

namespace PayerEdi.Ingestion.Validation.x12;

/// <summary>
/// Base class for typed X12 validators with consistent null-guard and dispatch behavior.
/// </summary>
public abstract class X12SnipValidatorBase<TModel> : IX12Validator<TModel> where TModel : class
{
    /// <summary>
    /// Tier this validator is intended to execute under.
    /// </summary>
    protected abstract RuleTier Tier { get; }

    /// <summary>
    /// Performs validator-specific checks after base SNIP validation passes.
    /// </summary>
    protected virtual (bool, string?) OnValidate(ISA isa, GS? gs, ST? st, TModel item)
    {
        if (item is not EdiMessage message)
            return (false, $"Unsupported item type for SNIP validation: {typeof(TModel).FullName}.");

        if (Tier < RuleTier.SNIP1 || Tier > RuleTier.SNIP4)
            return (false, $"Unsupported RuleTier '{Tier}' for EdiFabric SNIP validation. Supported: SNIP1-SNIP4.");

        var validationSettings = new ValidationSettings
        {
            ValidationLevel = (ValidationLevel)(int)Tier
        };

        var isValid = message.IsValid(out var errorContext, validationSettings);
        return isValid ? (true, null) : (false, $"{Tier} validation failed: {string.Join("\r\n", errorContext.Flatten())}");
    }

    /// <inheritdoc />
    public (bool, string?) Validate(ISA isa, GS? gs, ST? st, TModel item) => OnValidate(isa, gs, st, item);
}
