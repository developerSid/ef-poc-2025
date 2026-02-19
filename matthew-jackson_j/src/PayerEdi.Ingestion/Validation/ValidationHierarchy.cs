using System.Text;

namespace PayerEdi.Ingestion.Validation;

/// <summary>
/// Mutable hierarchy context used to construct canonical validation lookup keys.
/// </summary>
public abstract class ValidationHierarchy : List<object>
{
    /// <summary>
    /// Selected validation policy tier for this hierarchy instance.
    /// </summary>
    public virtual RuleTier Tier { get; set; } = RuleTier.None;

    /// <summary>
    /// Selected rule scope dimensions for this hierarchy instance.
    /// </summary>
    public virtual RuleScope Scope { get; set; } = RuleScope.None;

    /// <summary>
    /// Gets a normalized key segment for the specified hierarchy index.
    /// </summary>
    protected virtual string GetKey(int index) => (0 <= index && index < Count) ? $"{this[index]?.ToString()}".Trim() : string.Empty;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not ValidationHierarchy target)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return string.Compare(GetCanonicalKey(), target.GetCanonicalKey(), StringComparison.OrdinalIgnoreCase) == 0;
    }

    /// <summary>
    /// Builds a canonical string key from hierarchy items in insertion order.
    /// </summary>
    public virtual string GetCanonicalKey()
    {
        var builder = new StringBuilder();

        for (int i = 0; i < Count; i++)
        {
            builder.Append(GetKey(i));
            builder.AppendLine();
        }

        return builder.ToString();
    }

    /// <inheritdoc />
    public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(GetCanonicalKey());

    //public static implicit operator X12ValidationHierarchyKey(ValidationHierarchy vh) => ///new(vh.Tier, vh.Scope, vh.GetCanonicalKey());
}
