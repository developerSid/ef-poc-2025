using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using X12EDI837.Ingestion.Infrastructure.FileSource;

namespace X12EDI837.Ingestion.Tests;

/// <summary>
/// Unit tests for LocalFileSource — uses a real temp directory on disk.
/// </summary>
public class LocalFileSourceTests : IDisposable
{
    private readonly string _tempDir;

    public LocalFileSourceTests()
    {
        // Create a fresh temp directory for each test
        _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose() => Directory.Delete(_tempDir, recursive: true);

    private LocalFileSource CreateSource(string? fileName = null) =>
        new(Options.Create(new FileSourceOptions
        {
            LocalPath = _tempDir,
            FileName  = fileName ?? string.Empty,
        }), NullLogger<LocalFileSource>.Instance);

    // -------------------------------------------------------------------------
    // ListFilesAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ListFilesAsync_NoFileName_ReturnsAllEdiFiles()
    {
        // Arrange
        File.WriteAllText(Path.Combine(_tempDir, "a.edi"), "ISA*");
        File.WriteAllText(Path.Combine(_tempDir, "b.edi"), "ISA*");
        File.WriteAllText(Path.Combine(_tempDir, "ignore.txt"), "not edi");

        var svc = CreateSource();

        // Act
        var files = (await svc.ListFilesAsync()).ToList();

        // Assert
        Assert.Equal(2, files.Count);
        Assert.Contains("a.edi", files);
        Assert.Contains("b.edi", files);
        Assert.DoesNotContain("ignore.txt", files);
    }

    [Fact]
    public async Task ListFilesAsync_WithFileName_ReturnsThatFileOnly()
    {
        // Arrange
        File.WriteAllText(Path.Combine(_tempDir, "a.edi"), "ISA*");
        File.WriteAllText(Path.Combine(_tempDir, "b.edi"), "ISA*");

        var svc = CreateSource(fileName: "a.edi");

        // Act
        var files = (await svc.ListFilesAsync()).ToList();

        // Assert
        Assert.Single(files);
        Assert.Equal("a.edi", files[0]);
    }

    [Fact]
    public async Task ListFilesAsync_EmptyDirectory_ReturnsEmptyList()
    {
        var svc   = CreateSource();
        var files = (await svc.ListFilesAsync()).ToList();
        Assert.Empty(files);
    }

    [Fact]
    public async Task ListFilesAsync_DirectoryNotFound_ThrowsDirectoryNotFoundException()
    {
        var svc = new LocalFileSource(
            Options.Create(new FileSourceOptions { LocalPath = "/nonexistent/path" }),
            NullLogger<LocalFileSource>.Instance);

        await Assert.ThrowsAsync<DirectoryNotFoundException>(
            () => svc.ListFilesAsync());
    }

    // -------------------------------------------------------------------------
    // OpenReadAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task OpenReadAsync_ExistingFile_ReturnsReadableStream()
    {
        // Arrange
        var content = "ISA*00*test~";
        File.WriteAllText(Path.Combine(_tempDir, "test.edi"), content);

        var svc = CreateSource();

        // Act
        await using var stream = await svc.OpenReadAsync("test.edi");
        using var reader = new StreamReader(stream);
        var result = await reader.ReadToEndAsync();

        // Assert
        Assert.Equal(content, result);
    }

    [Fact]
    public async Task OpenReadAsync_FileNotFound_ThrowsFileNotFoundException()
    {
        var svc = CreateSource();

        await Assert.ThrowsAsync<FileNotFoundException>(
            () => svc.OpenReadAsync("missing.edi"));
    }
}
