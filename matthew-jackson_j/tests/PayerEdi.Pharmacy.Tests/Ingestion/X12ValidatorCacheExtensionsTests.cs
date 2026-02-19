using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;
using PayerEdi.Ingestion.Validation;
using PayerEdi.Ingestion.Validation.x12;
using PayerEdi.Ingestion.Validation.x12._837p;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

public sealed class X12ValidatorCacheExtensionsTests
{
    [Fact]
    public void AddValidatorWithIsaOnlyStoresValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var validator = new TestValidator();

        cache.AddValidator<TestModel>(RuleTier.Tier1, isa, validator);

        var validators = cache.GetValidators<TestModel>(RuleTier.Tier1, isa, null, null);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Fact]
    public void AddValidatorWithIsaAndGsStoresValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var gs = CreateGs();
        var validator = new TestValidator();

        cache.AddValidator<TestModel>(RuleTier.Tier2, isa, gs, validator);

        var validators = cache.GetValidators<TestModel>(RuleTier.Tier2, isa, gs, null);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Fact]
    public void AddValidatorWithIsaAndStStoresValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var st = CreateSt();
        var validator = new TestValidator();

        cache.AddValidator<TestModel>(RuleTier.Tier2, isa, st, validator);

        var validators = cache.GetValidators<TestModel>(RuleTier.Tier2, isa, null, st);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Fact]
    public void AddValidatorWithIsaGsStStoresValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var gs = CreateGs();
        var st = CreateSt();
        var validator = new TestValidator();

        cache.AddValidator<TestModel>(RuleTier.Tier3, isa, gs, st, validator);

        var validators = cache.GetValidators<TestModel>(RuleTier.Tier3, isa, gs, st);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Fact]
    public void GetValidatorsIsaOnlyReturnsStoredValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var validator = new TestValidator();
        cache.AddValidator<TestModel>(RuleTier.Tier1, isa, null, null, validator);

        var validators = X12ValidatorCacheExtensions.GetValidators<TestModel>(cache, RuleTier.Tier1, isa);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Fact]
    public void GetValidatorsIsaAndGsReturnsStoredValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var gs = CreateGs();
        var validator = new TestValidator();
        cache.AddValidator<TestModel>(RuleTier.Tier2, isa, gs, null, validator);

        var validators = X12ValidatorCacheExtensions.GetValidators<TestModel>(cache, RuleTier.Tier2, isa, gs);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Fact]
    public void GetValidatorsIsaAndStReturnsStoredValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var st = CreateSt();
        var validator = new TestValidator();
        cache.AddValidator<TestModel>(RuleTier.Tier2, isa, null, st, validator);

        var validators = X12ValidatorCacheExtensions.GetValidators<TestModel>(cache, RuleTier.Tier2, isa, st);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Fact]
    public void GetValidatorsIsaGsStReturnsStoredValidator()
    {
        IX12ValidatorCache cache = new X12ValidatorCache();
        var isa = CreateIsa();
        var gs = CreateGs();
        var st = CreateSt();
        var validator = new TestValidator();
        cache.AddValidator<TestModel>(RuleTier.Tier3, isa, gs, st, validator);

        var validators = X12ValidatorCacheExtensions.GetValidators<TestModel>(cache, RuleTier.Tier3, isa, gs, st);
        Assert.Single(validators);
        Assert.Same(validator, validators[0]);
    }

    [Theory]
    [InlineData(RuleTier.SNIP1, typeof(TS837PSnip1Validator))]
    [InlineData(RuleTier.SNIP2, typeof(TS837PSnip2Validator))]
    [InlineData(RuleTier.SNIP3, typeof(TS837PSnip3Validator))]
    [InlineData(RuleTier.SNIP4, typeof(TS837PSnip4Validator))]
    public void AddTS837PSnipValidatorsRegistersExpectedTypePerTier(RuleTier tier, Type validatorType)
    {
        IX12ValidatorCache cache = new X12ValidatorCache();

        cache.AddTS837PSnipValidators();

        var validators = X12ValidatorCacheExtensions.GetValidators<TS837P>(cache, tier);
        Assert.Single(validators);
        Assert.IsType(validatorType, validators[0]);
    }

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
        ImplementationConventionPreference_03 = "005010X222A1"
    };

    private sealed class TestModel;

    private sealed class TestValidator : IX12Validator<TestModel>
    {
        public (bool, string?) Validate(ISA isa, GS gs, ST st, TestModel item) => (true, null);
    }
}
