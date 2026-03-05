using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using PayerEdi.Ingestion.Validation;
using PayerEdi.Ingestion.Validation.x12;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

/// <summary>
/// Unit tests for SNIP pre-save hook behavior and tier selection.
/// </summary>
public sealed class X12SnipValidationPreSaveHookTests
{
    [Fact]
    public async Task OnBeforeSaveAsyncWhenDisabledSkipsValidation()
    {
        var cache = new TrackingValidatorCache();
        var hook = CreateHook(cache, new SnipValidationOptions { Enabled = false, Level = RuleTier.SNIP4 });

        await hook.OnBeforeSaveAsync(CreateValidItems());

        Assert.Empty(cache.RequestedTiers);
    }

    [Fact]
    public async Task OnBeforeSaveAsyncWhenNoTs837pItemsIsNoOp()
    {
        var cache = new TrackingValidatorCache();
        var hook = CreateHook(cache, new SnipValidationOptions { Enabled = true, Level = RuleTier.SNIP4 });
        List<IEdiItem> items = [CreateIsa(), CreateGs()];

        await hook.OnBeforeSaveAsync(items);

        Assert.Empty(cache.RequestedTiers);
    }

    [Fact]
    public async Task OnBeforeSaveAsyncWhenConfiguredLevelIsOutOfRangeThrows()
    {
        var cache = new TrackingValidatorCache();
        var hook = CreateHook(cache, new SnipValidationOptions { Enabled = true, Level = RuleTier.SNIP5 });

        await Assert.ThrowsAsync<InvalidOperationException>(() => hook.OnBeforeSaveAsync(CreateValidItems()));
    }

    [Fact]
    public async Task OnBeforeSaveAsyncWhenIsaMissingThrows()
    {
        var cache = new TrackingValidatorCache();
        var hook = CreateHook(cache, new SnipValidationOptions { Enabled = true, Level = RuleTier.SNIP1 });
        List<IEdiItem> items = [new TS837P { ST = CreateSt() }];

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => hook.OnBeforeSaveAsync(items));
        Assert.Contains("ISA", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task OnBeforeSaveAsyncWhenStMissingThrows()
    {
        var cache = new TrackingValidatorCache();
        var hook = CreateHook(cache, new SnipValidationOptions { Enabled = true, Level = RuleTier.SNIP1 });
        List<IEdiItem> items = [CreateIsa(), new TS837P()];

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => hook.OnBeforeSaveAsync(items));
        Assert.Contains("ST", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Theory]
    [InlineData(RuleTier.SNIP2, 2)]
    [InlineData(RuleTier.SNIP4, 4)]
    public async Task OnBeforeSaveAsyncRunsValidatorsThroughConfiguredLevel(RuleTier level, int expectedTierCount)
    {
        var cache = new TrackingValidatorCache();
        var executed = new List<RuleTier>();
        cache.Register(RuleTier.SNIP1, new RecordingValidator(RuleTier.SNIP1, executed));
        cache.Register(RuleTier.SNIP2, new RecordingValidator(RuleTier.SNIP2, executed));
        cache.Register(RuleTier.SNIP3, new RecordingValidator(RuleTier.SNIP3, executed));
        cache.Register(RuleTier.SNIP4, new RecordingValidator(RuleTier.SNIP4, executed));

        var hook = CreateHook(cache, new SnipValidationOptions { Enabled = true, Level = level });

        await hook.OnBeforeSaveAsync(CreateValidItems());

        var expectedTiers = Enumerable.Range(1, expectedTierCount).Select(x => (RuleTier)x).ToArray();
        Assert.Equal(expectedTiers, cache.RequestedTiers);
        Assert.Equal(expectedTiers, executed);
    }

    private static X12SnipValidationPreSaveHook CreateHook(IX12ValidatorCache cache, SnipValidationOptions options) =>
        new(NullLogger<X12SnipValidationPreSaveHook>.Instance, cache, Options.Create(options));

    private static List<IEdiItem> CreateValidItems() => [CreateIsa(), CreateGs(), new TS837P { ST = CreateSt() }];

    private static ISA CreateIsa() => new()
    {
        SenderIDQualifier_5 = "ZZ",
        InterchangeSenderID_6 = "SENDER",
        ReceiverIDQualifier_7 = "ZZ",
        InterchangeReceiverID_8 = "RECEIVER"
    };

    private static GS CreateGs() => new()
    {
        SenderIDCode_2 = "APP-SENDER",
        ReceiverIDCode_3 = "APP-RECEIVER",
        VersionAndRelease_8 = "005010X222A1"
    };

    private static ST CreateSt() => new()
    {
        TransactionSetIdentifierCode_01 = "837",
        TransactionSetControlNumber_02 = "0001",
        ImplementationConventionPreference_03 = "005010X222A1"
    };

    private sealed class TrackingValidatorCache : IX12ValidatorCache
    {
        private readonly Dictionary<RuleTier, IReadOnlyList<IX12Validator<TS837P>>> _validators = new();
        public List<RuleTier> RequestedTiers { get; } = [];

        public void Register(RuleTier tier, params IX12Validator<TS837P>[] validators)
            => _validators[tier] = validators;

        public void AddValidator<TModel>(RuleTier tier, ISA? isa, GS? gs, ST? st, IX12Validator<TModel> validator) where TModel : class
            => throw new NotSupportedException("AddValidator is not used by these tests.");

        public IReadOnlyList<IX12Validator<TModel>> GetValidators<TModel>(RuleTier tier, ISA? isa, GS? gs = null, ST? st = null) where TModel : class
        {
            RequestedTiers.Add(tier);

            if (typeof(TModel) != typeof(TS837P))
                return [];

            if (!_validators.TryGetValue(tier, out var validators))
                return [];

            return (IReadOnlyList<IX12Validator<TModel>>)validators;
        }
    }

    private sealed class RecordingValidator(RuleTier tier, List<RuleTier> executed) : IX12Validator<TS837P>
    {
        public (bool, string?) Validate(ISA isa, GS? gs, ST st, TS837P item)
        {
            executed.Add(tier);
            return (true, null);
        }
    }
}
