namespace PayerEdi.Ingestion.Tokens;

/// <summary>
/// Resolves and caches the EdiFabric serial token used for parsing operations.
/// </summary>
public sealed class EdiTokenProvider : IEdiTokenProvider
{
    private static readonly Lock _globalLock = new();
    private string? _cachedToken;
    private DateTimeOffset? _cachedAt;
    private const string EnvVarName = "EDIFABRIC_SERIAL_KEY";
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(24);

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

            var serialKey = Environment.GetEnvironmentVariable(EnvVarName, EnvironmentVariableTarget.Machine);
            SerialKey.Set(serialKey, false);

            var token = Environment.GetEnvironmentVariable(EnvVarName, EnvironmentVariableTarget.Machine);
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
