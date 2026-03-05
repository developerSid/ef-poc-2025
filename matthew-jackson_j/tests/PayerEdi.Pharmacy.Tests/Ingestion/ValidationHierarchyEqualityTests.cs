using EdiFabric.Core.Model.Edi;
using PayerEdi.Ingestion.Validation;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

/// <summary>
/// Captures equality and hash-code expectations for mutable validation hierarchy keys.
/// </summary>
public sealed class ValidationHierarchyEqualityTests
{
    /// <summary>
    /// Equivalent key parts should compare equal regardless of letter casing.
    /// </summary>
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

    /// <summary>
    /// Leading/trailing whitespace is normalized by canonical key generation.
    /// </summary>
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

    /// <summary>
    /// Any differing normalized key part should break equality.
    /// </summary>
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

    /// <summary>
    /// Hierarchies with different item counts are not equivalent.
    /// </summary>
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

    /// <summary>
    /// Equality against null must return false.
    /// </summary>
    [Fact]
    public void EqualsReturnsFalseForNull()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.False(left.Equals(null));
    }

    /// <summary>
    /// Reference equality should always return true.
    /// </summary>
    [Fact]
    public void EqualsReturnsTrueForSameReference()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.True(left.Equals(left));
    }

    /// <summary>
    /// Hash-based collections should honor the same canonical equality contract.
    /// </summary>
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

    /// <summary>
    /// Demonstrates hash instability risk when mutating keys after collection insertion.
    /// </summary>
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

    /// <summary>
    /// Different runtime types are not considered equal.
    /// </summary>
    [Fact]
    public void EqualsReturnsFalseForDifferentType()
    {
        var left = new TwoPartValidationHierarchy
        {
            new FakeEdiItem("payerA", "claim001")
        };

        Assert.False(left.Equals("not-a-hierarchy"));
    }

    /// <summary>
    /// Key part ordering is significant in canonical key comparisons.
    /// </summary>
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

    /// <summary>
    /// Concrete hierarchy used to expose base comparison behavior in tests.
    /// </summary>
    private sealed class TwoPartValidationHierarchy : ValidationHierarchy
    {
    }

    /// <summary>
    /// Minimal EDI item stub that controls key material through ToString().
    /// </summary>
    private sealed class FakeEdiItem(string part1, string part2) : IEdiItem
    {
        private readonly string _part1 = part1;
        private readonly string _part2 = part2;

        public override string ToString() => $"{_part1}|{_part2}";
    }
}
