namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Unit tests for in-memory file service contract behavior.
/// </summary>
public sealed class TestFileServiceTests
{
    [Fact]
    public async Task PushThenListThenPullReturnsExpectedPayload()
    {
        const string Bucket = "test-bucket";
        const string Key = "incoming/claim.edi";
        var expected = "ISA*00*          *00*          *ZZ*SENDER*ZZ*RECEIVER*"u8.ToArray();
        var sut = new TestFileService();

        await sut.PushAsync(Bucket, Key, expected, TestContext.Current.CancellationToken);

        var keys = await sut.ListAsync(Bucket, TestContext.Current.CancellationToken);
        Assert.Contains(Key, keys);

        var actual = await sut.PullAsync(Bucket, Key, TestContext.Current.CancellationToken);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task PushWhenSameBucketAndKeyTwiceOverwritesPayload()
    {
        const string Bucket = "test-bucket";
        const string Key = "incoming/claim.edi";
        var initial = "A"u8.ToArray();
        var replacement = "B"u8.ToArray();
        var sut = new TestFileService();

        await sut.PushAsync(Bucket, Key, initial, TestContext.Current.CancellationToken);
        await sut.PushAsync(Bucket, Key, replacement, TestContext.Current.CancellationToken);

        var actual = await sut.PullAsync(Bucket, Key, TestContext.Current.CancellationToken);
        Assert.Equal(replacement, actual);
    }

    [Fact]
    public async Task ListWhenBucketHasNoFilesReturnsEmpty()
    {
        const string Bucket = "empty-bucket";
        var sut = new TestFileService();

        var keys = await sut.ListAsync(Bucket, TestContext.Current.CancellationToken);
        Assert.Empty(keys);
    }

    [Fact]
    public async Task PullWhenKeyMissingThrowsFileNotFoundException()
    {
        const string Bucket = "test-bucket";
        const string Key = "incoming/missing.edi";
        var sut = new TestFileService();

        await Assert.ThrowsAsync<FileNotFoundException>(() => sut.PullAsync(Bucket, Key, TestContext.Current.CancellationToken));
    }
}
