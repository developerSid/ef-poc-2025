using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace X12EDI837.Ingestion.Infrastructure.FileSource;

/// <summary>
/// Reads EDI files from the local filesystem.
/// </summary>
public sealed class LocalFileSource : IFileSource
{
    private readonly FileSourceOptions _opts;
    private readonly ILogger<LocalFileSource> _logger;

    public LocalFileSource(IOptions<FileSourceOptions> opts, ILogger<LocalFileSource> logger)
    {
        _opts = opts.Value;
        _logger = logger;
    }

  
    public Task<IEnumerable<string>> ListFilesAsync(CancellationToken ct = default)
    {
        var dir = Path.GetFullPath(_opts.LocalPath);

        if (!Directory.Exists(dir))
            throw new DirectoryNotFoundException($"LocalFileSource: directory not found → {dir}");

        // If a specific file is configured, return just that; otherwise return all .edi files.
        IEnumerable<string> files = string.IsNullOrWhiteSpace(_opts.FileName)
            ? Directory.GetFiles(dir, "*.edi").Select(f => Path.GetFileName(f)!)
            : new[] { _opts.FileName };

        _logger.LogInformation("LocalFileSource: found {Count} file(s) in {Dir}", files.Count(), dir);
        return Task.FromResult(files);
    }

 
    public Task<Stream> OpenReadAsync(string fileName, CancellationToken ct = default)
    {
        var fullPath = Path.Combine(Path.GetFullPath(_opts.LocalPath), fileName);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"LocalFileSource: file not found → {fullPath}");

        _logger.LogInformation("LocalFileSource: opening {File}", fullPath);
        Stream stream = File.OpenRead(fullPath);
        return Task.FromResult(stream);
    }
}
