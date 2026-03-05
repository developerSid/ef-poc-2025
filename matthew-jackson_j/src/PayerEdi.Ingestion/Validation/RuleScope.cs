namespace PayerEdi.Ingestion.Validation;

/// <summary>
/// Defines the X12 validation context scope used for rule lookup and execution.
/// </summary>
/// <remarks>
/// This is a flags enum and values may be combined.
/// Typical X12 progression is <see cref="Partner"/> (ISA) -> <see cref="Application"/> (GS) -> <see cref="Schema"/> (ST)
/// as additional envelope context is available.
/// </remarks>
[Flags]
public enum RuleScope
{
    /// <summary>No scope selected.</summary>
    None = 0,
    /// <summary>X12 interchange partner scope (ISA-level context).</summary>
    Partner = 1,
    /// <summary>X12 functional-group/application scope (GS-level context).</summary>
    Application = 2,
    /// <summary>X12 transaction/schema scope (ST-level context).</summary>
    Schema = 4,
    /// <summary>Combined partner and application scope.</summary>
    PartnerApplication = Partner | Application,
    /// <summary>Combined partner and schema scope.</summary>
    PartnerSchema = Partner | Schema,
    /// <summary>All scopes combined.</summary>
    All = Partner | Application | Schema
}
