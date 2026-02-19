using EdiFabric.Core.Model.Edi.X12;
using System.Collections.Concurrent;

namespace PayerEdi.Ingestion.Validation.x12;

public class X12ValidatorCache : IX12ValidatorCache
{
    private readonly ConcurrentDictionary<X12ValidationHierarchyKey, object> _items = new();

    private static X12ValidationHierarchyKey GetKey<TModel>(RuleTier tier, ISA isa, GS? gs, ST? st) where TModel : class
    {
        X12ValidationHierarchy hierarchy = new()
        {
            Tier = tier,
            Scope = RuleScope.Partner | (gs is null ? RuleScope.None : RuleScope.Application) | (st is null ? RuleScope.None : RuleScope.Schema)
        };

        hierarchy.Add(isa);

        if (gs is not null)
            hierarchy.Add(gs);

        if (st is not null)
            hierarchy.Add(st);

        return new X12ValidationHierarchyKey(hierarchy.Tier, hierarchy.Scope, hierarchy.GetCanonicalKey(), typeof(TModel));
    }

    public void AddValidator<TModel>(RuleTier tier, ISA isa, GS? gs, ST? st, IX12Validator<TModel> validator) where TModel : class
    {
        var key = GetKey<TModel>(tier, isa, gs, st);
        var collection = _items.GetOrAdd(key, _ => new BlockingCollection<IX12Validator<TModel>>()) as BlockingCollection<IX12Validator<TModel>>;
        collection?.Add(validator);
    }

    public IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(RuleTier tier, ISA isa, GS? gs = null, ST? st = null) where TModel : class
    {
        var key = GetKey<TModel>(tier, isa, gs, st);
        _items.TryGetValue(key, out var validators);
        return [.. validators as BlockingCollection<IX12Validator<TModel>> ?? []];
    }
}