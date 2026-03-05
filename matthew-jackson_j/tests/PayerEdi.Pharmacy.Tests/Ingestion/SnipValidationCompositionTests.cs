using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PayerEdi.Ingestion.Validation;
using PayerEdi.Ingestion.Validation.x12;
using PayerEdi.Ingestion.Validation.x12._837p;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

/// <summary>
/// Verifies DI composition for default ingestion and optional SNIP validation hook wiring.
/// </summary>
public sealed class SnipValidationCompositionTests
{
    [Fact]
    public void AddPharmacyServicesRegistersNoPreSaveHooksByDefault()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddLogging();
        services.AddPharmacyServices();

        using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = false,
            ValidateScopes = true
        });

        using var scope = provider.CreateScope();
        var hooks = scope.ServiceProvider.GetServices<IIngestionPreSaveHook>();
        Assert.Empty(hooks);
    }

    [Fact]
    public void AddSnipValidationPreSaveHookComposesWithX12CacheAndBindsOptions()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["SnipValidation:Enabled"] = "true",
                ["SnipValidation:Level"] = "SNIP2"
            })
            .Build();

        IServiceCollection services = new ServiceCollection();
        services.AddLogging();
        services.AddTS837PSnipValidation();
        services.AddSnipValidationPreSaveHook(configuration);

        using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });

        var cache = provider.GetRequiredService<IX12ValidatorCache>();
        var options = provider.GetRequiredService<IOptions<SnipValidationOptions>>().Value;
        using var scope = provider.CreateScope();
        var hooks = scope.ServiceProvider.GetServices<IIngestionPreSaveHook>().ToArray();

        Assert.NotNull(cache);
        Assert.Single(hooks);
        Assert.IsType<X12SnipValidationPreSaveHook>(hooks[0]);
        Assert.True(options.Enabled);
        Assert.Equal(RuleTier.SNIP2, options.Level);
    }
}
