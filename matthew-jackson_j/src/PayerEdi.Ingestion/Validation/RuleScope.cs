namespace PayerEdi.Ingestion.Validation;

[Flags]
public enum RuleScope
{
    None = 0,
    Partner = 1,
    Application = 2,
    Schema = 4,
    PartnerApplication = Partner | Application,
    PartnerSchema = Partner | Schema,
    All = Partner | Application | Schema
}