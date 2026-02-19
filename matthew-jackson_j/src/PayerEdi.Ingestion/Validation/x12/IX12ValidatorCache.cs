using EdiFabric.Core.Model.Edi.X12;

namespace PayerEdi.Ingestion.Validation.x12;

/// <summary>
/// Stores and resolves X12 validators by tier, scope key, and model type.
/// </summary>
public interface IX12ValidatorCache
{
    /// <summary>
    /// Adds a validator for the supplied hierarchy context and model type.
    /// </summary>
    public void AddValidator<TModel>(RuleTier tier, ISA isa, GS? gs, ST? st, IX12Validator<TModel> validator) where TModel : class;

    /// <summary>
    /// Gets validators matching the supplied hierarchy context and model type.
    /// </summary>
    public IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(RuleTier tier, ISA isa, GS? gs = null, ST? st = null) where TModel : class;
}
