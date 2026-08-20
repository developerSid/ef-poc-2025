using System.Xml;
using System.Xml.Serialization;

namespace PayerEDI.Data.Helpers;

public static class XmlExtensions
{
    private static readonly XmlWriterSettings DefaultSettings = new()
    {
        Indent = true,
        OmitXmlDeclaration = true,
    };

    public static string ToXml<T>(this T value, XmlWriterSettings? settings = null)
    {
        if (value is null)
        {
            return string.Empty;
        }

        var serializer = new XmlSerializer(value.GetType());
        using var stringWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(stringWriter, settings ?? DefaultSettings);
        serializer.Serialize(xmlWriter, value);

        return stringWriter.ToString();
    }
}
