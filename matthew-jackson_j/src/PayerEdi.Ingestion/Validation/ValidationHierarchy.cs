using System.Text;

namespace PayerEdi.Ingestion.Validation;

public abstract class ValidationHierarchy : List<object>
{
    public virtual RuleTier Tier { get; set; } = RuleTier.None;

    public virtual RuleScope Scope { get; set; } = RuleScope.None;

    protected virtual string GetKey(int index) => (0 <= index && index < Count) ? $"{this[index]?.ToString()}".Trim() : string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not ValidationHierarchy target)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return string.Compare(GetCanonicalKey(), target.GetCanonicalKey(), StringComparison.OrdinalIgnoreCase) == 0;
    }

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

    public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(GetCanonicalKey());

    //public static implicit operator X12ValidationHierarchyKey(ValidationHierarchy vh) => ///new(vh.Tier, vh.Scope, vh.GetCanonicalKey());
}
