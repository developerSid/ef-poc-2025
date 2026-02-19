using EdiFabric.Core.Model.Edi;
using PayerEdi.Ingestion.Validation;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

public sealed class ValidationHierarchyEqualityTests
{
    [Fact]
    public void EqualsReturnsTrueForSameTwoPartKeysIgnoringCase()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payera", "claim001"),
            new FakeEdiItem("providerb", "line10")
        };

        var right = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("PAYERA", "CLAIM001"),
            new FakeEdiItem("PROVIDERB", "LINE10")
        };

        Assert.True(left.Equals(right));
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void EqualsReturnsTrueWhenKeysNeedTrimming()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem(" payerA", "claim001 ")
        };

        var right = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.True(left.Equals(right));
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void EqualsReturnsFalseWhenSecondPartDiffers()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        var right = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claimXYZ")
        };

        Assert.False(left.Equals(right));
    }

    [Fact]
    public void EqualsReturnsFalseWhenCountsDiffer()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        var right = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001"),
            new FakeEdiItem("providerB", "line10")
        };

        Assert.False(left.Equals(right));
    }

    [Fact]
    public void EqualsReturnsFalseForNull()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.False(left.Equals(null));
    }

    [Fact]
    public void EqualsReturnsTrueForSameReference()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.True(left.Equals(left));
    }

    [Fact]
    public void HashSetUsesEqualityContractForEquivalentHierarchies()
    {
        var first = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        var second = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("PAYERA", "CLAIM001")
        };

        var set = new HashSet<ValidationHierarchy>
        {
            first
        };

        Assert.True(set.Contains(second));
    }

    [Fact]
    public void HashSetLookupFailsAfterMutatingIndexedHierarchy()
    {
        var hierarchy = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        var set = new HashSet<ValidationHierarchy>
        {
            hierarchy
        };

        hierarchy[0] = new FakeEdiItem("payerA", "claimXYZ");

        Assert.False(set.Contains(hierarchy));
    }

    [Fact]
    public void EqualsReturnsFalseForDifferentType()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.False(left.Equals("not-a-hierarchy"));
    }

    [Fact]
    public void EqualsReturnsFalseWhenPartsAreReordered()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001"),
            new FakeEdiItem("providerB", "line10")
        };

        var right = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("providerB", "line10"),
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.False(left.Equals(right));
    }

    private sealed class TwoPartValidationHierarchy : ValidationHierarchy
    {
    }

    private sealed class FakeEdiItem(string part1, string part2) : IEdiItem
    {
        private readonly string _part1 = part1;
        private readonly string _part2 = part2;

        public override string ToString() => $"{_part1}|{_part2}";
    }
}
