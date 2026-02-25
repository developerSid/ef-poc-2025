using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.Hipaa5010;
using PayerEdi.Pharmacy.Tests.Extensions;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

[Collection("db")]
/// <summary>
/// Verifies ingestion pre-save hook ordering and failure behavior.
/// </summary>
public sealed class Hipaa837pIngestionPreSaveHooksTests(DbFixture fixture)
{
    private const string TestBucket = "unit-tests-hooks";

    [Fact]
    public async Task IngestAsyncRunsHooksInRegistrationOrderBeforePersistence()
    {
        await fixture.ResetAsync();

        IServiceCollection services = new ServiceCollection();
        services.AddTestServices(fixture);
        services.AddSingleton<HookRecorder>();
        services.AddScoped<IIngestionPreSaveHook, FirstHook>();
        services.AddScoped<IIngestionPreSaveHook, SecondHook>();

        await using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });

        await using var scope = provider.CreateAsyncScope();
        var fileService = scope.ServiceProvider.GetRequiredService<TestFileService>();
        var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
        var recorder = scope.ServiceProvider.GetRequiredService<HookRecorder>();

        var key = "837p-sample.edi";
        await fileService.PushAsync(TestBucket, key, SampleFile.ReadAllBytes(key), TestContext.Current.CancellationToken);

        var items = await ingestion.IngestAsync(TestBucket, key, TestContext.Current.CancellationToken);
        var transaction = Assert.Single(items.OfType<TS837P>());
        Assert.True(transaction.Id > 0);
        Assert.Equal(["first:0", "second:0"], recorder.Calls);

        var dbContext = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        var persisted = await dbContext.Set<TS837P>().CountAsync(TestContext.Current.CancellationToken);
        Assert.Equal(1, persisted);
    }

    [Fact]
    public async Task IngestAsyncWhenHookThrowsDoesNotPersist()
    {
        await fixture.ResetAsync();

        IServiceCollection services = new ServiceCollection();
        services.AddTestServices(fixture);
        services.AddSingleton<HookRecorder>();
        services.AddScoped<IIngestionPreSaveHook, ThrowingHook>();

        await using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });

        await using var scope = provider.CreateAsyncScope();
        var fileService = scope.ServiceProvider.GetRequiredService<TestFileService>();
        var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
        var recorder = scope.ServiceProvider.GetRequiredService<HookRecorder>();

        var key = "837p-sample.edi";
        await fileService.PushAsync(TestBucket, key, SampleFile.ReadAllBytes(key), TestContext.Current.CancellationToken);

        await Assert.ThrowsAsync<InvalidOperationException>(() => ingestion.IngestAsync(TestBucket, key, TestContext.Current.CancellationToken));
        Assert.Equal(["throw:0"], recorder.Calls);

        var dbContext = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        var persisted = await dbContext.Set<TS837P>().CountAsync(TestContext.Current.CancellationToken);
        Assert.Equal(0, persisted);
    }

    private sealed class HookRecorder
    {
        public List<string> Calls { get; } = [];
    }

    private sealed class FirstHook(Hipaa837pDbContext dbContext, HookRecorder recorder) : IIngestionPreSaveHook
    {
        public Task OnBeforeSaveAsync(List<IEdiItem> items, CancellationToken cancellationToken = default)
        {
            recorder.Calls.Add($"first:{dbContext.Set<TS837P>().Count()}");
            return Task.CompletedTask;
        }
    }

    private sealed class SecondHook(Hipaa837pDbContext dbContext, HookRecorder recorder) : IIngestionPreSaveHook
    {
        public Task OnBeforeSaveAsync(List<IEdiItem> items, CancellationToken cancellationToken = default)
        {
            recorder.Calls.Add($"second:{dbContext.Set<TS837P>().Count()}");
            return Task.CompletedTask;
        }
    }

    private sealed class ThrowingHook(Hipaa837pDbContext dbContext, HookRecorder recorder) : IIngestionPreSaveHook
    {
        public Task OnBeforeSaveAsync(List<IEdiItem> items, CancellationToken cancellationToken = default)
        {
            recorder.Calls.Add($"throw:{dbContext.Set<TS837P>().Count()}");
            throw new InvalidOperationException("Hook failure for test.");
        }
    }
}
