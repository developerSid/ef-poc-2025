using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;
using PayerEdi.Ingestion.Validation;
using PayerEdi.Ingestion.Validation.x12;
using PayerEdi.Ingestion.Validation.x12._837p;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

/// <summary>
/// Verifies DI registration helpers seed expected TS837P SNIP validators.
/// </summary>
public sealed class TS837PSnipStartupExtensionsTests
{
    /// <summary>
    /// Ensures base startup registration resolves exactly one validator per SNIP tier (1-4).
    /// </summary>
    [Theory]
    [InlineData(RuleTier.SNIP1, typeof(TS837PSnip1Validator))]
    [InlineData(RuleTier.SNIP2, typeof(TS837PSnip2Validator))]
    [InlineData(RuleTier.SNIP3, typeof(TS837PSnip3Validator))]
    [InlineData(RuleTier.SNIP4, typeof(TS837PSnip4Validator))]
    public void AddTS837PSnipValidationSeedsCacheWithExpectedTypes(RuleTier tier, Type validatorType)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTS837PSnipValidation();

        using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });

        var cache = provider.GetRequiredService<IX12ValidatorCache>();
        var validators = X12ValidatorCacheExtensions.GetValidators<TS837P>(cache, tier);

        Assert.Single(validators);
        Assert.IsType(validatorType, validators[0]);
    }

    /// <summary>
    /// Ensures additional validator registrations compose with defaults instead of replacing them.
    /// </summary>
    [Fact]
    public void AddTS837PSnipValidationComposesWithAdditionalRegistration()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTS837PSnipValidation();
        services.AddX12ValidatorRegistration(cache => cache.AddValidator<TS837P>(RuleTier.SNIP1, new ExtraSnip1Validator()));

        using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });

        var cache = provider.GetRequiredService<IX12ValidatorCache>();
        var validators = X12ValidatorCacheExtensions.GetValidators<TS837P>(cache, RuleTier.SNIP1);
        Assert.Equal(2, validators.Count);
    }

    /// <summary>
    /// Extra validator used to verify additive registration semantics.
    /// </summary>
    private sealed class ExtraSnip1Validator : IX12Validator<TS837P>
    {
        public (bool, string?) Validate(ISA isa, GS? gs, ST st, TS837P item) => (true, null);
    }
}
