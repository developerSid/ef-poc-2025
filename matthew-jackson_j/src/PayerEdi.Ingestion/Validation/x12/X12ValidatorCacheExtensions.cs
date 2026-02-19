using EdiFabric.Core.Model.Edi.X12;

namespace PayerEdi.Ingestion.Validation.x12;

public static class X12ValidatorCacheExtensions
{
    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, null, null, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, gs, null, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, ST st, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, null, st, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs, ST st, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, gs, st, validator);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, null, null);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, gs, null);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, ST st) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, null, st);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs, ST st) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, gs, st);
}
