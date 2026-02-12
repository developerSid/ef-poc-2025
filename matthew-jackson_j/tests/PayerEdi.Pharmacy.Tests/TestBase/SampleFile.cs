using System.Reflection;

namespace PayerEdi.Pharmacy.Tests.TestBase;

public static class SampleFile
{
    private static readonly Assembly Assembly = typeof(SampleFile).Assembly;

    public static Stream Open(string fileName)
    {
        var resourceName = FindResourceName(fileName);
        var stream = Assembly.GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            throw new InvalidOperationException($"Embedded sample '{fileName}' resolved to '{resourceName}', but the stream could not be opened.");
        }

        return stream;
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
