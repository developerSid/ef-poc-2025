using Microsoft.Extensions.Options;

namespace PayerEdi.Ingestion.Tokens;

/// <summary>
/// Resolves and caches the EdiFabric serial token used for parsing operations.
/// </summary>
public sealed class EdiTokenProvider : IEdiTokenProvider
{
    private static readonly Lock _globalLock = new();
    private readonly EdiFabricOptions _options;
    private string? _cachedToken;
    private DateTimeOffset? _cachedAt;
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(24);

    /// <summary>
    /// Creates a token provider from configured EdiFabric options.
    /// </summary>
    public EdiTokenProvider(IOptions<EdiFabricOptions> options)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    /// <inheritdoc />
    public void InitToken() => GetToken();

    /// <inheritdoc />
    public string GetToken()
    {
        lock (_globalLock)
        {
            if (!string.IsNullOrWhiteSpace(_cachedToken) && _cachedAt.HasValue)
            {
                if (DateTimeOffset.UtcNow - _cachedAt.Value < TokenLifetime)
                    return _cachedToken;
            }

            _cachedToken = null;
            _cachedAt = null;

            var now = DateTimeOffset.UtcNow;
            var serialKey = _options.SerialKey;
            if (string.IsNullOrWhiteSpace(serialKey))
                throw new InvalidOperationException("Configuration key 'EdiFabric:SerialKey' is required.");

            SerialKey.Set(serialKey, false);

            var token = serialKey;
            if (string.IsNullOrWhiteSpace(token))
            {
                token = SerialKey.GetToken(serialKey, true);
                SerialKey.SetToken(token);
            }

            _cachedToken = token;
            _cachedAt = now;
            return token;
        }
    }
}
