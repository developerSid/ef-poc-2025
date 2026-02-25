using EdiFabric.Templates.Hipaa5010;
using PayerEdi.Pharmacy.Tests.Extensions;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

[Collection("db")]
/// <summary>
/// Regression coverage for default ingestion flow without validation hooks/providers.
/// </summary>
public sealed class NonValidatedIngestionRegressionTests(DbFixture fixture)
{
    private const string TestBucket = "unit-tests-regression";

    [Fact]
    public async Task DefaultCompositionWithoutValidationHooksStillPersistsTs837p()
    {
        await fixture.ResetAsync();

        IServiceCollection services = new ServiceCollection();
        services.AddTestServices(fixture);

        await using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });

        await using var scope = provider.CreateAsyncScope();
        var hooks = scope.ServiceProvider.GetServices<IIngestionPreSaveHook>();
        Assert.Empty(hooks);

        var fileService = scope.ServiceProvider.GetRequiredService<TestFileService>();
        var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
        var key = "837p-sample.edi";
        await fileService.PushAsync(TestBucket, key, SampleFile.ReadAllBytes(key), TestContext.Current.CancellationToken);

        var items = await ingestion.IngestAsync(TestBucket, key, TestContext.Current.CancellationToken);
        var transaction = Assert.Single(items.OfType<TS837P>());
        Assert.True(transaction.Id > 0);

        var dbContext = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        var persisted = await dbContext.Set<TS837P>().CountAsync(TestContext.Current.CancellationToken);
        Assert.Equal(1, persisted);
    }
}
