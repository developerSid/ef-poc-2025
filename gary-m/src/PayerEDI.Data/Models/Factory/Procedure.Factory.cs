using EdiFabric.Templates.Hipaa5010;

namespace PayerEDI.Data.Models.Factory;

public static class ProcedureFactory
{
    extension(Procedure)
    {
        public static List<Procedure> New(TS837P claim) => claim
            .Loop2000A.SelectMany(provider => provider.Loop2000B)
            .SelectMany(subscriber =>
                (subscriber.Loop2300 ?? []).Concat(
                    (subscriber.Loop2000C ?? []).SelectMany(dependent => dependent.Loop2300 ?? [])
                )
            )
            .SelectMany(claimLoop => claimLoop.Loop2400)
            .Where(line => line.SV1_ProfessionalService is not null)
            .Select(line =>
            {
                var service = line.SV1_ProfessionalService;
                var procedure = service.CompositeMedicalProcedureIdentifier_01;
                var pointer = service.CompositeDiagnosisCodePointer_07;
                var date = line.AllDTP?.DTP_Date_ServiceDate;
                return new Procedure
                {
                    ServiceLineNumber = Value(line.LX_ServiceLineNumber?.AssignedNumber_01),
                    ProcedureIdQualifier = Value(procedure?.ProductorServiceIDQualifier_01),
                    ProcedureCode = Value(procedure?.ProcedureCode_02),
                    ProductServiceId = Value(procedure?.ProductServiceID_08),
                    Modifier1 = Value(procedure?.ProcedureModifier_03),
                    Modifier2 = Value(procedure?.ProcedureModifier_04),
                    Modifier3 = Value(procedure?.ProcedureModifier_05),
                    Modifier4 = Value(procedure?.ProcedureModifier_06),
                    Description = Value(procedure?.Description_07),
                    ChargeAmount = Value(service.LineItemChargeAmount_02),
                    UnitOrBasisForMeasurementCode = Value(service.UnitorBasisforMeasurementCode_03),
                    ServiceUnitCount = Value(service.ServiceUnitCount_04),
                    PlaceOfServiceCode = Value(service.PlaceofServiceCode_05),
                    ServiceTypeCode = Value(service.ServiceTypeCode_06),
                    DiagnosisPointer1 = Value(pointer?.DiagnosisCodePointer_01),
                    DiagnosisPointer2 = Value(pointer?.DiagnosisCodePointer_02),
                    DiagnosisPointer3 = Value(pointer?.DiagnosisCodePointer_03),
                    DiagnosisPointer4 = Value(pointer?.DiagnosisCodePointer_04),
                    ServiceDateQualifier = Value(date?.DateTimeQualifier_01),
                    ServiceDateFormatQualifier = Value(date?.DateTimePeriodFormatQualifier_02),
                    ServiceDate = Value(date?.DateTimePeriod_03),
                    EmergencyIndicator = Value(service.EmergencyIndicator_09),
                    MultipleProcedureCode = Value(service.MultipleProcedureCode_10),
                    EpsdtIndicator = Value(service.EPSDTIndicator_11),
                    FamilyPlanningIndicator = Value(service.FamilyPlanningIndicator_12),
                    ReviewCode = Value(service.ReviewCode_13),
                    CopayStatusCode = Value(service.CoPayStatusCode_15),
                    ReferenceIdentification = Value(service.ReferenceIdentification_17),
                    MonetaryAmount = Value(service.MonetaryAmount_08),
                    NationalOrLocalAssignedReviewValue = Value(service.NationalorLocalAssignedReviewValue_14),
                    HealthCareProfessionalShortageAreaCode = Value(service.HealthCareProfessionalShortageAreaCode_16),
                    PostalCode = Value(service.PostalCode_18),
                    SecondaryMonetaryAmount = Value(service.MonetaryAmount_19),
                    LevelOfCareCode = Value(service.LevelofCareCode_20),
                    ProviderAgreementCode = Value(service.ProviderAgreementCode_21)
                };
            })
            .ToList();

        public static List<Procedure> New(TS837D claim) => claim
            .Loop2000A.SelectMany(provider => provider.Loop2000B)
            .SelectMany(subscriber =>
                (subscriber.Loop2300 ?? []).Concat(
                    (subscriber.Loop2000C ?? []).SelectMany(dependent => dependent.Loop2300 ?? [])
                )
            )
            .SelectMany(claimLoop => claimLoop.Loop2400)
            .Where(line => line.SV3_DentalService is not null)
            .Select(line =>
            {
                var service = line.SV3_DentalService;
                var procedure = service.CompositeMedicalProcedureIdentifier_01;
                var pointer = service.CompositeDiagnosisCodePointer_11;
                var oral = service.OralCavityDesignation_04;
                var date = line.AllDTP?.DTP_Date_ServiceDate;
                return new Procedure
                {
                    ServiceLineNumber = Value(line.LX_ServiceLineNumber?.AssignedNumber_01),
                    ProcedureIdQualifier = Value(procedure?.ProductorServiceIDQualifier_01),
                    ProcedureCode = Value(procedure?.ProcedureCode_02),
                    ProductServiceId = Value(procedure?.ProductServiceID_08),
                    Modifier1 = Value(procedure?.ProcedureModifier_03),
                    Modifier2 = Value(procedure?.ProcedureModifier_04),
                    Modifier3 = Value(procedure?.ProcedureModifier_05),
                    Modifier4 = Value(procedure?.ProcedureModifier_06),
                    Description = Value(procedure?.Description_07),
                    ChargeAmount = Value(service.LineItemChargeAmount_02),
                    PlaceOfServiceCode = Value(service.PlaceofServiceCode_03),
                    DiagnosisPointer1 = Value(pointer?.DiagnosisCodePointer_01),
                    DiagnosisPointer2 = Value(pointer?.DiagnosisCodePointer_02),
                    DiagnosisPointer3 = Value(pointer?.DiagnosisCodePointer_03),
                    DiagnosisPointer4 = Value(pointer?.DiagnosisCodePointer_04),
                    ServiceDateQualifier = Value(date?.DateTimeQualifier_01),
                    ServiceDateFormatQualifier = Value(date?.DateTimePeriodFormatQualifier_02),
                    ServiceDate = Value(date?.DateTimePeriod_03),
                    CopayStatusCode = Value(service.CopayStatusCode_08),
                    ProviderAgreementCode = Value(service.ProviderAgreementCode_09),
                    OralCavityDesignation1 = Value(oral?.OralCavityDesignationCode_01),
                    OralCavityDesignation2 = Value(oral?.OralCavityDesignationCode_02),
                    OralCavityDesignation3 = Value(oral?.OralCavityDesignationCode_03),
                    OralCavityDesignation4 = Value(oral?.OralCavityDesignationCode_04),
                    OralCavityDesignation5 = Value(oral?.OralCavityDesignationCode_05),
                    ProsthesisCrownOrInlayCode = Value(service.ProsthesisCrownorInlayCode_05),
                    ProcedureCount = Value(service.ProcedureCount_06),
                    YesNoConditionOrResponseCode = Value(service.YesNoConditionorResponseCode_10)
                };
            })
            .ToList();
    }

    private static string? Value(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
