using EdiFabric.Core.Model.Edi.X12;
using PayerEdi.Ingestion.Validation.x12._837p;

namespace PayerEdi.Ingestion.Validation.x12;

/// <summary>
/// Overloads for adding and resolving validators with common X12 scope combinations.
/// </summary>
public static class X12ValidatorCacheExtensions
{
    /// <summary>
    /// Registers the default built-in SNIP 1-4 validator chain for TS837P transactions.
    /// </summary>
    public static void AddTS837PSnipValidators(this IX12ValidatorCache cache)
    {
        ArgumentNullException.ThrowIfNull(cache);

        cache.AddValidator<TS837P>(RuleTier.SNIP1, new TS837PSnip1Validator());
        cache.AddValidator<TS837P>(RuleTier.SNIP2, new TS837PSnip2Validator());
        cache.AddValidator<TS837P>(RuleTier.SNIP3, new TS837PSnip3Validator());
        cache.AddValidator<TS837P>(RuleTier.SNIP4, new TS837PSnip4Validator());
    }

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, null, null, null, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, GS gs, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, null, gs, null, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ST st, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, null, null, st, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, GS gs, ST st, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, null, gs, st, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, null, null, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, gs, null, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, ST st, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, null, st, validator);

    public static void AddValidator<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs, ST st, IX12Validator<TModel> validator) where TModel : class
        => cache.AddValidator(tier, isa, gs, st, validator);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier) where TModel : class
        => cache.GetValidators<TModel>(tier, null, null, null);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, GS gs) where TModel : class
        => cache.GetValidators<TModel>(tier, null, gs, null);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ST st) where TModel : class
        => cache.GetValidators<TModel>(tier, null, null, st);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, GS gs, ST st) where TModel : class
        => cache.GetValidators<TModel>(tier, null, gs, st);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, null, null);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, gs, null);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, ST st) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, null, st);

    public static IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(this IX12ValidatorCache cache, RuleTier tier, ISA isa, GS gs, ST st) where TModel : class
        => cache.GetValidators<TModel>(tier, isa, gs, st);
}
