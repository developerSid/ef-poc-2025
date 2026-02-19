
namespace PayerEdi.Ingestion.Reader;

/// <summary>
/// Convenience helpers for consuming <see cref="IEdiReader"/> instances.
/// </summary>
public static class EdiReaderExtensions
{
    /// <summary>
    /// Buffers all parsed EDI items from the reader into memory.
    /// </summary>
    public static List<IEdiItem> ReadAll(this IEdiReader reader)
    {
        var values = new List<IEdiItem>();
        IEdiItem? value;

        do
        {
            value = reader.Read();

            if (value != null)
                values.Add(value);

        } while (value != null);

        return values;
    }
}
