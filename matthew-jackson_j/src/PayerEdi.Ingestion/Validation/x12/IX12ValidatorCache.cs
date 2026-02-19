using EdiFabric.Core.Model.Edi.X12;

namespace PayerEdi.Ingestion.Validation.x12;

public interface IX12ValidatorCache
{
    public void AddValidator<TModel>(RuleTier tier, ISA isa, GS? gs, ST? st, IX12Validator<TModel> validator) where TModel : class;

    public IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(RuleTier tier, ISA isa, GS? gs = null, ST? st = null) where TModel : class;
}
