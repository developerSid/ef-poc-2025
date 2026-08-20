using System.Xml.Serialization;
using PayerEDI.Data.Helpers;

namespace PayerEDI.Tests.Helpers;

public class XmlExtensionsTests
{
    [XmlRoot("TestItem")]
    public class TestItem
    {
        public string? Name { get; set; }
        public int Value { get; set; }
    }

    [Fact]
    public void ToXml_SerializesObjectToXmlStringWithoutDeclaration()
    {
        var item = new TestItem { Name = "Sample", Value = 42 };

        var xml = item.ToXml();

        Assert.NotNull(xml);
        Assert.DoesNotContain("<?xml", xml);
        Assert.Contains("<TestItem", xml);
        Assert.Contains("<Name>Sample</Name>", xml);
        Assert.Contains("<Value>42</Value>", xml);
    }

    [Fact]
    public void ToXml_ReturnsEmptyString_WhenObjectIsNull()
    {
        TestItem? item = null;

        var xml = item.ToXml();

        Assert.Equal(string.Empty, xml);
    }
}
