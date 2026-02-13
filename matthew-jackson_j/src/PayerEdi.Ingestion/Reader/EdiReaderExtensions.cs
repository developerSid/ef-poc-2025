
namespace PayerEdi.Ingestion.Reader;

public static class EdiReaderExtensions
{
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