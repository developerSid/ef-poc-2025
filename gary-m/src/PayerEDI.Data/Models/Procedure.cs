namespace PayerEDI.Data.Models;

/// <summary>Common service-line data from an 837P SV1 or 837D SV3 loop.</summary>
public record Procedure
{
    public string? ServiceLineNumber { get; init; }
    public string? ProcedureIdQualifier { get; init; }
    public string? ProcedureCode { get; init; }
    public string? ProductServiceId { get; init; }
    public string? Modifier1 { get; init; }
    public string? Modifier2 { get; init; }
    public string? Modifier3 { get; init; }
    public string? Modifier4 { get; init; }
    public string? Description { get; init; }
    public string? ChargeAmount { get; init; }
    public string? UnitOrBasisForMeasurementCode { get; init; }
    public string? ServiceUnitCount { get; init; }
    public string? PlaceOfServiceCode { get; init; }
    public string? ServiceTypeCode { get; init; }
    public string? DiagnosisPointer1 { get; init; }
    public string? DiagnosisPointer2 { get; init; }
    public string? DiagnosisPointer3 { get; init; }
    public string? DiagnosisPointer4 { get; init; }
    public string? ServiceDateQualifier { get; init; }
    public string? ServiceDateFormatQualifier { get; init; }
    public string? ServiceDate { get; init; }
    public string? EmergencyIndicator { get; init; }
    public string? MultipleProcedureCode { get; init; }
    public string? EpsdtIndicator { get; init; }
    public string? FamilyPlanningIndicator { get; init; }
    public string? ReviewCode { get; init; }
    public string? CopayStatusCode { get; init; }
    public string? ProviderAgreementCode { get; init; }
    public string? YesNoConditionOrResponseCode { get; init; }
    public string? ReferenceIdentification { get; init; }
    public string? MonetaryAmount { get; init; }
    public string? NationalOrLocalAssignedReviewValue { get; init; }
    public string? HealthCareProfessionalShortageAreaCode { get; init; }
    public string? PostalCode { get; init; }
    public string? SecondaryMonetaryAmount { get; init; }
    public string? LevelOfCareCode { get; init; }
    public string? OralCavityDesignation1 { get; init; }
    public string? OralCavityDesignation2 { get; init; }
    public string? OralCavityDesignation3 { get; init; }
    public string? OralCavityDesignation4 { get; init; }
    public string? OralCavityDesignation5 { get; init; }
    public string? ProsthesisCrownOrInlayCode { get; init; }
    public string? ProcedureCount { get; init; }
}
