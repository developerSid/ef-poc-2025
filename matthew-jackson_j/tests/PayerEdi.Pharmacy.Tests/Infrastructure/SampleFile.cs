using System.Reflection;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Accessor for embedded EDI sample resources used by tests.
/// </summary>
public static class SampleFile
{
    private static readonly Assembly Assembly = typeof(SampleFile).Assembly;

    /// <summary>
    /// Reads an embedded sample file by filename suffix.
    /// </summary>
    public static byte[] ReadAllBytes(string fileName)
    {
        using var stream = Open(fileName);
        using var memory = new MemoryStream();
        stream.CopyTo(memory);
        return memory.ToArray();
    }

    /// <summary>
    /// Opens an embedded sample file stream by filename suffix.
    /// </summary>
    public static Stream Open(string fileName)
    {
        var resourceName = FindResourceName(fileName);
        return Assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Embedded sample '{fileName}' resolved to '{resourceName}', but the stream could not be opened.");
    }

    private static string FindResourceName(string fileName)
    {
        var normalized = fileName
            .Replace('\\', '.')
            .Replace('/', '.')
            .TrimStart('.');

        var names = Assembly.GetManifestResourceNames();
        var match = names.FirstOrDefault(name => name.EndsWith("." + normalized, StringComparison.OrdinalIgnoreCase));
        if (match is not null)
        {
            return match;
        }

        match = names.FirstOrDefault(name => name.EndsWith("." + fileName, StringComparison.OrdinalIgnoreCase));
        if (match is not null)
        {
            return match;
        }

        throw new InvalidOperationException($"Embedded sample '{fileName}' not found. Available: {string.Join(", ", names)}");
    }
}
