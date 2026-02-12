namespace PayerEdi.Ingestion;

public sealed class EdiTokenProvider : IEdiTokenProvider
{
    private readonly object _locker = new();
    private string? _cachedToken;
    private DateTimeOffset? _cachedAt;
    private const string EnvVarName = "EDIFABRIC_SERIAL_KEY";
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(24);

    public void InitToken() => GetToken();

    public string GetToken()
    {
        lock (_locker)
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
