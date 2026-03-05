using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayerEdi.Pharmacy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_REF_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_REF_837D_2Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_REF_837D_5Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_REF_837D_8Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_REF_837I_3Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_REF_837I_4Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_REF_837I_5Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310A_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310A_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310B_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310B_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310C_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310C_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310D_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310D_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310E_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310E_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2310F_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330A_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330A_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330C_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330C_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330D_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330D_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330E_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330E_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330F_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330F_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330G_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330G_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330H_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330H_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2330I_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420A_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420A_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420B_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420B_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420C_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420C_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420D_837DId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2420D_837IId",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REF_OtherPayerReferralNumber_2_All_REF_837D_2Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REF_PeerReviewOrganization_ReferenceIdentifier_04Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id",
                table: "REF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2300_837DId",
                table: "PWK",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2300_837IId",
                table: "PWK",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2400_837IId",
                table: "PWK",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id",
                table: "PWK",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_1000A_837DId",
                table: "PER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_1000A_837IId",
                table: "PER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2010AA_837DId",
                table: "PER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2010AA_837IId",
                table: "PER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_NTE_837IId",
                table: "NTE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2300_837DId",
                table: "NTE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2300_837DId",
                table: "K3",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2300_837IId",
                table: "K3",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2400_837DId",
                table: "K3",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "All_HI_837IId",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_All_HI_837IId",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_All_HI_837IId",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_All_HI_837IId",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_All_HI_837IId",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_Patient_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_All_HI_837IId",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_All_HI_837IId",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HI_ValueInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id",
                table: "CLM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CLM_ClaimInformation_2_RelatedCausesInformation_11Id",
                table: "CLM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id",
                table: "CLM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CLM_ClaimInformation_3_RelatedCausesInformation_11Id",
                table: "CLM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2320_837DId",
                table: "CAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2320_837IId",
                table: "CAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2430_837DId",
                table: "CAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loop_2430_837IId",
                table: "CAS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "All_AMT_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMT_CoordinationofBenefits_COB_PayerPaidAmountId = table.Column<int>(type: "int", nullable: true),
                    AMT_RemainingPatientLiabilityId = table.Column<int>(type: "int", nullable: true),
                    AMT_CoordinationofBenefits_COB_TotalNon_AmountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_AMT_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_AMT_837D_AMT_AMT_CoordinationofBenefits_COB_PayerPaidAmountId",
                        column: x => x.AMT_CoordinationofBenefits_COB_PayerPaidAmountId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_AMT_837D_AMT_AMT_CoordinationofBenefits_COB_TotalNon_AmountId",
                        column: x => x.AMT_CoordinationofBenefits_COB_TotalNon_AmountId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_AMT_837D_AMT_AMT_RemainingPatientLiabilityId",
                        column: x => x.AMT_RemainingPatientLiabilityId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_AMT_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMT_ServiceTaxAmountId = table.Column<int>(type: "int", nullable: true),
                    AMT_FacilityTaxAmountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_AMT_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_AMT_837I_AMT_AMT_FacilityTaxAmountId",
                        column: x => x.AMT_FacilityTaxAmountId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_AMT_837I_AMT_AMT_ServiceTaxAmountId",
                        column: x => x.AMT_ServiceTaxAmountId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_AMT_837I_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMT_CoordinationofBenefits_COB_PayerPaidAmountId = table.Column<int>(type: "int", nullable: true),
                    AMT_RemainingPatientLiabilityId = table.Column<int>(type: "int", nullable: true),
                    AMT_CoordinationofBenefits_COB_TotalNon_AmountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_AMT_837I_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_AMT_837I_2_AMT_AMT_CoordinationofBenefits_COB_PayerPaidAmountId",
                        column: x => x.AMT_CoordinationofBenefits_COB_PayerPaidAmountId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_AMT_837I_2_AMT_AMT_CoordinationofBenefits_COB_TotalNon_AmountId",
                        column: x => x.AMT_CoordinationofBenefits_COB_TotalNon_AmountId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_AMT_837I_2_AMT_AMT_RemainingPatientLiabilityId",
                        column: x => x.AMT_RemainingPatientLiabilityId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_DTP_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTP_Date_ServiceDateId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_PriorPlacementId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_AppliancePlacementId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_ReplacementId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_TreatmentStartId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_TreatmentCompletionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_DTP_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_DTP_DTP_Date_AppliancePlacementId",
                        column: x => x.DTP_Date_AppliancePlacementId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_DTP_DTP_Date_PriorPlacementId",
                        column: x => x.DTP_Date_PriorPlacementId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_DTP_DTP_Date_ReplacementId",
                        column: x => x.DTP_Date_ReplacementId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_DTP_DTP_Date_ServiceDateId",
                        column: x => x.DTP_Date_ServiceDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_DTP_DTP_Date_TreatmentCompletionId",
                        column: x => x.DTP_Date_TreatmentCompletionId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_DTP_DTP_Date_TreatmentStartId",
                        column: x => x.DTP_Date_TreatmentStartId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_DTP_837D_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTP_Date_AccidentId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_AppliancePlacementId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_ServiceDateId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_RepricerReceivedDateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_DTP_837D_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_2_DTP_DTP_Date_AccidentId",
                        column: x => x.DTP_Date_AccidentId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_2_DTP_DTP_Date_AppliancePlacementId",
                        column: x => x.DTP_Date_AppliancePlacementId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_2_DTP_DTP_Date_RepricerReceivedDateId",
                        column: x => x.DTP_Date_RepricerReceivedDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837D_2_DTP_DTP_Date_ServiceDateId",
                        column: x => x.DTP_Date_ServiceDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_DTP_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTP_DischargeHourId = table.Column<int>(type: "int", nullable: true),
                    DTP_StatementDatesId = table.Column<int>(type: "int", nullable: true),
                    DTP_AdmissionDate_HourId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_RepricerReceivedDateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_DTP_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_DTP_837I_DTP_DTP_AdmissionDate_HourId",
                        column: x => x.DTP_AdmissionDate_HourId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837I_DTP_DTP_Date_RepricerReceivedDateId",
                        column: x => x.DTP_Date_RepricerReceivedDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837I_DTP_DTP_DischargeHourId",
                        column: x => x.DTP_DischargeHourId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_DTP_837I_DTP_DTP_StatementDatesId",
                        column: x => x.DTP_StatementDatesId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_HI_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HI_PrincipalDiagnosisId = table.Column<int>(type: "int", nullable: true),
                    HI_AdmittingDiagnosisId = table.Column<int>(type: "int", nullable: true),
                    HI_Patient_ReasonForVisitId = table.Column<int>(type: "int", nullable: true),
                    HI_ExternalCauseofInjuryId = table.Column<int>(type: "int", nullable: true),
                    HI_DiagnosisRelatedGroup_DRG_InformationId = table.Column<int>(type: "int", nullable: true),
                    HI_PrincipalProcedureInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_HI_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_HI_837I_HI_HI_AdmittingDiagnosisId",
                        column: x => x.HI_AdmittingDiagnosisId,
                        principalTable: "HI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_HI_837I_HI_HI_DiagnosisRelatedGroup_DRG_InformationId",
                        column: x => x.HI_DiagnosisRelatedGroup_DRG_InformationId,
                        principalTable: "HI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_HI_837I_HI_HI_ExternalCauseofInjuryId",
                        column: x => x.HI_ExternalCauseofInjuryId,
                        principalTable: "HI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_HI_837I_HI_HI_Patient_ReasonForVisitId",
                        column: x => x.HI_Patient_ReasonForVisitId,
                        principalTable: "HI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_HI_837I_HI_HI_PrincipalDiagnosisId",
                        column: x => x.HI_PrincipalDiagnosisId,
                        principalTable: "HI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_HI_837I_HI_HI_PrincipalProcedureInformationId",
                        column: x => x.HI_PrincipalProcedureInformationId,
                        principalTable: "HI",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NTE_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NTE_BillingNoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NTE_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NTE_837I_NTE_NTE_BillingNoteId",
                        column: x => x.NTE_BillingNoteId,
                        principalTable: "NTE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_OtherPayerPriorAuthorizationNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_OtherPayerReferralNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_OtherPayerClaimAdjustmentIndicatorId = table.Column<int>(type: "int", nullable: true),
                    REF_OtherPayerPredeterminationIdentificationId = table.Column<int>(type: "int", nullable: true),
                    REF_OtherPayerClaimControlNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_REF_REF_OtherPayerClaimAdjustmentIndicatorId",
                        column: x => x.REF_OtherPayerClaimAdjustmentIndicatorId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_REF_REF_OtherPayerClaimControlNumberId",
                        column: x => x.REF_OtherPayerClaimControlNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_REF_REF_OtherPayerPredeterminationIdentificationId",
                        column: x => x.REF_OtherPayerPredeterminationIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_REF_REF_OtherPayerPriorAuthorizationNumberId",
                        column: x => x.REF_OtherPayerPriorAuthorizationNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_REF_REF_OtherPayerReferralNumberId",
                        column: x => x.REF_OtherPayerReferralNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_LineItemControlNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_RepricedClaimNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_AdjustedRepricedClaimNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_2_REF_REF_AdjustedRepricedClaimNumberId",
                        column: x => x.REF_AdjustedRepricedClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_2_REF_REF_LineItemControlNumberId",
                        column: x => x.REF_LineItemControlNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_2_REF_REF_RepricedClaimNumberId",
                        column: x => x.REF_RepricedClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D_3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_Pay_ToPlanSecondaryIdentificationId = table.Column<int>(type: "int", nullable: true),
                    REF_Pay_ToPlanTaxIdentificationNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D_3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_3_REF_REF_Pay_ToPlanSecondaryIdentificationId",
                        column: x => x.REF_Pay_ToPlanSecondaryIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_3_REF_REF_Pay_ToPlanTaxIdentificationNumberId",
                        column: x => x.REF_Pay_ToPlanTaxIdentificationNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D_4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_SubscriberSecondaryIdentificationId = table.Column<int>(type: "int", nullable: true),
                    REF_PropertyandCasualtyClaimNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D_4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_4_REF_REF_PropertyandCasualtyClaimNumberId",
                        column: x => x.REF_PropertyandCasualtyClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_4_REF_REF_SubscriberSecondaryIdentificationId",
                        column: x => x.REF_SubscriberSecondaryIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D_5",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_BillingProviderSecondaryIdentificationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D_5", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_5_REF_REF_BillingProviderSecondaryIdentificationId",
                        column: x => x.REF_BillingProviderSecondaryIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D_6",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_PredeterminationIdentificationId = table.Column<int>(type: "int", nullable: true),
                    REF_ServiceAuthorizationExceptionCodeId = table.Column<int>(type: "int", nullable: true),
                    REF_PayerClaimControlNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_ReferralNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_PriorAuthorizationId = table.Column<int>(type: "int", nullable: true),
                    REF_RepricedClaimNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_AdjustedRepricedClaimNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_ClaimIdentifierForTransmissionIntermediariesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D_6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_AdjustedRepricedClaimNumberId",
                        column: x => x.REF_AdjustedRepricedClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_ClaimIdentifierForTransmissionIntermediariesId",
                        column: x => x.REF_ClaimIdentifierForTransmissionIntermediariesId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_PayerClaimControlNumberId",
                        column: x => x.REF_PayerClaimControlNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_PredeterminationIdentificationId",
                        column: x => x.REF_PredeterminationIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_PriorAuthorizationId",
                        column: x => x.REF_PriorAuthorizationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_ReferralNumberId",
                        column: x => x.REF_ReferralNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_RepricedClaimNumberId",
                        column: x => x.REF_RepricedClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_6_REF_REF_ServiceAuthorizationExceptionCodeId",
                        column: x => x.REF_ServiceAuthorizationExceptionCodeId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D_7",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_PropertyandCasualtyClaimNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_PropertyandCasualtyPatientIdentifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D_7", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_7_REF_REF_PropertyandCasualtyClaimNumberId",
                        column: x => x.REF_PropertyandCasualtyClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837D_7_REF_REF_PropertyandCasualtyPatientIdentifierId",
                        column: x => x.REF_PropertyandCasualtyPatientIdentifierId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837D_8",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_BillingProviderTaxIdentificationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837D_8", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837D_8_REF_REF_BillingProviderTaxIdentificationId",
                        column: x => x.REF_BillingProviderTaxIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_LineItemControlNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_RepricedLineItemReferenceNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_AdjustedRepricedLineItemReferenceNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837I_REF_REF_AdjustedRepricedLineItemReferenceNumberId",
                        column: x => x.REF_AdjustedRepricedLineItemReferenceNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_REF_REF_LineItemControlNumberId",
                        column: x => x.REF_LineItemControlNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_REF_REF_RepricedLineItemReferenceNumberId",
                        column: x => x.REF_RepricedLineItemReferenceNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837I_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_SubscriberSecondaryIdentificationId = table.Column<int>(type: "int", nullable: true),
                    REF_PropertyandCasualtyClaimNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837I_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837I_2_REF_REF_PropertyandCasualtyClaimNumberId",
                        column: x => x.REF_PropertyandCasualtyClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_2_REF_REF_SubscriberSecondaryIdentificationId",
                        column: x => x.REF_SubscriberSecondaryIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837I_3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_BillingProviderSecondaryIdentificationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837I_3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837I_3_REF_REF_BillingProviderSecondaryIdentificationId",
                        column: x => x.REF_BillingProviderSecondaryIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837I_4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_ServiceAuthorizationExceptionCodeId = table.Column<int>(type: "int", nullable: true),
                    REF_ReferralNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_PriorAuthorizationId = table.Column<int>(type: "int", nullable: true),
                    REF_PayerClaimControlNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_RepricedClaimNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_AdjustedRepricedClaimNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_ClaimIdentifierForTransmissionIntermediariesId = table.Column<int>(type: "int", nullable: true),
                    REF_AutoAccidentStateId = table.Column<int>(type: "int", nullable: true),
                    REF_MedicalRecordNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_DemonstrationProjectIdentifierId = table.Column<int>(type: "int", nullable: true),
                    REF_PeerReviewOrganization_PRO_ApprovalNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837I_4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_AdjustedRepricedClaimNumberId",
                        column: x => x.REF_AdjustedRepricedClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_AutoAccidentStateId",
                        column: x => x.REF_AutoAccidentStateId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_ClaimIdentifierForTransmissionIntermediariesId",
                        column: x => x.REF_ClaimIdentifierForTransmissionIntermediariesId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_DemonstrationProjectIdentifierId",
                        column: x => x.REF_DemonstrationProjectIdentifierId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_MedicalRecordNumberId",
                        column: x => x.REF_MedicalRecordNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_PayerClaimControlNumberId",
                        column: x => x.REF_PayerClaimControlNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_PeerReviewOrganization_PRO_ApprovalNumberId",
                        column: x => x.REF_PeerReviewOrganization_PRO_ApprovalNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_PriorAuthorizationId",
                        column: x => x.REF_PriorAuthorizationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_ReferralNumberId",
                        column: x => x.REF_ReferralNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_RepricedClaimNumberId",
                        column: x => x.REF_RepricedClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_4_REF_REF_ServiceAuthorizationExceptionCodeId",
                        column: x => x.REF_ServiceAuthorizationExceptionCodeId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837I_5",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_OtherPayerPriorAuthorizationNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_OtherPayerReferralNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_OtherPayerClaimAdjustmentIndicatorId = table.Column<int>(type: "int", nullable: true),
                    REF_OtherPayerClaimControlNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837I_5", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837I_5_REF_REF_OtherPayerClaimAdjustmentIndicatorId",
                        column: x => x.REF_OtherPayerClaimAdjustmentIndicatorId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_5_REF_REF_OtherPayerClaimControlNumberId",
                        column: x => x.REF_OtherPayerClaimControlNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_5_REF_REF_OtherPayerPriorAuthorizationNumberId",
                        column: x => x.REF_OtherPayerPriorAuthorizationNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_5_REF_REF_OtherPayerReferralNumberId",
                        column: x => x.REF_OtherPayerReferralNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837I_6",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_PropertyandCasualtyClaimNumberId = table.Column<int>(type: "int", nullable: true),
                    REF_PropertyandCasualtyPatientIdentifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837I_6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837I_6_REF_REF_PropertyandCasualtyClaimNumberId",
                        column: x => x.REF_PropertyandCasualtyClaimNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_6_REF_REF_PropertyandCasualtyPatientIdentifierId",
                        column: x => x.REF_PropertyandCasualtyPatientIdentifierId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_REF_837I_7",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REF_Pay_ToPlanSecondaryIdentificationId = table.Column<int>(type: "int", nullable: true),
                    REF_Pay_ToTaxIdentificationNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_REF_837I_7", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_REF_837I_7_REF_REF_Pay_ToPlanSecondaryIdentificationId",
                        column: x => x.REF_Pay_ToPlanSecondaryIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_REF_837I_7_REF_REF_Pay_ToTaxIdentificationNumberId",
                        column: x => x.REF_Pay_ToTaxIdentificationNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "C005_ToothSurface",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToothSurfaceCode_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToothSurfaceCode_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToothSurfaceCode_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToothSurfaceCode_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToothSurfaceCode_05 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C005_ToothSurface", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "C006_OralCavityDesignation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OralCavityDesignationCode_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralCavityDesignationCode_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralCavityDesignationCode_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralCavityDesignationCode_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralCavityDesignationCode_05 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C006_OralCavityDesignation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CL1_InstitutionalClaimCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionTypeCode_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionSourceCode_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientStatusCode_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NursingHomeResidentialStatusCode_04 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CL1_InstitutionalClaimCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DN1_OrthodonticTotalMonthsofTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrthodonticTreatmentMonthsCount_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrthodonticTreatmentMonthsRemainingCount_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YesNoConditionorResponseCode_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrthodonticTreatmentIndicator_04 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DN1_OrthodonticTotalMonthsofTreatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loop_1000A_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_SubmitterNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_1000A_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_1000A_837D_NM1_NM1_SubmitterNameId",
                        column: x => x.NM1_SubmitterNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_1000A_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_SubmitterNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_1000A_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_1000A_837I_NM1_NM1_SubmitterNameId",
                        column: x => x.NM1_SubmitterNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_1000B_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ReceiverNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_1000B_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_1000B_837D_NM1_NM1_ReceiverNameId",
                        column: x => x.NM1_ReceiverNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_1000B_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ReceiverNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_1000B_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_1000B_837I_NM1_NM1_ReceiverNameId",
                        column: x => x.NM1_ReceiverNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010AA_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_BillingProviderNameId = table.Column<int>(type: "int", nullable: true),
                    N3_BillingProviderAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_BillingProviderCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    REF_BillingProviderTaxIdentificationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010AA_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837I_N3_N3_BillingProviderAddressId",
                        column: x => x.N3_BillingProviderAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837I_N4_N4_BillingProviderCity_State_ZIPCodeId",
                        column: x => x.N4_BillingProviderCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837I_NM1_NM1_BillingProviderNameId",
                        column: x => x.NM1_BillingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837I_REF_REF_BillingProviderTaxIdentificationId",
                        column: x => x.REF_BillingProviderTaxIdentificationId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010AB_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_Pay_AddressNameId = table.Column<int>(type: "int", nullable: true),
                    N3_Pay_Address_ADDRESSId = table.Column<int>(type: "int", nullable: true),
                    N4_Pay_Address_City_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010AB_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010AB_837D_N3_N3_Pay_Address_ADDRESSId",
                        column: x => x.N3_Pay_Address_ADDRESSId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AB_837D_N4_N4_Pay_Address_City_State_ZIPCodeId",
                        column: x => x.N4_Pay_Address_City_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AB_837D_NM1_NM1_Pay_AddressNameId",
                        column: x => x.NM1_Pay_AddressNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010AB_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_Pay_AddressNameId = table.Column<int>(type: "int", nullable: true),
                    N3_Pay_ToAddress_ADDRESSId = table.Column<int>(type: "int", nullable: true),
                    N4_Pay_AddressCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010AB_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010AB_837I_N3_N3_Pay_ToAddress_ADDRESSId",
                        column: x => x.N3_Pay_ToAddress_ADDRESSId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AB_837I_N4_N4_Pay_AddressCity_State_ZIPCodeId",
                        column: x => x.N4_Pay_AddressCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AB_837I_NM1_NM1_Pay_AddressNameId",
                        column: x => x.NM1_Pay_AddressNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310A_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_AttendingProviderNameId = table.Column<int>(type: "int", nullable: true),
                    PRV_AttendingProviderSpecialtyInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310A_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310A_837I_NM1_NM1_AttendingProviderNameId",
                        column: x => x.NM1_AttendingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310A_837I_PRV_PRV_AttendingProviderSpecialtyInformationId",
                        column: x => x.PRV_AttendingProviderSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310B_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_RenderingProviderNameId = table.Column<int>(type: "int", nullable: true),
                    PRV_RenderingProviderSpecialtyInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310B_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310B_837D_NM1_NM1_RenderingProviderNameId",
                        column: x => x.NM1_RenderingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310B_837D_PRV_PRV_RenderingProviderSpecialtyInformationId",
                        column: x => x.PRV_RenderingProviderSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310B_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OperatingPhysicianNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310B_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310B_837I_NM1_NM1_OperatingPhysicianNameId",
                        column: x => x.NM1_OperatingPhysicianNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310C_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ServiceFacilityLocationNameId = table.Column<int>(type: "int", nullable: true),
                    N3_ServiceFacilityLocationAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_ServiceFacilityLocationCity_State_ZipCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310C_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310C_837D_N3_N3_ServiceFacilityLocationAddressId",
                        column: x => x.N3_ServiceFacilityLocationAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310C_837D_N4_N4_ServiceFacilityLocationCity_State_ZipCodeId",
                        column: x => x.N4_ServiceFacilityLocationCity_State_ZipCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310C_837D_NM1_NM1_ServiceFacilityLocationNameId",
                        column: x => x.NM1_ServiceFacilityLocationNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310C_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherOperatingPhysicianNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310C_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310C_837I_NM1_NM1_OtherOperatingPhysicianNameId",
                        column: x => x.NM1_OtherOperatingPhysicianNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310D_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_AssistantSurgeonNameId = table.Column<int>(type: "int", nullable: true),
                    PRV_AssistantSurgeonSpecialtyInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310D_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310D_837D_NM1_NM1_AssistantSurgeonNameId",
                        column: x => x.NM1_AssistantSurgeonNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310D_837D_PRV_PRV_AssistantSurgeonSpecialtyInformationId",
                        column: x => x.PRV_AssistantSurgeonSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310D_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_RenderingProviderNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310D_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310D_837I_NM1_NM1_RenderingProviderNameId",
                        column: x => x.NM1_RenderingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310E_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_SupervisingProviderNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310E_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310E_837D_NM1_NM1_SupervisingProviderNameId",
                        column: x => x.NM1_SupervisingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310E_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ServiceFacilityLocationNameId = table.Column<int>(type: "int", nullable: true),
                    N3_ServiceFacilityLocationAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_ServiceFacilityLocationCity_State_ZIPId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310E_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310E_837I_N3_N3_ServiceFacilityLocationAddressId",
                        column: x => x.N3_ServiceFacilityLocationAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310E_837I_N4_N4_ServiceFacilityLocationCity_State_ZIPId",
                        column: x => x.N4_ServiceFacilityLocationCity_State_ZIPId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310E_837I_NM1_NM1_ServiceFacilityLocationNameId",
                        column: x => x.NM1_ServiceFacilityLocationNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310F_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ReferringProviderNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310F_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310F_837I_NM1_NM1_ReferringProviderNameId",
                        column: x => x.NM1_ReferringProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330A_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherSubscriberNameId = table.Column<int>(type: "int", nullable: true),
                    N3_OtherSubscriberAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_OtherSubscriberCity_State_ZipCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330A_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330A_837D_N3_N3_OtherSubscriberAddressId",
                        column: x => x.N3_OtherSubscriberAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330A_837D_N4_N4_OtherSubscriberCity_State_ZipCodeId",
                        column: x => x.N4_OtherSubscriberCity_State_ZipCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330A_837D_NM1_NM1_OtherSubscriberNameId",
                        column: x => x.NM1_OtherSubscriberNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330A_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherSubscriberNameId = table.Column<int>(type: "int", nullable: true),
                    N3_OtherSubscriberAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_OtherSubscriberCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330A_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330A_837I_N3_N3_OtherSubscriberAddressId",
                        column: x => x.N3_OtherSubscriberAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330A_837I_N4_N4_OtherSubscriberCity_State_ZIPCodeId",
                        column: x => x.N4_OtherSubscriberCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330A_837I_NM1_NM1_OtherSubscriberNameId",
                        column: x => x.NM1_OtherSubscriberNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330C_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerAttendingProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330C_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330C_837I_NM1_NM1_OtherPayerAttendingProviderId",
                        column: x => x.NM1_OtherPayerAttendingProviderId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330D_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerRenderingProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330D_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330D_837D_NM1_NM1_OtherPayerRenderingProviderId",
                        column: x => x.NM1_OtherPayerRenderingProviderId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330D_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerOperatingPhysicianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330D_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330D_837I_NM1_NM1_OtherPayerOperatingPhysicianId",
                        column: x => x.NM1_OtherPayerOperatingPhysicianId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330E_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerSupervisingProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330E_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330E_837D_NM1_NM1_OtherPayerSupervisingProviderId",
                        column: x => x.NM1_OtherPayerSupervisingProviderId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330E_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerOtherOperatingPhysicianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330E_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330E_837I_NM1_NM1_OtherPayerOtherOperatingPhysicianId",
                        column: x => x.NM1_OtherPayerOtherOperatingPhysicianId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330F_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerBillingProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330F_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330F_837D_NM1_NM1_OtherPayerBillingProviderId",
                        column: x => x.NM1_OtherPayerBillingProviderId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330F_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerServiceFacilityLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330F_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330F_837I_NM1_NM1_OtherPayerServiceFacilityLocationId",
                        column: x => x.NM1_OtherPayerServiceFacilityLocationId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330G_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerServiceFacilityLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330G_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330G_837D_NM1_NM1_OtherPayerServiceFacilityLocationId",
                        column: x => x.NM1_OtherPayerServiceFacilityLocationId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330G_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerRenderingProviderNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330G_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330G_837I_NM1_NM1_OtherPayerRenderingProviderNameId",
                        column: x => x.NM1_OtherPayerRenderingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330H_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerAssistantSurgeonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330H_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330H_837D_NM1_NM1_OtherPayerAssistantSurgeonId",
                        column: x => x.NM1_OtherPayerAssistantSurgeonId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330H_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerReferringProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330H_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330H_837I_NM1_NM1_OtherPayerReferringProviderId",
                        column: x => x.NM1_OtherPayerReferringProviderId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330I_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerBillingProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330I_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330I_837I_NM1_NM1_OtherPayerBillingProviderId",
                        column: x => x.NM1_OtherPayerBillingProviderId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2410_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LIN_DrugIdentificationId = table.Column<int>(type: "int", nullable: true),
                    CTP_DrugQuantityId = table.Column<int>(type: "int", nullable: true),
                    REF_PrescriptionorCompoundDrugAssociationNumberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2410_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2410_837I_CTP_CTP_DrugQuantityId",
                        column: x => x.CTP_DrugQuantityId,
                        principalTable: "CTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2410_837I_LIN_LIN_DrugIdentificationId",
                        column: x => x.LIN_DrugIdentificationId,
                        principalTable: "LIN",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2410_837I_REF_REF_PrescriptionorCompoundDrugAssociationNumberId",
                        column: x => x.REF_PrescriptionorCompoundDrugAssociationNumberId,
                        principalTable: "REF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420A_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_RenderingProviderNameId = table.Column<int>(type: "int", nullable: true),
                    PRV_RenderingProviderSpecialtyInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420A_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420A_837D_NM1_NM1_RenderingProviderNameId",
                        column: x => x.NM1_RenderingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2420A_837D_PRV_PRV_RenderingProviderSpecialtyInformationId",
                        column: x => x.PRV_RenderingProviderSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420A_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OperatingPhysicianNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420A_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420A_837I_NM1_NM1_OperatingPhysicianNameId",
                        column: x => x.NM1_OperatingPhysicianNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420B_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_AssistantSurgeonNameId = table.Column<int>(type: "int", nullable: true),
                    PRV_AssistantSurgeonSpecialtyInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420B_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420B_837D_NM1_NM1_AssistantSurgeonNameId",
                        column: x => x.NM1_AssistantSurgeonNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2420B_837D_PRV_PRV_AssistantSurgeonSpecialtyInformationId",
                        column: x => x.PRV_AssistantSurgeonSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420B_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherOperatingPhysicianNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420B_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420B_837I_NM1_NM1_OtherOperatingPhysicianNameId",
                        column: x => x.NM1_OtherOperatingPhysicianNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420C_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_SupervisingProviderNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420C_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420C_837D_NM1_NM1_SupervisingProviderNameId",
                        column: x => x.NM1_SupervisingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420C_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_RenderingProviderNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420C_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420C_837I_NM1_NM1_RenderingProviderNameId",
                        column: x => x.NM1_RenderingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420D_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ServiceFacilityLocationNameId = table.Column<int>(type: "int", nullable: true),
                    N3_ServiceFacilityLocationAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_ServiceFacilityLocationCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420D_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420D_837D_N3_N3_ServiceFacilityLocationAddressId",
                        column: x => x.N3_ServiceFacilityLocationAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2420D_837D_N4_N4_ServiceFacilityLocationCity_State_ZIPCodeId",
                        column: x => x.N4_ServiceFacilityLocationCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2420D_837D_NM1_NM1_ServiceFacilityLocationNameId",
                        column: x => x.NM1_ServiceFacilityLocationNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2420D_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ReferringProviderNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2420D_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2420D_837I_NM1_NM1_ReferringProviderNameId",
                        column: x => x.NM1_ReferringProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MIA_InpatientAdjudicationInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoveredDaysorVisitsCount_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonetaryAmount_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifetimePsychiatricDaysCount_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimDRGAmount_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimPaymentRemarkCode_05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimDisproportionateShareAmount_06 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimMSPPassthroughAmount_07 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimPPSCapitalAmount_08 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPSCapitalFSPDRGAmount_09 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPSCapitalHSPDRGAmount_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPSCapitalDSHDRGAmount_11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldCapitalAmount_12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPSCapitalIMEamount_13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPSOperatingHospitalSpecificDRGAmount_14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostReportDayCount_15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPSOperatingFederalSpecificDRGAmount_16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimPPSCapitalOutlierAmount_17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimIndirectTeachingAmount_18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonpayableProfessionalComponentAmount_19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimPaymentRemarkCode_20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimPaymentRemarkCode_21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimPaymentRemarkCode_22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimPaymentRemarkCode_23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPSCapitalExceptionAmount_24 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MIA_InpatientAdjudicationInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SV2_InstitutionalServiceLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLineRevenueCode_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompositeMedicalProcedureIdentifier_02Id = table.Column<int>(type: "int", nullable: true),
                    LineItemChargeAmount_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitorBasisforMeasurementCode_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceUnitCount_05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitRate_06 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineItemDeniedChargeorNonCoveredChargeAmount_07 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YesNoConditionorResponseCode_08 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NursingHomeResidentialStatusCode_09 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelofCareCode_10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SV2_InstitutionalServiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SV2_InstitutionalServiceLine_C003_CompositeMedicalProcedureIdentifier_02Id",
                        column: x => x.CompositeMedicalProcedureIdentifier_02Id,
                        principalTable: "C003",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330B_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerNameId = table.Column<int>(type: "int", nullable: true),
                    N3_OtherPayerAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_OtherPayerCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    DTP_ClaimCheckOrRemittanceDateId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330B_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837D_All_REF_837D_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837D_DTP_DTP_ClaimCheckOrRemittanceDateId",
                        column: x => x.DTP_ClaimCheckOrRemittanceDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837D_N3_N3_OtherPayerAddressId",
                        column: x => x.N3_OtherPayerAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837D_N4_N4_OtherPayerCity_State_ZIPCodeId",
                        column: x => x.N4_OtherPayerCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837D_NM1_NM1_OtherPayerNameId",
                        column: x => x.NM1_OtherPayerNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010AC_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_Pay_ToPlanNameId = table.Column<int>(type: "int", nullable: true),
                    N3_Pay_ToPlanAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_Pay_ToPlanCity_State_ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010AC_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837D_All_REF_837D_3_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D_3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837D_N3_N3_Pay_ToPlanAddressId",
                        column: x => x.N3_Pay_ToPlanAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837D_N4_N4_Pay_ToPlanCity_State_ZipCodeId",
                        column: x => x.N4_Pay_ToPlanCity_State_ZipCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837D_NM1_NM1_Pay_ToPlanNameId",
                        column: x => x.NM1_Pay_ToPlanNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010BA_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_SubscriberNameId = table.Column<int>(type: "int", nullable: true),
                    N3_SubscriberAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_SubscriberCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    DMG_SubscriberDemographicInformationId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010BA_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837D_All_REF_837D_4_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D_4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837D_DMG_DMG_SubscriberDemographicInformationId",
                        column: x => x.DMG_SubscriberDemographicInformationId,
                        principalTable: "DMG",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837D_N3_N3_SubscriberAddressId",
                        column: x => x.N3_SubscriberAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837D_N4_N4_SubscriberCity_State_ZIPCodeId",
                        column: x => x.N4_SubscriberCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837D_NM1_NM1_SubscriberNameId",
                        column: x => x.NM1_SubscriberNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010BB_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_PayerNameId = table.Column<int>(type: "int", nullable: true),
                    N3_PayerAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_PayerCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010BB_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837D_All_REF_837D_5_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D_5",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837D_N3_N3_PayerAddressId",
                        column: x => x.N3_PayerAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837D_N4_N4_PayerCity_State_ZIPCodeId",
                        column: x => x.N4_PayerCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837D_NM1_NM1_PayerNameId",
                        column: x => x.NM1_PayerNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010CA_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_PatientNameId = table.Column<int>(type: "int", nullable: true),
                    N3_PatientAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_PatientCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    DMG_PatientDemographicInformationId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010CA_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837D_All_REF_837D_7_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D_7",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837D_DMG_DMG_PatientDemographicInformationId",
                        column: x => x.DMG_PatientDemographicInformationId,
                        principalTable: "DMG",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837D_N3_N3_PatientAddressId",
                        column: x => x.N3_PatientAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837D_N4_N4_PatientCity_State_ZIPCodeId",
                        column: x => x.N4_PatientCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837D_NM1_NM1_PatientNameId",
                        column: x => x.NM1_PatientNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010AA_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_BillingProviderNameId = table.Column<int>(type: "int", nullable: true),
                    N3_BillingProviderAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_BillingProviderCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010AA_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837D_All_REF_837D_8_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D_8",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837D_N3_N3_BillingProviderAddressId",
                        column: x => x.N3_BillingProviderAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837D_N4_N4_BillingProviderCity_State_ZIPCodeId",
                        column: x => x.N4_BillingProviderCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AA_837D_NM1_NM1_BillingProviderNameId",
                        column: x => x.NM1_BillingProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010BA_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_SubscriberNameId = table.Column<int>(type: "int", nullable: true),
                    N3_SubscriberAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_SubscriberCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    DMG_SubscriberDemographicInformationId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010BA_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837I_All_REF_837I_2_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837I_2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837I_DMG_DMG_SubscriberDemographicInformationId",
                        column: x => x.DMG_SubscriberDemographicInformationId,
                        principalTable: "DMG",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837I_N3_N3_SubscriberAddressId",
                        column: x => x.N3_SubscriberAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837I_N4_N4_SubscriberCity_State_ZIPCodeId",
                        column: x => x.N4_SubscriberCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BA_837I_NM1_NM1_SubscriberNameId",
                        column: x => x.NM1_SubscriberNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010BB_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_PayerNameId = table.Column<int>(type: "int", nullable: true),
                    N3_PayerAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_PayerCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010BB_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837I_All_REF_837I_3_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837I_3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837I_N3_N3_PayerAddressId",
                        column: x => x.N3_PayerAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837I_N4_N4_PayerCity_State_ZIPCodeId",
                        column: x => x.N4_PayerCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010BB_837I_NM1_NM1_PayerNameId",
                        column: x => x.NM1_PayerNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330B_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerNameId = table.Column<int>(type: "int", nullable: true),
                    N3_OtherPayerAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_OtherPayerCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    DTP_ClaimCheckOrRemittanceDateId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330B_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837I_All_REF_837I_5_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837I_5",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837I_DTP_DTP_ClaimCheckOrRemittanceDateId",
                        column: x => x.DTP_ClaimCheckOrRemittanceDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837I_N3_N3_OtherPayerAddressId",
                        column: x => x.N3_OtherPayerAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837I_N4_N4_OtherPayerCity_State_ZIPCodeId",
                        column: x => x.N4_OtherPayerCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330B_837I_NM1_NM1_OtherPayerNameId",
                        column: x => x.NM1_OtherPayerNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010CA_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_PatientNameId = table.Column<int>(type: "int", nullable: true),
                    N3_PatientAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_PatientCity_State_ZIPCodeId = table.Column<int>(type: "int", nullable: true),
                    DMG_PatientDemographicInformationId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010CA_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837I_All_REF_837I_6_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837I_6",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837I_DMG_DMG_PatientDemographicInformationId",
                        column: x => x.DMG_PatientDemographicInformationId,
                        principalTable: "DMG",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837I_N3_N3_PatientAddressId",
                        column: x => x.N3_PatientAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837I_N4_N4_PatientCity_State_ZIPCodeId",
                        column: x => x.N4_PatientCity_State_ZIPCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010CA_837I_NM1_NM1_PatientNameId",
                        column: x => x.NM1_PatientNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2010AC_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_Pay_ToPlanNameId = table.Column<int>(type: "int", nullable: true),
                    N3_Pay_ToPlanAddressId = table.Column<int>(type: "int", nullable: true),
                    N4_Pay_ToPlanCity_State_ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2010AC_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837I_All_REF_837I_7_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837I_7",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837I_N3_N3_Pay_ToPlanAddressId",
                        column: x => x.N3_Pay_ToPlanAddressId,
                        principalTable: "N3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837I_N4_N4_Pay_ToPlanCity_State_ZipCodeId",
                        column: x => x.N4_Pay_ToPlanCity_State_ZipCodeId,
                        principalTable: "N4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2010AC_837I_NM1_NM1_Pay_ToPlanNameId",
                        column: x => x.NM1_Pay_ToPlanNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SV3_DentalService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompositeMedicalProcedureIdentifier_01Id = table.Column<int>(type: "int", nullable: true),
                    LineItemChargeAmount_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceofServiceCode_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralCavityDesignation_04Id = table.Column<int>(type: "int", nullable: true),
                    ProsthesisCrownorInlayCode_05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureCount_06 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_07 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopayStatusCode_08 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderAgreementCode_09 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YesNoConditionorResponseCode_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompositeDiagnosisCodePointer_11Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SV3_DentalService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SV3_DentalService_C003_CompositeMedicalProcedureIdentifier_01Id",
                        column: x => x.CompositeMedicalProcedureIdentifier_01Id,
                        principalTable: "C003",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SV3_DentalService_C004_CompositeDiagnosisCodePointer_11Id",
                        column: x => x.CompositeDiagnosisCodePointer_11Id,
                        principalTable: "C004",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SV3_DentalService_C006_OralCavityDesignation_OralCavityDesignation_04Id",
                        column: x => x.OralCavityDesignation_04Id,
                        principalTable: "C006_OralCavityDesignation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837D_6",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop1000AId = table.Column<int>(type: "int", nullable: true),
                    Loop1000BId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837D_6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_6_Loop_1000A_837D_Loop1000AId",
                        column: x => x.Loop1000AId,
                        principalTable: "Loop_1000A_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_6_Loop_1000B_837D_Loop1000BId",
                        column: x => x.Loop1000BId,
                        principalTable: "Loop_1000B_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837I_6",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop1000AId = table.Column<int>(type: "int", nullable: true),
                    Loop1000BId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837I_6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_6_Loop_1000A_837I_Loop1000AId",
                        column: x => x.Loop1000AId,
                        principalTable: "Loop_1000A_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_6_Loop_1000B_837I_Loop1000BId",
                        column: x => x.Loop1000BId,
                        principalTable: "Loop_1000B_837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837D_3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2310BId = table.Column<int>(type: "int", nullable: true),
                    Loop2310CId = table.Column<int>(type: "int", nullable: true),
                    Loop2310DId = table.Column<int>(type: "int", nullable: true),
                    Loop2310EId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837D_3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_3_Loop_2310B_837D_Loop2310BId",
                        column: x => x.Loop2310BId,
                        principalTable: "Loop_2310B_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_3_Loop_2310C_837D_Loop2310CId",
                        column: x => x.Loop2310CId,
                        principalTable: "Loop_2310C_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_3_Loop_2310D_837D_Loop2310DId",
                        column: x => x.Loop2310DId,
                        principalTable: "Loop_2310D_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_3_Loop_2310E_837D_Loop2310EId",
                        column: x => x.Loop2310EId,
                        principalTable: "Loop_2310E_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837I_3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2310AId = table.Column<int>(type: "int", nullable: true),
                    Loop2310BId = table.Column<int>(type: "int", nullable: true),
                    Loop2310CId = table.Column<int>(type: "int", nullable: true),
                    Loop2310DId = table.Column<int>(type: "int", nullable: true),
                    Loop2310EId = table.Column<int>(type: "int", nullable: true),
                    Loop2310FId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837I_3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_3_Loop_2310A_837I_Loop2310AId",
                        column: x => x.Loop2310AId,
                        principalTable: "Loop_2310A_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_3_Loop_2310B_837I_Loop2310BId",
                        column: x => x.Loop2310BId,
                        principalTable: "Loop_2310B_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_3_Loop_2310C_837I_Loop2310CId",
                        column: x => x.Loop2310CId,
                        principalTable: "Loop_2310C_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_3_Loop_2310D_837I_Loop2310DId",
                        column: x => x.Loop2310DId,
                        principalTable: "Loop_2310D_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_3_Loop_2310E_837I_Loop2310EId",
                        column: x => x.Loop2310EId,
                        principalTable: "Loop_2310E_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_3_Loop_2310F_837I_Loop2310FId",
                        column: x => x.Loop2310FId,
                        principalTable: "Loop_2310F_837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837D_5",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2420AId = table.Column<int>(type: "int", nullable: true),
                    Loop2420BId = table.Column<int>(type: "int", nullable: true),
                    Loop2420CId = table.Column<int>(type: "int", nullable: true),
                    Loop2420DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837D_5", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_5_Loop_2420A_837D_Loop2420AId",
                        column: x => x.Loop2420AId,
                        principalTable: "Loop_2420A_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_5_Loop_2420B_837D_Loop2420BId",
                        column: x => x.Loop2420BId,
                        principalTable: "Loop_2420B_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_5_Loop_2420C_837D_Loop2420CId",
                        column: x => x.Loop2420CId,
                        principalTable: "Loop_2420C_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_5_Loop_2420D_837D_Loop2420DId",
                        column: x => x.Loop2420DId,
                        principalTable: "Loop_2420D_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837I_5",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2420AId = table.Column<int>(type: "int", nullable: true),
                    Loop2420BId = table.Column<int>(type: "int", nullable: true),
                    Loop2420CId = table.Column<int>(type: "int", nullable: true),
                    Loop2420DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837I_5", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_5_Loop_2420A_837I_Loop2420AId",
                        column: x => x.Loop2420AId,
                        principalTable: "Loop_2420A_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_5_Loop_2420B_837I_Loop2420BId",
                        column: x => x.Loop2420BId,
                        principalTable: "Loop_2420B_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_5_Loop_2420C_837I_Loop2420CId",
                        column: x => x.Loop2420CId,
                        principalTable: "Loop_2420C_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_5_Loop_2420D_837I_Loop2420DId",
                        column: x => x.Loop2420DId,
                        principalTable: "Loop_2420D_837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837D_4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2330AId = table.Column<int>(type: "int", nullable: true),
                    Loop2330BId = table.Column<int>(type: "int", nullable: true),
                    Loop2330DId = table.Column<int>(type: "int", nullable: true),
                    Loop2330EId = table.Column<int>(type: "int", nullable: true),
                    Loop2330FId = table.Column<int>(type: "int", nullable: true),
                    Loop2330GId = table.Column<int>(type: "int", nullable: true),
                    Loop2330HId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837D_4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_4_Loop_2330A_837D_Loop2330AId",
                        column: x => x.Loop2330AId,
                        principalTable: "Loop_2330A_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_4_Loop_2330B_837D_Loop2330BId",
                        column: x => x.Loop2330BId,
                        principalTable: "Loop_2330B_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_4_Loop_2330D_837D_Loop2330DId",
                        column: x => x.Loop2330DId,
                        principalTable: "Loop_2330D_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_4_Loop_2330E_837D_Loop2330EId",
                        column: x => x.Loop2330EId,
                        principalTable: "Loop_2330E_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_4_Loop_2330F_837D_Loop2330FId",
                        column: x => x.Loop2330FId,
                        principalTable: "Loop_2330F_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_4_Loop_2330G_837D_Loop2330GId",
                        column: x => x.Loop2330GId,
                        principalTable: "Loop_2330G_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_4_Loop_2330H_837D_Loop2330HId",
                        column: x => x.Loop2330HId,
                        principalTable: "Loop_2330H_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837D_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2010BAId = table.Column<int>(type: "int", nullable: true),
                    Loop2010BBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837D_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_2_Loop_2010BA_837D_Loop2010BAId",
                        column: x => x.Loop2010BAId,
                        principalTable: "Loop_2010BA_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_2_Loop_2010BB_837D_Loop2010BBId",
                        column: x => x.Loop2010BBId,
                        principalTable: "Loop_2010BB_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2010AAId = table.Column<int>(type: "int", nullable: true),
                    Loop2010ABId = table.Column<int>(type: "int", nullable: true),
                    Loop2010ACId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_Loop_2010AA_837D_Loop2010AAId",
                        column: x => x.Loop2010AAId,
                        principalTable: "Loop_2010AA_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_Loop_2010AB_837D_Loop2010ABId",
                        column: x => x.Loop2010ABId,
                        principalTable: "Loop_2010AB_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837D_Loop_2010AC_837D_Loop2010ACId",
                        column: x => x.Loop2010ACId,
                        principalTable: "Loop_2010AC_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837I_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2010BAId = table.Column<int>(type: "int", nullable: true),
                    Loop2010BBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837I_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_2_Loop_2010BA_837I_Loop2010BAId",
                        column: x => x.Loop2010BAId,
                        principalTable: "Loop_2010BA_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_2_Loop_2010BB_837I_Loop2010BBId",
                        column: x => x.Loop2010BBId,
                        principalTable: "Loop_2010BB_837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837I_4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2330AId = table.Column<int>(type: "int", nullable: true),
                    Loop2330BId = table.Column<int>(type: "int", nullable: true),
                    Loop2330CId = table.Column<int>(type: "int", nullable: true),
                    Loop2330DId = table.Column<int>(type: "int", nullable: true),
                    Loop2330EId = table.Column<int>(type: "int", nullable: true),
                    Loop2330FId = table.Column<int>(type: "int", nullable: true),
                    Loop2330GId = table.Column<int>(type: "int", nullable: true),
                    Loop2330HId = table.Column<int>(type: "int", nullable: true),
                    Loop2330IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837I_4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330A_837I_Loop2330AId",
                        column: x => x.Loop2330AId,
                        principalTable: "Loop_2330A_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330B_837I_Loop2330BId",
                        column: x => x.Loop2330BId,
                        principalTable: "Loop_2330B_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330C_837I_Loop2330CId",
                        column: x => x.Loop2330CId,
                        principalTable: "Loop_2330C_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330D_837I_Loop2330DId",
                        column: x => x.Loop2330DId,
                        principalTable: "Loop_2330D_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330E_837I_Loop2330EId",
                        column: x => x.Loop2330EId,
                        principalTable: "Loop_2330E_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330F_837I_Loop2330FId",
                        column: x => x.Loop2330FId,
                        principalTable: "Loop_2330F_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330G_837I_Loop2330GId",
                        column: x => x.Loop2330GId,
                        principalTable: "Loop_2330G_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330H_837I_Loop2330HId",
                        column: x => x.Loop2330HId,
                        principalTable: "Loop_2330H_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_4_Loop_2330I_837I_Loop2330IId",
                        column: x => x.Loop2330IId,
                        principalTable: "Loop_2330I_837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "All_NM1_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loop2010AAId = table.Column<int>(type: "int", nullable: true),
                    Loop2010ABId = table.Column<int>(type: "int", nullable: true),
                    Loop2010ACId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_NM1_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_Loop_2010AA_837I_Loop2010AAId",
                        column: x => x.Loop2010AAId,
                        principalTable: "Loop_2010AA_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_Loop_2010AB_837I_Loop2010ABId",
                        column: x => x.Loop2010ABId,
                        principalTable: "Loop_2010AB_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_All_NM1_837I_Loop_2010AC_837I_Loop2010ACId",
                        column: x => x.Loop2010ACId,
                        principalTable: "Loop_2010AC_837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TS837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STId = table.Column<int>(type: "int", nullable: true),
                    BHT_BeginningOfHierarchicalTransactionId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    SEId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TS837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TS837D_All_NM1_837D_6_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837D_6",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TS837D_BHT_BHT_BeginningOfHierarchicalTransactionId",
                        column: x => x.BHT_BeginningOfHierarchicalTransactionId,
                        principalTable: "BHT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TS837D_SE_SEId",
                        column: x => x.SEId,
                        principalTable: "SE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TS837D_ST_STId",
                        column: x => x.STId,
                        principalTable: "ST",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TS837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STId = table.Column<int>(type: "int", nullable: true),
                    BHT_BeginningOfHierarchicalTransactionId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    SEId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TS837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TS837I_All_NM1_837I_6_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837I_6",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TS837I_BHT_BHT_BeginningOfHierarchicalTransactionId",
                        column: x => x.BHT_BeginningOfHierarchicalTransactionId,
                        principalTable: "BHT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TS837I_SE_SEId",
                        column: x => x.SEId,
                        principalTable: "SE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TS837I_ST_STId",
                        column: x => x.STId,
                        principalTable: "ST",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2310A_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_ReferringProviderNameId = table.Column<int>(type: "int", nullable: true),
                    PRV_ReferringProviderSpecialtyInformationId = table.Column<int>(type: "int", nullable: true),
                    All_NM1_837D_3Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2310A_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2310A_837D_All_NM1_837D_3_All_NM1_837D_3Id",
                        column: x => x.All_NM1_837D_3Id,
                        principalTable: "All_NM1_837D_3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310A_837D_NM1_NM1_ReferringProviderNameId",
                        column: x => x.NM1_ReferringProviderNameId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2310A_837D_PRV_PRV_ReferringProviderSpecialtyInformationId",
                        column: x => x.PRV_ReferringProviderSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2330C_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM1_OtherPayerReferringProviderId = table.Column<int>(type: "int", nullable: true),
                    All_NM1_837D_4Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2330C_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2330C_837D_All_NM1_837D_4_All_NM1_837D_4Id",
                        column: x => x.All_NM1_837D_4Id,
                        principalTable: "All_NM1_837D_4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2330C_837D_NM1_NM1_OtherPayerReferringProviderId",
                        column: x => x.NM1_OtherPayerReferringProviderId,
                        principalTable: "NM1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2000A_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HL_BillingProviderHierarchicalLevelId = table.Column<int>(type: "int", nullable: true),
                    PRV_BillingProviderSpecialtyInformationId = table.Column<int>(type: "int", nullable: true),
                    CUR_ForeignCurrencyInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    TS837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2000A_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837D_All_NM1_837D_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837D_CUR_CUR_ForeignCurrencyInformationId",
                        column: x => x.CUR_ForeignCurrencyInformationId,
                        principalTable: "CUR",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837D_HL_HL_BillingProviderHierarchicalLevelId",
                        column: x => x.HL_BillingProviderHierarchicalLevelId,
                        principalTable: "HL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837D_PRV_PRV_BillingProviderSpecialtyInformationId",
                        column: x => x.PRV_BillingProviderSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837D_TS837D_TS837DId",
                        column: x => x.TS837DId,
                        principalTable: "TS837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2000A_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HL_BillingProviderHierarchicalLevelId = table.Column<int>(type: "int", nullable: true),
                    PRV_BillingProviderSpecialtyInformationId = table.Column<int>(type: "int", nullable: true),
                    CUR_ForeignCurrencyInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    TS837IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2000A_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837I_All_NM1_837I_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837I_CUR_CUR_ForeignCurrencyInformationId",
                        column: x => x.CUR_ForeignCurrencyInformationId,
                        principalTable: "CUR",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837I_HL_HL_BillingProviderHierarchicalLevelId",
                        column: x => x.HL_BillingProviderHierarchicalLevelId,
                        principalTable: "HL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837I_PRV_PRV_BillingProviderSpecialtyInformationId",
                        column: x => x.PRV_BillingProviderSpecialtyInformationId,
                        principalTable: "PRV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000A_837I_TS837I_TS837IId",
                        column: x => x.TS837IId,
                        principalTable: "TS837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2000B_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HL_SubscriberHierarchicalLevelId = table.Column<int>(type: "int", nullable: true),
                    SBR_SubscriberInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2000A_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2000B_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837D_All_NM1_837D_2_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837D_2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837D_HL_HL_SubscriberHierarchicalLevelId",
                        column: x => x.HL_SubscriberHierarchicalLevelId,
                        principalTable: "HL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837D_Loop_2000A_837D_Loop_2000A_837DId",
                        column: x => x.Loop_2000A_837DId,
                        principalTable: "Loop_2000A_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837D_SBR_SBR_SubscriberInformationId",
                        column: x => x.SBR_SubscriberInformationId,
                        principalTable: "SBR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2000B_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HL_SubscriberHierarchicalLevelId = table.Column<int>(type: "int", nullable: true),
                    SBR_SubscriberInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2000A_837IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2000B_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837I_All_NM1_837I_2_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837I_2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837I_HL_HL_SubscriberHierarchicalLevelId",
                        column: x => x.HL_SubscriberHierarchicalLevelId,
                        principalTable: "HL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837I_Loop_2000A_837I_Loop_2000A_837IId",
                        column: x => x.Loop_2000A_837IId,
                        principalTable: "Loop_2000A_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000B_837I_SBR_SBR_SubscriberInformationId",
                        column: x => x.SBR_SubscriberInformationId,
                        principalTable: "SBR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2000C_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HL_PatientHierarchicalLevelId = table.Column<int>(type: "int", nullable: true),
                    PAT_PatientInformationId = table.Column<int>(type: "int", nullable: true),
                    Loop2010CAId = table.Column<int>(type: "int", nullable: true),
                    Loop_2000B_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2000C_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837D_HL_HL_PatientHierarchicalLevelId",
                        column: x => x.HL_PatientHierarchicalLevelId,
                        principalTable: "HL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837D_Loop_2000B_837D_Loop_2000B_837DId",
                        column: x => x.Loop_2000B_837DId,
                        principalTable: "Loop_2000B_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837D_Loop_2010CA_837D_Loop2010CAId",
                        column: x => x.Loop2010CAId,
                        principalTable: "Loop_2010CA_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837D_PAT_PAT_PatientInformationId",
                        column: x => x.PAT_PatientInformationId,
                        principalTable: "PAT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2000C_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HL_PatientHierarchicalLevelId = table.Column<int>(type: "int", nullable: true),
                    PAT_PatientInformationId = table.Column<int>(type: "int", nullable: true),
                    Loop2010CAId = table.Column<int>(type: "int", nullable: true),
                    Loop_2000B_837IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2000C_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837I_HL_HL_PatientHierarchicalLevelId",
                        column: x => x.HL_PatientHierarchicalLevelId,
                        principalTable: "HL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837I_Loop_2000B_837I_Loop_2000B_837IId",
                        column: x => x.Loop_2000B_837IId,
                        principalTable: "Loop_2000B_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837I_Loop_2010CA_837I_Loop2010CAId",
                        column: x => x.Loop2010CAId,
                        principalTable: "Loop_2010CA_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2000C_837I_PAT_PAT_PatientInformationId",
                        column: x => x.PAT_PatientInformationId,
                        principalTable: "PAT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2300_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLM_ClaimInformationId = table.Column<int>(type: "int", nullable: true),
                    AllDTPId = table.Column<int>(type: "int", nullable: true),
                    DN1_OrthodonticTotalMonthsofTreatmentId = table.Column<int>(type: "int", nullable: true),
                    CN1_ContractInformationId = table.Column<int>(type: "int", nullable: true),
                    AMT_PatientAmountPaidId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true),
                    HI_HealthCareDiagnosisCodeId = table.Column<int>(type: "int", nullable: true),
                    HCP_ClaimPricing_RepricingInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2000B_837DId = table.Column<int>(type: "int", nullable: true),
                    Loop_2000C_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2300_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_AMT_AMT_PatientAmountPaidId",
                        column: x => x.AMT_PatientAmountPaidId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_All_DTP_837D_2_AllDTPId",
                        column: x => x.AllDTPId,
                        principalTable: "All_DTP_837D_2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_All_NM1_837D_3_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837D_3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_All_REF_837D_6_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D_6",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_CLM_CLM_ClaimInformationId",
                        column: x => x.CLM_ClaimInformationId,
                        principalTable: "CLM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_CN1_CN1_ContractInformationId",
                        column: x => x.CN1_ContractInformationId,
                        principalTable: "CN1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_DN1_OrthodonticTotalMonthsofTreatment_DN1_OrthodonticTotalMonthsofTreatmentId",
                        column: x => x.DN1_OrthodonticTotalMonthsofTreatmentId,
                        principalTable: "DN1_OrthodonticTotalMonthsofTreatment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_HCP_HCP_ClaimPricing_RepricingInformationId",
                        column: x => x.HCP_ClaimPricing_RepricingInformationId,
                        principalTable: "HCP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_HI_HI_HealthCareDiagnosisCodeId",
                        column: x => x.HI_HealthCareDiagnosisCodeId,
                        principalTable: "HI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_Loop_2000B_837D_Loop_2000B_837DId",
                        column: x => x.Loop_2000B_837DId,
                        principalTable: "Loop_2000B_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837D_Loop_2000C_837D_Loop_2000C_837DId",
                        column: x => x.Loop_2000C_837DId,
                        principalTable: "Loop_2000C_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2300_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLM_ClaimInformationId = table.Column<int>(type: "int", nullable: true),
                    AllDTPId = table.Column<int>(type: "int", nullable: true),
                    CL1_InstitutionalClaimCodeId = table.Column<int>(type: "int", nullable: true),
                    CN1_ContractInformationId = table.Column<int>(type: "int", nullable: true),
                    AMT_PatientEstimatedAmountDueId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true),
                    AllNTEId = table.Column<int>(type: "int", nullable: true),
                    CRC_EPSDTReferralId = table.Column<int>(type: "int", nullable: true),
                    AllHIId = table.Column<int>(type: "int", nullable: true),
                    HCP_ClaimPricing_RepricingInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2000B_837IId = table.Column<int>(type: "int", nullable: true),
                    Loop_2000C_837IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2300_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_AMT_AMT_PatientEstimatedAmountDueId",
                        column: x => x.AMT_PatientEstimatedAmountDueId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_All_DTP_837I_AllDTPId",
                        column: x => x.AllDTPId,
                        principalTable: "All_DTP_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_All_HI_837I_AllHIId",
                        column: x => x.AllHIId,
                        principalTable: "All_HI_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_All_NM1_837I_3_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837I_3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_All_NTE_837I_AllNTEId",
                        column: x => x.AllNTEId,
                        principalTable: "All_NTE_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_All_REF_837I_4_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837I_4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_CL1_InstitutionalClaimCode_CL1_InstitutionalClaimCodeId",
                        column: x => x.CL1_InstitutionalClaimCodeId,
                        principalTable: "CL1_InstitutionalClaimCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_CLM_CLM_ClaimInformationId",
                        column: x => x.CLM_ClaimInformationId,
                        principalTable: "CLM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_CN1_CN1_ContractInformationId",
                        column: x => x.CN1_ContractInformationId,
                        principalTable: "CN1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_CRC_CRC_EPSDTReferralId",
                        column: x => x.CRC_EPSDTReferralId,
                        principalTable: "CRC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_HCP_HCP_ClaimPricing_RepricingInformationId",
                        column: x => x.HCP_ClaimPricing_RepricingInformationId,
                        principalTable: "HCP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_Loop_2000B_837I_Loop_2000B_837IId",
                        column: x => x.Loop_2000B_837IId,
                        principalTable: "Loop_2000B_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2300_837I_Loop_2000C_837I_Loop_2000C_837IId",
                        column: x => x.Loop_2000C_837IId,
                        principalTable: "Loop_2000C_837I",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DN2_ToothStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToothNumber_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToothStatusCode_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimePeriodFormatQualifier_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimePeriod_05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifierCode_06 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loop_2300_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DN2_ToothStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DN2_ToothStatus_Loop_2300_837D_Loop_2300_837DId",
                        column: x => x.Loop_2300_837DId,
                        principalTable: "Loop_2300_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2320_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SBR_OtherSubscriberInformationId = table.Column<int>(type: "int", nullable: true),
                    AllAMTId = table.Column<int>(type: "int", nullable: true),
                    OI_OtherInsuranceCoverageInformationId = table.Column<int>(type: "int", nullable: true),
                    MOA_OutpatientAdjudicationInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2300_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2320_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2320_837D_All_AMT_837D_AllAMTId",
                        column: x => x.AllAMTId,
                        principalTable: "All_AMT_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837D_All_NM1_837D_4_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837D_4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837D_Loop_2300_837D_Loop_2300_837DId",
                        column: x => x.Loop_2300_837DId,
                        principalTable: "Loop_2300_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837D_MOA_MOA_OutpatientAdjudicationInformationId",
                        column: x => x.MOA_OutpatientAdjudicationInformationId,
                        principalTable: "MOA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837D_OI_OI_OtherInsuranceCoverageInformationId",
                        column: x => x.OI_OtherInsuranceCoverageInformationId,
                        principalTable: "OI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837D_SBR_SBR_OtherSubscriberInformationId",
                        column: x => x.SBR_OtherSubscriberInformationId,
                        principalTable: "SBR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2400_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LX_ServiceLineNumberId = table.Column<int>(type: "int", nullable: true),
                    SV3_DentalServiceId = table.Column<int>(type: "int", nullable: true),
                    AllDTPId = table.Column<int>(type: "int", nullable: true),
                    CN1_ContractInformationId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true),
                    AMT_SalesTaxAmountId = table.Column<int>(type: "int", nullable: true),
                    HCP_LinePricing_RepricingInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2300_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2400_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_AMT_AMT_SalesTaxAmountId",
                        column: x => x.AMT_SalesTaxAmountId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_All_DTP_837D_AllDTPId",
                        column: x => x.AllDTPId,
                        principalTable: "All_DTP_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_All_NM1_837D_5_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837D_5",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_All_REF_837D_2_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837D_2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_CN1_CN1_ContractInformationId",
                        column: x => x.CN1_ContractInformationId,
                        principalTable: "CN1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_HCP_HCP_LinePricing_RepricingInformationId",
                        column: x => x.HCP_LinePricing_RepricingInformationId,
                        principalTable: "HCP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_LX_LX_ServiceLineNumberId",
                        column: x => x.LX_ServiceLineNumberId,
                        principalTable: "LX",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_Loop_2300_837D_Loop_2300_837DId",
                        column: x => x.Loop_2300_837DId,
                        principalTable: "Loop_2300_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837D_SV3_DentalService_SV3_DentalServiceId",
                        column: x => x.SV3_DentalServiceId,
                        principalTable: "SV3_DentalService",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2320_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SBR_OtherSubscriberInformationId = table.Column<int>(type: "int", nullable: true),
                    AllAMTId = table.Column<int>(type: "int", nullable: true),
                    OI_OtherInsuranceCoverageInformationId = table.Column<int>(type: "int", nullable: true),
                    MIA_InpatientAdjudicationInformationId = table.Column<int>(type: "int", nullable: true),
                    MOA_OutpatientAdjudicationInformationId = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2300_837IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2320_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2320_837I_All_AMT_837I_2_AllAMTId",
                        column: x => x.AllAMTId,
                        principalTable: "All_AMT_837I_2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837I_All_NM1_837I_4_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837I_4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837I_Loop_2300_837I_Loop_2300_837IId",
                        column: x => x.Loop_2300_837IId,
                        principalTable: "Loop_2300_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837I_MIA_InpatientAdjudicationInformation_MIA_InpatientAdjudicationInformationId",
                        column: x => x.MIA_InpatientAdjudicationInformationId,
                        principalTable: "MIA_InpatientAdjudicationInformation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837I_MOA_MOA_OutpatientAdjudicationInformationId",
                        column: x => x.MOA_OutpatientAdjudicationInformationId,
                        principalTable: "MOA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837I_OI_OI_OtherInsuranceCoverageInformationId",
                        column: x => x.OI_OtherInsuranceCoverageInformationId,
                        principalTable: "OI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2320_837I_SBR_SBR_OtherSubscriberInformationId",
                        column: x => x.SBR_OtherSubscriberInformationId,
                        principalTable: "SBR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2400_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LX_ServiceLineNumberId = table.Column<int>(type: "int", nullable: true),
                    SV2_InstitutionalServiceLineId = table.Column<int>(type: "int", nullable: true),
                    DTP_Date_ServiceDateId = table.Column<int>(type: "int", nullable: true),
                    AllREFId = table.Column<int>(type: "int", nullable: true),
                    AllAMTId = table.Column<int>(type: "int", nullable: true),
                    NTE_ThirdPartyOrganizationNotesId = table.Column<int>(type: "int", nullable: true),
                    HCP_LinePricing_RepricingInformationId = table.Column<int>(type: "int", nullable: true),
                    Loop2410Id = table.Column<int>(type: "int", nullable: true),
                    AllNM1Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2300_837IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2400_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_All_AMT_837I_AllAMTId",
                        column: x => x.AllAMTId,
                        principalTable: "All_AMT_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_All_NM1_837I_5_AllNM1Id",
                        column: x => x.AllNM1Id,
                        principalTable: "All_NM1_837I_5",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_All_REF_837I_AllREFId",
                        column: x => x.AllREFId,
                        principalTable: "All_REF_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_DTP_DTP_Date_ServiceDateId",
                        column: x => x.DTP_Date_ServiceDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_HCP_HCP_LinePricing_RepricingInformationId",
                        column: x => x.HCP_LinePricing_RepricingInformationId,
                        principalTable: "HCP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_LX_LX_ServiceLineNumberId",
                        column: x => x.LX_ServiceLineNumberId,
                        principalTable: "LX",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_Loop_2300_837I_Loop_2300_837IId",
                        column: x => x.Loop_2300_837IId,
                        principalTable: "Loop_2300_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_Loop_2410_837I_Loop2410Id",
                        column: x => x.Loop2410Id,
                        principalTable: "Loop_2410_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_NTE_NTE_ThirdPartyOrganizationNotesId",
                        column: x => x.NTE_ThirdPartyOrganizationNotesId,
                        principalTable: "NTE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2400_837I_SV2_InstitutionalServiceLine_SV2_InstitutionalServiceLineId",
                        column: x => x.SV2_InstitutionalServiceLineId,
                        principalTable: "SV2_InstitutionalServiceLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2430_837D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SVD_LineAdjudicationInformationId = table.Column<int>(type: "int", nullable: true),
                    DTP_LineCheckorRemittanceDateId = table.Column<int>(type: "int", nullable: true),
                    AMT_RemainingPatientLiabilityId = table.Column<int>(type: "int", nullable: true),
                    Loop_2400_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2430_837D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2430_837D_AMT_AMT_RemainingPatientLiabilityId",
                        column: x => x.AMT_RemainingPatientLiabilityId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2430_837D_DTP_DTP_LineCheckorRemittanceDateId",
                        column: x => x.DTP_LineCheckorRemittanceDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2430_837D_Loop_2400_837D_Loop_2400_837DId",
                        column: x => x.Loop_2400_837DId,
                        principalTable: "Loop_2400_837D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2430_837D_SVD_SVD_LineAdjudicationInformationId",
                        column: x => x.SVD_LineAdjudicationInformationId,
                        principalTable: "SVD",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TOO_ToothInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeListQualifierCode_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToothCode_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToothSurface_03Id = table.Column<int>(type: "int", nullable: true),
                    Loop_2400_837DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOO_ToothInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TOO_ToothInformation_C005_ToothSurface_ToothSurface_03Id",
                        column: x => x.ToothSurface_03Id,
                        principalTable: "C005_ToothSurface",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TOO_ToothInformation_Loop_2400_837D_Loop_2400_837DId",
                        column: x => x.Loop_2400_837DId,
                        principalTable: "Loop_2400_837D",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loop_2430_837I",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SVD_LineAdjudicationInformationId = table.Column<int>(type: "int", nullable: true),
                    DTP_LineCheckorRemittanceDateId = table.Column<int>(type: "int", nullable: true),
                    AMT_RemainingPatientLiabilityId = table.Column<int>(type: "int", nullable: true),
                    Loop_2400_837IId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loop_2430_837I", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loop_2430_837I_AMT_AMT_RemainingPatientLiabilityId",
                        column: x => x.AMT_RemainingPatientLiabilityId,
                        principalTable: "AMT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2430_837I_DTP_DTP_LineCheckorRemittanceDateId",
                        column: x => x.DTP_LineCheckorRemittanceDateId,
                        principalTable: "DTP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2430_837I_Loop_2400_837I_Loop_2400_837IId",
                        column: x => x.Loop_2400_837IId,
                        principalTable: "Loop_2400_837I",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loop_2430_837I_SVD_SVD_LineAdjudicationInformationId",
                        column: x => x.SVD_LineAdjudicationInformationId,
                        principalTable: "SVD",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SVD_SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD",
                column: "SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_SVD_SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD",
                column: "SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_All_REF_837D_2Id",
                table: "REF",
                column: "All_REF_837D_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_All_REF_837D_5Id",
                table: "REF",
                column: "All_REF_837D_5Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_All_REF_837D_8Id",
                table: "REF",
                column: "All_REF_837D_8Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_All_REF_837DId",
                table: "REF",
                column: "All_REF_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_All_REF_837I_3Id",
                table: "REF",
                column: "All_REF_837I_3Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_All_REF_837I_4Id",
                table: "REF",
                column: "All_REF_837I_4Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_All_REF_837I_5Id",
                table: "REF",
                column: "All_REF_837I_5Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310A_837DId",
                table: "REF",
                column: "Loop_2310A_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310A_837IId",
                table: "REF",
                column: "Loop_2310A_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310B_837DId",
                table: "REF",
                column: "Loop_2310B_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310B_837IId",
                table: "REF",
                column: "Loop_2310B_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310C_837DId",
                table: "REF",
                column: "Loop_2310C_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310C_837IId",
                table: "REF",
                column: "Loop_2310C_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310D_837DId",
                table: "REF",
                column: "Loop_2310D_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310D_837IId",
                table: "REF",
                column: "Loop_2310D_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310E_837DId",
                table: "REF",
                column: "Loop_2310E_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310E_837IId",
                table: "REF",
                column: "Loop_2310E_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2310F_837IId",
                table: "REF",
                column: "Loop_2310F_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330A_837DId",
                table: "REF",
                column: "Loop_2330A_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330A_837IId",
                table: "REF",
                column: "Loop_2330A_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330C_837DId",
                table: "REF",
                column: "Loop_2330C_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330C_837IId",
                table: "REF",
                column: "Loop_2330C_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330D_837DId",
                table: "REF",
                column: "Loop_2330D_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330D_837IId",
                table: "REF",
                column: "Loop_2330D_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330E_837DId",
                table: "REF",
                column: "Loop_2330E_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330E_837IId",
                table: "REF",
                column: "Loop_2330E_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330F_837DId",
                table: "REF",
                column: "Loop_2330F_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330F_837IId",
                table: "REF",
                column: "Loop_2330F_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330G_837DId",
                table: "REF",
                column: "Loop_2330G_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330G_837IId",
                table: "REF",
                column: "Loop_2330G_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330H_837DId",
                table: "REF",
                column: "Loop_2330H_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330H_837IId",
                table: "REF",
                column: "Loop_2330H_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2330I_837IId",
                table: "REF",
                column: "Loop_2330I_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420A_837DId",
                table: "REF",
                column: "Loop_2420A_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420A_837IId",
                table: "REF",
                column: "Loop_2420A_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420B_837DId",
                table: "REF",
                column: "Loop_2420B_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420B_837IId",
                table: "REF",
                column: "Loop_2420B_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420C_837DId",
                table: "REF",
                column: "Loop_2420C_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420C_837IId",
                table: "REF",
                column: "Loop_2420C_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420D_837DId",
                table: "REF",
                column: "Loop_2420D_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_Loop_2420D_837IId",
                table: "REF",
                column: "Loop_2420D_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_REF_REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id",
                table: "REF",
                column: "REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_REF_OtherPayerReferralNumber_2_All_REF_837D_2Id",
                table: "REF",
                column: "REF_OtherPayerReferralNumber_2_All_REF_837D_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_REF_PeerReviewOrganization_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_PeerReviewOrganization_ReferenceIdentifier_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_REF_REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_PWK_Loop_2300_837DId",
                table: "PWK",
                column: "Loop_2300_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_PWK_Loop_2300_837IId",
                table: "PWK",
                column: "Loop_2300_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_PWK_Loop_2400_837IId",
                table: "PWK",
                column: "Loop_2400_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_PWK_PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id",
                table: "PWK",
                column: "PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRV_PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                column: "PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRV_PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                column: "PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRV_PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                column: "PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_PER_Loop_1000A_837DId",
                table: "PER",
                column: "Loop_1000A_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_PER_Loop_1000A_837IId",
                table: "PER",
                column: "Loop_1000A_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_PER_Loop_2010AA_837DId",
                table: "PER",
                column: "Loop_2010AA_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_PER_Loop_2010AA_837IId",
                table: "PER",
                column: "Loop_2010AA_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_NTE_All_NTE_837IId",
                table: "NTE",
                column: "All_NTE_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_NTE_Loop_2300_837DId",
                table: "NTE",
                column: "Loop_2300_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_K3_Loop_2300_837DId",
                table: "K3",
                column: "Loop_2300_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_K3_Loop_2300_837IId",
                table: "K3",
                column: "Loop_2300_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_K3_Loop_2400_837DId",
                table: "K3",
                column: "Loop_2400_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_All_HI_837IId",
                table: "HI",
                column: "All_HI_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OccurrenceInformation_All_HI_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_All_HI_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_All_HI_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OtherProcedureInformation_All_HI_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_All_HI_837IId",
                table: "HI",
                column: "HI_TreatmentCodeInformation_All_HI_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_All_HI_837IId",
                table: "HI",
                column: "HI_ValueInformation_All_HI_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_06Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_07Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_08Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_09Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_12Id");

            migrationBuilder.CreateIndex(
                name: "IX_CLM_CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id",
                table: "CLM",
                column: "CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_CLM_CLM_ClaimInformation_2_RelatedCausesInformation_11Id",
                table: "CLM",
                column: "CLM_ClaimInformation_2_RelatedCausesInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_CLM_CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id",
                table: "CLM",
                column: "CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_CLM_CLM_ClaimInformation_3_RelatedCausesInformation_11Id",
                table: "CLM",
                column: "CLM_ClaimInformation_3_RelatedCausesInformation_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_CAS_Loop_2320_837DId",
                table: "CAS",
                column: "Loop_2320_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_CAS_Loop_2320_837IId",
                table: "CAS",
                column: "Loop_2320_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_CAS_Loop_2430_837DId",
                table: "CAS",
                column: "Loop_2430_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_CAS_Loop_2430_837IId",
                table: "CAS",
                column: "Loop_2430_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837D_AMT_CoordinationofBenefits_COB_PayerPaidAmountId",
                table: "All_AMT_837D",
                column: "AMT_CoordinationofBenefits_COB_PayerPaidAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837D_AMT_CoordinationofBenefits_COB_TotalNon_AmountId",
                table: "All_AMT_837D",
                column: "AMT_CoordinationofBenefits_COB_TotalNon_AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837D_AMT_RemainingPatientLiabilityId",
                table: "All_AMT_837D",
                column: "AMT_RemainingPatientLiabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837I_AMT_FacilityTaxAmountId",
                table: "All_AMT_837I",
                column: "AMT_FacilityTaxAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837I_AMT_ServiceTaxAmountId",
                table: "All_AMT_837I",
                column: "AMT_ServiceTaxAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837I_2_AMT_CoordinationofBenefits_COB_PayerPaidAmountId",
                table: "All_AMT_837I_2",
                column: "AMT_CoordinationofBenefits_COB_PayerPaidAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837I_2_AMT_CoordinationofBenefits_COB_TotalNon_AmountId",
                table: "All_AMT_837I_2",
                column: "AMT_CoordinationofBenefits_COB_TotalNon_AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_All_AMT_837I_2_AMT_RemainingPatientLiabilityId",
                table: "All_AMT_837I_2",
                column: "AMT_RemainingPatientLiabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_DTP_Date_AppliancePlacementId",
                table: "All_DTP_837D",
                column: "DTP_Date_AppliancePlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_DTP_Date_PriorPlacementId",
                table: "All_DTP_837D",
                column: "DTP_Date_PriorPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_DTP_Date_ReplacementId",
                table: "All_DTP_837D",
                column: "DTP_Date_ReplacementId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_DTP_Date_ServiceDateId",
                table: "All_DTP_837D",
                column: "DTP_Date_ServiceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_DTP_Date_TreatmentCompletionId",
                table: "All_DTP_837D",
                column: "DTP_Date_TreatmentCompletionId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_DTP_Date_TreatmentStartId",
                table: "All_DTP_837D",
                column: "DTP_Date_TreatmentStartId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_2_DTP_Date_AccidentId",
                table: "All_DTP_837D_2",
                column: "DTP_Date_AccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_2_DTP_Date_AppliancePlacementId",
                table: "All_DTP_837D_2",
                column: "DTP_Date_AppliancePlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_2_DTP_Date_RepricerReceivedDateId",
                table: "All_DTP_837D_2",
                column: "DTP_Date_RepricerReceivedDateId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837D_2_DTP_Date_ServiceDateId",
                table: "All_DTP_837D_2",
                column: "DTP_Date_ServiceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837I_DTP_AdmissionDate_HourId",
                table: "All_DTP_837I",
                column: "DTP_AdmissionDate_HourId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837I_DTP_Date_RepricerReceivedDateId",
                table: "All_DTP_837I",
                column: "DTP_Date_RepricerReceivedDateId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837I_DTP_DischargeHourId",
                table: "All_DTP_837I",
                column: "DTP_DischargeHourId");

            migrationBuilder.CreateIndex(
                name: "IX_All_DTP_837I_DTP_StatementDatesId",
                table: "All_DTP_837I",
                column: "DTP_StatementDatesId");

            migrationBuilder.CreateIndex(
                name: "IX_All_HI_837I_HI_AdmittingDiagnosisId",
                table: "All_HI_837I",
                column: "HI_AdmittingDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_All_HI_837I_HI_DiagnosisRelatedGroup_DRG_InformationId",
                table: "All_HI_837I",
                column: "HI_DiagnosisRelatedGroup_DRG_InformationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_HI_837I_HI_ExternalCauseofInjuryId",
                table: "All_HI_837I",
                column: "HI_ExternalCauseofInjuryId");

            migrationBuilder.CreateIndex(
                name: "IX_All_HI_837I_HI_Patient_ReasonForVisitId",
                table: "All_HI_837I",
                column: "HI_Patient_ReasonForVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_All_HI_837I_HI_PrincipalDiagnosisId",
                table: "All_HI_837I",
                column: "HI_PrincipalDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_All_HI_837I_HI_PrincipalProcedureInformationId",
                table: "All_HI_837I",
                column: "HI_PrincipalProcedureInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_Loop2010AAId",
                table: "All_NM1_837D",
                column: "Loop2010AAId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_Loop2010ABId",
                table: "All_NM1_837D",
                column: "Loop2010ABId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_Loop2010ACId",
                table: "All_NM1_837D",
                column: "Loop2010ACId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_2_Loop2010BAId",
                table: "All_NM1_837D_2",
                column: "Loop2010BAId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_2_Loop2010BBId",
                table: "All_NM1_837D_2",
                column: "Loop2010BBId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_3_Loop2310BId",
                table: "All_NM1_837D_3",
                column: "Loop2310BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_3_Loop2310CId",
                table: "All_NM1_837D_3",
                column: "Loop2310CId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_3_Loop2310DId",
                table: "All_NM1_837D_3",
                column: "Loop2310DId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_3_Loop2310EId",
                table: "All_NM1_837D_3",
                column: "Loop2310EId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_4_Loop2330AId",
                table: "All_NM1_837D_4",
                column: "Loop2330AId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_4_Loop2330BId",
                table: "All_NM1_837D_4",
                column: "Loop2330BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_4_Loop2330DId",
                table: "All_NM1_837D_4",
                column: "Loop2330DId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_4_Loop2330EId",
                table: "All_NM1_837D_4",
                column: "Loop2330EId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_4_Loop2330FId",
                table: "All_NM1_837D_4",
                column: "Loop2330FId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_4_Loop2330GId",
                table: "All_NM1_837D_4",
                column: "Loop2330GId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_4_Loop2330HId",
                table: "All_NM1_837D_4",
                column: "Loop2330HId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_5_Loop2420AId",
                table: "All_NM1_837D_5",
                column: "Loop2420AId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_5_Loop2420BId",
                table: "All_NM1_837D_5",
                column: "Loop2420BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_5_Loop2420CId",
                table: "All_NM1_837D_5",
                column: "Loop2420CId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_5_Loop2420DId",
                table: "All_NM1_837D_5",
                column: "Loop2420DId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_6_Loop1000AId",
                table: "All_NM1_837D_6",
                column: "Loop1000AId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837D_6_Loop1000BId",
                table: "All_NM1_837D_6",
                column: "Loop1000BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_Loop2010AAId",
                table: "All_NM1_837I",
                column: "Loop2010AAId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_Loop2010ABId",
                table: "All_NM1_837I",
                column: "Loop2010ABId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_Loop2010ACId",
                table: "All_NM1_837I",
                column: "Loop2010ACId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_2_Loop2010BAId",
                table: "All_NM1_837I_2",
                column: "Loop2010BAId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_2_Loop2010BBId",
                table: "All_NM1_837I_2",
                column: "Loop2010BBId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_3_Loop2310AId",
                table: "All_NM1_837I_3",
                column: "Loop2310AId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_3_Loop2310BId",
                table: "All_NM1_837I_3",
                column: "Loop2310BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_3_Loop2310CId",
                table: "All_NM1_837I_3",
                column: "Loop2310CId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_3_Loop2310DId",
                table: "All_NM1_837I_3",
                column: "Loop2310DId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_3_Loop2310EId",
                table: "All_NM1_837I_3",
                column: "Loop2310EId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_3_Loop2310FId",
                table: "All_NM1_837I_3",
                column: "Loop2310FId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330AId",
                table: "All_NM1_837I_4",
                column: "Loop2330AId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330BId",
                table: "All_NM1_837I_4",
                column: "Loop2330BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330CId",
                table: "All_NM1_837I_4",
                column: "Loop2330CId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330DId",
                table: "All_NM1_837I_4",
                column: "Loop2330DId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330EId",
                table: "All_NM1_837I_4",
                column: "Loop2330EId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330FId",
                table: "All_NM1_837I_4",
                column: "Loop2330FId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330GId",
                table: "All_NM1_837I_4",
                column: "Loop2330GId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330HId",
                table: "All_NM1_837I_4",
                column: "Loop2330HId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_4_Loop2330IId",
                table: "All_NM1_837I_4",
                column: "Loop2330IId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_5_Loop2420AId",
                table: "All_NM1_837I_5",
                column: "Loop2420AId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_5_Loop2420BId",
                table: "All_NM1_837I_5",
                column: "Loop2420BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_5_Loop2420CId",
                table: "All_NM1_837I_5",
                column: "Loop2420CId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_5_Loop2420DId",
                table: "All_NM1_837I_5",
                column: "Loop2420DId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_6_Loop1000AId",
                table: "All_NM1_837I_6",
                column: "Loop1000AId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NM1_837I_6_Loop1000BId",
                table: "All_NM1_837I_6",
                column: "Loop1000BId");

            migrationBuilder.CreateIndex(
                name: "IX_All_NTE_837I_NTE_BillingNoteId",
                table: "All_NTE_837I",
                column: "NTE_BillingNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_REF_OtherPayerClaimAdjustmentIndicatorId",
                table: "All_REF_837D",
                column: "REF_OtherPayerClaimAdjustmentIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_REF_OtherPayerClaimControlNumberId",
                table: "All_REF_837D",
                column: "REF_OtherPayerClaimControlNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_REF_OtherPayerPredeterminationIdentificationId",
                table: "All_REF_837D",
                column: "REF_OtherPayerPredeterminationIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_REF_OtherPayerPriorAuthorizationNumberId",
                table: "All_REF_837D",
                column: "REF_OtherPayerPriorAuthorizationNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_REF_OtherPayerReferralNumberId",
                table: "All_REF_837D",
                column: "REF_OtherPayerReferralNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_2_REF_AdjustedRepricedClaimNumberId",
                table: "All_REF_837D_2",
                column: "REF_AdjustedRepricedClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_2_REF_LineItemControlNumberId",
                table: "All_REF_837D_2",
                column: "REF_LineItemControlNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_2_REF_RepricedClaimNumberId",
                table: "All_REF_837D_2",
                column: "REF_RepricedClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_3_REF_Pay_ToPlanSecondaryIdentificationId",
                table: "All_REF_837D_3",
                column: "REF_Pay_ToPlanSecondaryIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_3_REF_Pay_ToPlanTaxIdentificationNumberId",
                table: "All_REF_837D_3",
                column: "REF_Pay_ToPlanTaxIdentificationNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_4_REF_PropertyandCasualtyClaimNumberId",
                table: "All_REF_837D_4",
                column: "REF_PropertyandCasualtyClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_4_REF_SubscriberSecondaryIdentificationId",
                table: "All_REF_837D_4",
                column: "REF_SubscriberSecondaryIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_5_REF_BillingProviderSecondaryIdentificationId",
                table: "All_REF_837D_5",
                column: "REF_BillingProviderSecondaryIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_AdjustedRepricedClaimNumberId",
                table: "All_REF_837D_6",
                column: "REF_AdjustedRepricedClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_ClaimIdentifierForTransmissionIntermediariesId",
                table: "All_REF_837D_6",
                column: "REF_ClaimIdentifierForTransmissionIntermediariesId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_PayerClaimControlNumberId",
                table: "All_REF_837D_6",
                column: "REF_PayerClaimControlNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_PredeterminationIdentificationId",
                table: "All_REF_837D_6",
                column: "REF_PredeterminationIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_PriorAuthorizationId",
                table: "All_REF_837D_6",
                column: "REF_PriorAuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_ReferralNumberId",
                table: "All_REF_837D_6",
                column: "REF_ReferralNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_RepricedClaimNumberId",
                table: "All_REF_837D_6",
                column: "REF_RepricedClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_6_REF_ServiceAuthorizationExceptionCodeId",
                table: "All_REF_837D_6",
                column: "REF_ServiceAuthorizationExceptionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_7_REF_PropertyandCasualtyClaimNumberId",
                table: "All_REF_837D_7",
                column: "REF_PropertyandCasualtyClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_7_REF_PropertyandCasualtyPatientIdentifierId",
                table: "All_REF_837D_7",
                column: "REF_PropertyandCasualtyPatientIdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837D_8_REF_BillingProviderTaxIdentificationId",
                table: "All_REF_837D_8",
                column: "REF_BillingProviderTaxIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_REF_AdjustedRepricedLineItemReferenceNumberId",
                table: "All_REF_837I",
                column: "REF_AdjustedRepricedLineItemReferenceNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_REF_LineItemControlNumberId",
                table: "All_REF_837I",
                column: "REF_LineItemControlNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_REF_RepricedLineItemReferenceNumberId",
                table: "All_REF_837I",
                column: "REF_RepricedLineItemReferenceNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_2_REF_PropertyandCasualtyClaimNumberId",
                table: "All_REF_837I_2",
                column: "REF_PropertyandCasualtyClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_2_REF_SubscriberSecondaryIdentificationId",
                table: "All_REF_837I_2",
                column: "REF_SubscriberSecondaryIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_3_REF_BillingProviderSecondaryIdentificationId",
                table: "All_REF_837I_3",
                column: "REF_BillingProviderSecondaryIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_AdjustedRepricedClaimNumberId",
                table: "All_REF_837I_4",
                column: "REF_AdjustedRepricedClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_AutoAccidentStateId",
                table: "All_REF_837I_4",
                column: "REF_AutoAccidentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_ClaimIdentifierForTransmissionIntermediariesId",
                table: "All_REF_837I_4",
                column: "REF_ClaimIdentifierForTransmissionIntermediariesId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_DemonstrationProjectIdentifierId",
                table: "All_REF_837I_4",
                column: "REF_DemonstrationProjectIdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_MedicalRecordNumberId",
                table: "All_REF_837I_4",
                column: "REF_MedicalRecordNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_PayerClaimControlNumberId",
                table: "All_REF_837I_4",
                column: "REF_PayerClaimControlNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_PeerReviewOrganization_PRO_ApprovalNumberId",
                table: "All_REF_837I_4",
                column: "REF_PeerReviewOrganization_PRO_ApprovalNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_PriorAuthorizationId",
                table: "All_REF_837I_4",
                column: "REF_PriorAuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_ReferralNumberId",
                table: "All_REF_837I_4",
                column: "REF_ReferralNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_RepricedClaimNumberId",
                table: "All_REF_837I_4",
                column: "REF_RepricedClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_4_REF_ServiceAuthorizationExceptionCodeId",
                table: "All_REF_837I_4",
                column: "REF_ServiceAuthorizationExceptionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_5_REF_OtherPayerClaimAdjustmentIndicatorId",
                table: "All_REF_837I_5",
                column: "REF_OtherPayerClaimAdjustmentIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_5_REF_OtherPayerClaimControlNumberId",
                table: "All_REF_837I_5",
                column: "REF_OtherPayerClaimControlNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_5_REF_OtherPayerPriorAuthorizationNumberId",
                table: "All_REF_837I_5",
                column: "REF_OtherPayerPriorAuthorizationNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_5_REF_OtherPayerReferralNumberId",
                table: "All_REF_837I_5",
                column: "REF_OtherPayerReferralNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_6_REF_PropertyandCasualtyClaimNumberId",
                table: "All_REF_837I_6",
                column: "REF_PropertyandCasualtyClaimNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_6_REF_PropertyandCasualtyPatientIdentifierId",
                table: "All_REF_837I_6",
                column: "REF_PropertyandCasualtyPatientIdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_7_REF_Pay_ToPlanSecondaryIdentificationId",
                table: "All_REF_837I_7",
                column: "REF_Pay_ToPlanSecondaryIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_All_REF_837I_7_REF_Pay_ToTaxIdentificationNumberId",
                table: "All_REF_837I_7",
                column: "REF_Pay_ToTaxIdentificationNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_DN2_ToothStatus_Loop_2300_837DId",
                table: "DN2_ToothStatus",
                column: "Loop_2300_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_1000A_837D_NM1_SubmitterNameId",
                table: "Loop_1000A_837D",
                column: "NM1_SubmitterNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_1000A_837I_NM1_SubmitterNameId",
                table: "Loop_1000A_837I",
                column: "NM1_SubmitterNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_1000B_837D_NM1_ReceiverNameId",
                table: "Loop_1000B_837D",
                column: "NM1_ReceiverNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_1000B_837I_NM1_ReceiverNameId",
                table: "Loop_1000B_837I",
                column: "NM1_ReceiverNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837D_AllNM1Id",
                table: "Loop_2000A_837D",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837D_CUR_ForeignCurrencyInformationId",
                table: "Loop_2000A_837D",
                column: "CUR_ForeignCurrencyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837D_HL_BillingProviderHierarchicalLevelId",
                table: "Loop_2000A_837D",
                column: "HL_BillingProviderHierarchicalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837D_PRV_BillingProviderSpecialtyInformationId",
                table: "Loop_2000A_837D",
                column: "PRV_BillingProviderSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837D_TS837DId",
                table: "Loop_2000A_837D",
                column: "TS837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837I_AllNM1Id",
                table: "Loop_2000A_837I",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837I_CUR_ForeignCurrencyInformationId",
                table: "Loop_2000A_837I",
                column: "CUR_ForeignCurrencyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837I_HL_BillingProviderHierarchicalLevelId",
                table: "Loop_2000A_837I",
                column: "HL_BillingProviderHierarchicalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837I_PRV_BillingProviderSpecialtyInformationId",
                table: "Loop_2000A_837I",
                column: "PRV_BillingProviderSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000A_837I_TS837IId",
                table: "Loop_2000A_837I",
                column: "TS837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837D_AllNM1Id",
                table: "Loop_2000B_837D",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837D_HL_SubscriberHierarchicalLevelId",
                table: "Loop_2000B_837D",
                column: "HL_SubscriberHierarchicalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837D_Loop_2000A_837DId",
                table: "Loop_2000B_837D",
                column: "Loop_2000A_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837D_SBR_SubscriberInformationId",
                table: "Loop_2000B_837D",
                column: "SBR_SubscriberInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837I_AllNM1Id",
                table: "Loop_2000B_837I",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837I_HL_SubscriberHierarchicalLevelId",
                table: "Loop_2000B_837I",
                column: "HL_SubscriberHierarchicalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837I_Loop_2000A_837IId",
                table: "Loop_2000B_837I",
                column: "Loop_2000A_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000B_837I_SBR_SubscriberInformationId",
                table: "Loop_2000B_837I",
                column: "SBR_SubscriberInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837D_HL_PatientHierarchicalLevelId",
                table: "Loop_2000C_837D",
                column: "HL_PatientHierarchicalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837D_Loop_2000B_837DId",
                table: "Loop_2000C_837D",
                column: "Loop_2000B_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837D_Loop2010CAId",
                table: "Loop_2000C_837D",
                column: "Loop2010CAId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837D_PAT_PatientInformationId",
                table: "Loop_2000C_837D",
                column: "PAT_PatientInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837I_HL_PatientHierarchicalLevelId",
                table: "Loop_2000C_837I",
                column: "HL_PatientHierarchicalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837I_Loop_2000B_837IId",
                table: "Loop_2000C_837I",
                column: "Loop_2000B_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837I_Loop2010CAId",
                table: "Loop_2000C_837I",
                column: "Loop2010CAId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2000C_837I_PAT_PatientInformationId",
                table: "Loop_2000C_837I",
                column: "PAT_PatientInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837D_AllREFId",
                table: "Loop_2010AA_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837D_N3_BillingProviderAddressId",
                table: "Loop_2010AA_837D",
                column: "N3_BillingProviderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837D_N4_BillingProviderCity_State_ZIPCodeId",
                table: "Loop_2010AA_837D",
                column: "N4_BillingProviderCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837D_NM1_BillingProviderNameId",
                table: "Loop_2010AA_837D",
                column: "NM1_BillingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837I_N3_BillingProviderAddressId",
                table: "Loop_2010AA_837I",
                column: "N3_BillingProviderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837I_N4_BillingProviderCity_State_ZIPCodeId",
                table: "Loop_2010AA_837I",
                column: "N4_BillingProviderCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837I_NM1_BillingProviderNameId",
                table: "Loop_2010AA_837I",
                column: "NM1_BillingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AA_837I_REF_BillingProviderTaxIdentificationId",
                table: "Loop_2010AA_837I",
                column: "REF_BillingProviderTaxIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AB_837D_N3_Pay_Address_ADDRESSId",
                table: "Loop_2010AB_837D",
                column: "N3_Pay_Address_ADDRESSId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AB_837D_N4_Pay_Address_City_State_ZIPCodeId",
                table: "Loop_2010AB_837D",
                column: "N4_Pay_Address_City_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AB_837D_NM1_Pay_AddressNameId",
                table: "Loop_2010AB_837D",
                column: "NM1_Pay_AddressNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AB_837I_N3_Pay_ToAddress_ADDRESSId",
                table: "Loop_2010AB_837I",
                column: "N3_Pay_ToAddress_ADDRESSId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AB_837I_N4_Pay_AddressCity_State_ZIPCodeId",
                table: "Loop_2010AB_837I",
                column: "N4_Pay_AddressCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AB_837I_NM1_Pay_AddressNameId",
                table: "Loop_2010AB_837I",
                column: "NM1_Pay_AddressNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837D_AllREFId",
                table: "Loop_2010AC_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837D_N3_Pay_ToPlanAddressId",
                table: "Loop_2010AC_837D",
                column: "N3_Pay_ToPlanAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837D_N4_Pay_ToPlanCity_State_ZipCodeId",
                table: "Loop_2010AC_837D",
                column: "N4_Pay_ToPlanCity_State_ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837D_NM1_Pay_ToPlanNameId",
                table: "Loop_2010AC_837D",
                column: "NM1_Pay_ToPlanNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837I_AllREFId",
                table: "Loop_2010AC_837I",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837I_N3_Pay_ToPlanAddressId",
                table: "Loop_2010AC_837I",
                column: "N3_Pay_ToPlanAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837I_N4_Pay_ToPlanCity_State_ZipCodeId",
                table: "Loop_2010AC_837I",
                column: "N4_Pay_ToPlanCity_State_ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010AC_837I_NM1_Pay_ToPlanNameId",
                table: "Loop_2010AC_837I",
                column: "NM1_Pay_ToPlanNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837D_AllREFId",
                table: "Loop_2010BA_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837D_DMG_SubscriberDemographicInformationId",
                table: "Loop_2010BA_837D",
                column: "DMG_SubscriberDemographicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837D_N3_SubscriberAddressId",
                table: "Loop_2010BA_837D",
                column: "N3_SubscriberAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837D_N4_SubscriberCity_State_ZIPCodeId",
                table: "Loop_2010BA_837D",
                column: "N4_SubscriberCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837D_NM1_SubscriberNameId",
                table: "Loop_2010BA_837D",
                column: "NM1_SubscriberNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837I_AllREFId",
                table: "Loop_2010BA_837I",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837I_DMG_SubscriberDemographicInformationId",
                table: "Loop_2010BA_837I",
                column: "DMG_SubscriberDemographicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837I_N3_SubscriberAddressId",
                table: "Loop_2010BA_837I",
                column: "N3_SubscriberAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837I_N4_SubscriberCity_State_ZIPCodeId",
                table: "Loop_2010BA_837I",
                column: "N4_SubscriberCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BA_837I_NM1_SubscriberNameId",
                table: "Loop_2010BA_837I",
                column: "NM1_SubscriberNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837D_AllREFId",
                table: "Loop_2010BB_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837D_N3_PayerAddressId",
                table: "Loop_2010BB_837D",
                column: "N3_PayerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837D_N4_PayerCity_State_ZIPCodeId",
                table: "Loop_2010BB_837D",
                column: "N4_PayerCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837D_NM1_PayerNameId",
                table: "Loop_2010BB_837D",
                column: "NM1_PayerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837I_AllREFId",
                table: "Loop_2010BB_837I",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837I_N3_PayerAddressId",
                table: "Loop_2010BB_837I",
                column: "N3_PayerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837I_N4_PayerCity_State_ZIPCodeId",
                table: "Loop_2010BB_837I",
                column: "N4_PayerCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010BB_837I_NM1_PayerNameId",
                table: "Loop_2010BB_837I",
                column: "NM1_PayerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837D_AllREFId",
                table: "Loop_2010CA_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837D_DMG_PatientDemographicInformationId",
                table: "Loop_2010CA_837D",
                column: "DMG_PatientDemographicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837D_N3_PatientAddressId",
                table: "Loop_2010CA_837D",
                column: "N3_PatientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837D_N4_PatientCity_State_ZIPCodeId",
                table: "Loop_2010CA_837D",
                column: "N4_PatientCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837D_NM1_PatientNameId",
                table: "Loop_2010CA_837D",
                column: "NM1_PatientNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837I_AllREFId",
                table: "Loop_2010CA_837I",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837I_DMG_PatientDemographicInformationId",
                table: "Loop_2010CA_837I",
                column: "DMG_PatientDemographicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837I_N3_PatientAddressId",
                table: "Loop_2010CA_837I",
                column: "N3_PatientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837I_N4_PatientCity_State_ZIPCodeId",
                table: "Loop_2010CA_837I",
                column: "N4_PatientCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2010CA_837I_NM1_PatientNameId",
                table: "Loop_2010CA_837I",
                column: "NM1_PatientNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_AllDTPId",
                table: "Loop_2300_837D",
                column: "AllDTPId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_AllNM1Id",
                table: "Loop_2300_837D",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_AllREFId",
                table: "Loop_2300_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_AMT_PatientAmountPaidId",
                table: "Loop_2300_837D",
                column: "AMT_PatientAmountPaidId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_CLM_ClaimInformationId",
                table: "Loop_2300_837D",
                column: "CLM_ClaimInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_CN1_ContractInformationId",
                table: "Loop_2300_837D",
                column: "CN1_ContractInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_DN1_OrthodonticTotalMonthsofTreatmentId",
                table: "Loop_2300_837D",
                column: "DN1_OrthodonticTotalMonthsofTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_HCP_ClaimPricing_RepricingInformationId",
                table: "Loop_2300_837D",
                column: "HCP_ClaimPricing_RepricingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_HI_HealthCareDiagnosisCodeId",
                table: "Loop_2300_837D",
                column: "HI_HealthCareDiagnosisCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_Loop_2000B_837DId",
                table: "Loop_2300_837D",
                column: "Loop_2000B_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837D_Loop_2000C_837DId",
                table: "Loop_2300_837D",
                column: "Loop_2000C_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_AllDTPId",
                table: "Loop_2300_837I",
                column: "AllDTPId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_AllHIId",
                table: "Loop_2300_837I",
                column: "AllHIId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_AllNM1Id",
                table: "Loop_2300_837I",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_AllNTEId",
                table: "Loop_2300_837I",
                column: "AllNTEId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_AllREFId",
                table: "Loop_2300_837I",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_AMT_PatientEstimatedAmountDueId",
                table: "Loop_2300_837I",
                column: "AMT_PatientEstimatedAmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_CL1_InstitutionalClaimCodeId",
                table: "Loop_2300_837I",
                column: "CL1_InstitutionalClaimCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_CLM_ClaimInformationId",
                table: "Loop_2300_837I",
                column: "CLM_ClaimInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_CN1_ContractInformationId",
                table: "Loop_2300_837I",
                column: "CN1_ContractInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_CRC_EPSDTReferralId",
                table: "Loop_2300_837I",
                column: "CRC_EPSDTReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_HCP_ClaimPricing_RepricingInformationId",
                table: "Loop_2300_837I",
                column: "HCP_ClaimPricing_RepricingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_Loop_2000B_837IId",
                table: "Loop_2300_837I",
                column: "Loop_2000B_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2300_837I_Loop_2000C_837IId",
                table: "Loop_2300_837I",
                column: "Loop_2000C_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310A_837D_All_NM1_837D_3Id",
                table: "Loop_2310A_837D",
                column: "All_NM1_837D_3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310A_837D_NM1_ReferringProviderNameId",
                table: "Loop_2310A_837D",
                column: "NM1_ReferringProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310A_837D_PRV_ReferringProviderSpecialtyInformationId",
                table: "Loop_2310A_837D",
                column: "PRV_ReferringProviderSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310A_837I_NM1_AttendingProviderNameId",
                table: "Loop_2310A_837I",
                column: "NM1_AttendingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310A_837I_PRV_AttendingProviderSpecialtyInformationId",
                table: "Loop_2310A_837I",
                column: "PRV_AttendingProviderSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310B_837D_NM1_RenderingProviderNameId",
                table: "Loop_2310B_837D",
                column: "NM1_RenderingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310B_837D_PRV_RenderingProviderSpecialtyInformationId",
                table: "Loop_2310B_837D",
                column: "PRV_RenderingProviderSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310B_837I_NM1_OperatingPhysicianNameId",
                table: "Loop_2310B_837I",
                column: "NM1_OperatingPhysicianNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310C_837D_N3_ServiceFacilityLocationAddressId",
                table: "Loop_2310C_837D",
                column: "N3_ServiceFacilityLocationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310C_837D_N4_ServiceFacilityLocationCity_State_ZipCodeId",
                table: "Loop_2310C_837D",
                column: "N4_ServiceFacilityLocationCity_State_ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310C_837D_NM1_ServiceFacilityLocationNameId",
                table: "Loop_2310C_837D",
                column: "NM1_ServiceFacilityLocationNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310C_837I_NM1_OtherOperatingPhysicianNameId",
                table: "Loop_2310C_837I",
                column: "NM1_OtherOperatingPhysicianNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310D_837D_NM1_AssistantSurgeonNameId",
                table: "Loop_2310D_837D",
                column: "NM1_AssistantSurgeonNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310D_837D_PRV_AssistantSurgeonSpecialtyInformationId",
                table: "Loop_2310D_837D",
                column: "PRV_AssistantSurgeonSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310D_837I_NM1_RenderingProviderNameId",
                table: "Loop_2310D_837I",
                column: "NM1_RenderingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310E_837D_NM1_SupervisingProviderNameId",
                table: "Loop_2310E_837D",
                column: "NM1_SupervisingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310E_837I_N3_ServiceFacilityLocationAddressId",
                table: "Loop_2310E_837I",
                column: "N3_ServiceFacilityLocationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310E_837I_N4_ServiceFacilityLocationCity_State_ZIPId",
                table: "Loop_2310E_837I",
                column: "N4_ServiceFacilityLocationCity_State_ZIPId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310E_837I_NM1_ServiceFacilityLocationNameId",
                table: "Loop_2310E_837I",
                column: "NM1_ServiceFacilityLocationNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2310F_837I_NM1_ReferringProviderNameId",
                table: "Loop_2310F_837I",
                column: "NM1_ReferringProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837D_AllAMTId",
                table: "Loop_2320_837D",
                column: "AllAMTId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837D_AllNM1Id",
                table: "Loop_2320_837D",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837D_Loop_2300_837DId",
                table: "Loop_2320_837D",
                column: "Loop_2300_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837D_MOA_OutpatientAdjudicationInformationId",
                table: "Loop_2320_837D",
                column: "MOA_OutpatientAdjudicationInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837D_OI_OtherInsuranceCoverageInformationId",
                table: "Loop_2320_837D",
                column: "OI_OtherInsuranceCoverageInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837D_SBR_OtherSubscriberInformationId",
                table: "Loop_2320_837D",
                column: "SBR_OtherSubscriberInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837I_AllAMTId",
                table: "Loop_2320_837I",
                column: "AllAMTId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837I_AllNM1Id",
                table: "Loop_2320_837I",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837I_Loop_2300_837IId",
                table: "Loop_2320_837I",
                column: "Loop_2300_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837I_MIA_InpatientAdjudicationInformationId",
                table: "Loop_2320_837I",
                column: "MIA_InpatientAdjudicationInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837I_MOA_OutpatientAdjudicationInformationId",
                table: "Loop_2320_837I",
                column: "MOA_OutpatientAdjudicationInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837I_OI_OtherInsuranceCoverageInformationId",
                table: "Loop_2320_837I",
                column: "OI_OtherInsuranceCoverageInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2320_837I_SBR_OtherSubscriberInformationId",
                table: "Loop_2320_837I",
                column: "SBR_OtherSubscriberInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330A_837D_N3_OtherSubscriberAddressId",
                table: "Loop_2330A_837D",
                column: "N3_OtherSubscriberAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330A_837D_N4_OtherSubscriberCity_State_ZipCodeId",
                table: "Loop_2330A_837D",
                column: "N4_OtherSubscriberCity_State_ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330A_837D_NM1_OtherSubscriberNameId",
                table: "Loop_2330A_837D",
                column: "NM1_OtherSubscriberNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330A_837I_N3_OtherSubscriberAddressId",
                table: "Loop_2330A_837I",
                column: "N3_OtherSubscriberAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330A_837I_N4_OtherSubscriberCity_State_ZIPCodeId",
                table: "Loop_2330A_837I",
                column: "N4_OtherSubscriberCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330A_837I_NM1_OtherSubscriberNameId",
                table: "Loop_2330A_837I",
                column: "NM1_OtherSubscriberNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837D_AllREFId",
                table: "Loop_2330B_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837D_DTP_ClaimCheckOrRemittanceDateId",
                table: "Loop_2330B_837D",
                column: "DTP_ClaimCheckOrRemittanceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837D_N3_OtherPayerAddressId",
                table: "Loop_2330B_837D",
                column: "N3_OtherPayerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837D_N4_OtherPayerCity_State_ZIPCodeId",
                table: "Loop_2330B_837D",
                column: "N4_OtherPayerCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837D_NM1_OtherPayerNameId",
                table: "Loop_2330B_837D",
                column: "NM1_OtherPayerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837I_AllREFId",
                table: "Loop_2330B_837I",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837I_DTP_ClaimCheckOrRemittanceDateId",
                table: "Loop_2330B_837I",
                column: "DTP_ClaimCheckOrRemittanceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837I_N3_OtherPayerAddressId",
                table: "Loop_2330B_837I",
                column: "N3_OtherPayerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837I_N4_OtherPayerCity_State_ZIPCodeId",
                table: "Loop_2330B_837I",
                column: "N4_OtherPayerCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330B_837I_NM1_OtherPayerNameId",
                table: "Loop_2330B_837I",
                column: "NM1_OtherPayerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330C_837D_All_NM1_837D_4Id",
                table: "Loop_2330C_837D",
                column: "All_NM1_837D_4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330C_837D_NM1_OtherPayerReferringProviderId",
                table: "Loop_2330C_837D",
                column: "NM1_OtherPayerReferringProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330C_837I_NM1_OtherPayerAttendingProviderId",
                table: "Loop_2330C_837I",
                column: "NM1_OtherPayerAttendingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330D_837D_NM1_OtherPayerRenderingProviderId",
                table: "Loop_2330D_837D",
                column: "NM1_OtherPayerRenderingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330D_837I_NM1_OtherPayerOperatingPhysicianId",
                table: "Loop_2330D_837I",
                column: "NM1_OtherPayerOperatingPhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330E_837D_NM1_OtherPayerSupervisingProviderId",
                table: "Loop_2330E_837D",
                column: "NM1_OtherPayerSupervisingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330E_837I_NM1_OtherPayerOtherOperatingPhysicianId",
                table: "Loop_2330E_837I",
                column: "NM1_OtherPayerOtherOperatingPhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330F_837D_NM1_OtherPayerBillingProviderId",
                table: "Loop_2330F_837D",
                column: "NM1_OtherPayerBillingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330F_837I_NM1_OtherPayerServiceFacilityLocationId",
                table: "Loop_2330F_837I",
                column: "NM1_OtherPayerServiceFacilityLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330G_837D_NM1_OtherPayerServiceFacilityLocationId",
                table: "Loop_2330G_837D",
                column: "NM1_OtherPayerServiceFacilityLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330G_837I_NM1_OtherPayerRenderingProviderNameId",
                table: "Loop_2330G_837I",
                column: "NM1_OtherPayerRenderingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330H_837D_NM1_OtherPayerAssistantSurgeonId",
                table: "Loop_2330H_837D",
                column: "NM1_OtherPayerAssistantSurgeonId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330H_837I_NM1_OtherPayerReferringProviderId",
                table: "Loop_2330H_837I",
                column: "NM1_OtherPayerReferringProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2330I_837I_NM1_OtherPayerBillingProviderId",
                table: "Loop_2330I_837I",
                column: "NM1_OtherPayerBillingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_AllDTPId",
                table: "Loop_2400_837D",
                column: "AllDTPId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_AllNM1Id",
                table: "Loop_2400_837D",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_AllREFId",
                table: "Loop_2400_837D",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_AMT_SalesTaxAmountId",
                table: "Loop_2400_837D",
                column: "AMT_SalesTaxAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_CN1_ContractInformationId",
                table: "Loop_2400_837D",
                column: "CN1_ContractInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_HCP_LinePricing_RepricingInformationId",
                table: "Loop_2400_837D",
                column: "HCP_LinePricing_RepricingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_Loop_2300_837DId",
                table: "Loop_2400_837D",
                column: "Loop_2300_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_LX_ServiceLineNumberId",
                table: "Loop_2400_837D",
                column: "LX_ServiceLineNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837D_SV3_DentalServiceId",
                table: "Loop_2400_837D",
                column: "SV3_DentalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_AllAMTId",
                table: "Loop_2400_837I",
                column: "AllAMTId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_AllNM1Id",
                table: "Loop_2400_837I",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_AllREFId",
                table: "Loop_2400_837I",
                column: "AllREFId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_DTP_Date_ServiceDateId",
                table: "Loop_2400_837I",
                column: "DTP_Date_ServiceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_HCP_LinePricing_RepricingInformationId",
                table: "Loop_2400_837I",
                column: "HCP_LinePricing_RepricingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_Loop_2300_837IId",
                table: "Loop_2400_837I",
                column: "Loop_2300_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_Loop2410Id",
                table: "Loop_2400_837I",
                column: "Loop2410Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_LX_ServiceLineNumberId",
                table: "Loop_2400_837I",
                column: "LX_ServiceLineNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_NTE_ThirdPartyOrganizationNotesId",
                table: "Loop_2400_837I",
                column: "NTE_ThirdPartyOrganizationNotesId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2400_837I_SV2_InstitutionalServiceLineId",
                table: "Loop_2400_837I",
                column: "SV2_InstitutionalServiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2410_837I_CTP_DrugQuantityId",
                table: "Loop_2410_837I",
                column: "CTP_DrugQuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2410_837I_LIN_DrugIdentificationId",
                table: "Loop_2410_837I",
                column: "LIN_DrugIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2410_837I_REF_PrescriptionorCompoundDrugAssociationNumberId",
                table: "Loop_2410_837I",
                column: "REF_PrescriptionorCompoundDrugAssociationNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420A_837D_NM1_RenderingProviderNameId",
                table: "Loop_2420A_837D",
                column: "NM1_RenderingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420A_837D_PRV_RenderingProviderSpecialtyInformationId",
                table: "Loop_2420A_837D",
                column: "PRV_RenderingProviderSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420A_837I_NM1_OperatingPhysicianNameId",
                table: "Loop_2420A_837I",
                column: "NM1_OperatingPhysicianNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420B_837D_NM1_AssistantSurgeonNameId",
                table: "Loop_2420B_837D",
                column: "NM1_AssistantSurgeonNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420B_837D_PRV_AssistantSurgeonSpecialtyInformationId",
                table: "Loop_2420B_837D",
                column: "PRV_AssistantSurgeonSpecialtyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420B_837I_NM1_OtherOperatingPhysicianNameId",
                table: "Loop_2420B_837I",
                column: "NM1_OtherOperatingPhysicianNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420C_837D_NM1_SupervisingProviderNameId",
                table: "Loop_2420C_837D",
                column: "NM1_SupervisingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420C_837I_NM1_RenderingProviderNameId",
                table: "Loop_2420C_837I",
                column: "NM1_RenderingProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420D_837D_N3_ServiceFacilityLocationAddressId",
                table: "Loop_2420D_837D",
                column: "N3_ServiceFacilityLocationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420D_837D_N4_ServiceFacilityLocationCity_State_ZIPCodeId",
                table: "Loop_2420D_837D",
                column: "N4_ServiceFacilityLocationCity_State_ZIPCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420D_837D_NM1_ServiceFacilityLocationNameId",
                table: "Loop_2420D_837D",
                column: "NM1_ServiceFacilityLocationNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2420D_837I_NM1_ReferringProviderNameId",
                table: "Loop_2420D_837I",
                column: "NM1_ReferringProviderNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837D_AMT_RemainingPatientLiabilityId",
                table: "Loop_2430_837D",
                column: "AMT_RemainingPatientLiabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837D_DTP_LineCheckorRemittanceDateId",
                table: "Loop_2430_837D",
                column: "DTP_LineCheckorRemittanceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837D_Loop_2400_837DId",
                table: "Loop_2430_837D",
                column: "Loop_2400_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837D_SVD_LineAdjudicationInformationId",
                table: "Loop_2430_837D",
                column: "SVD_LineAdjudicationInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837I_AMT_RemainingPatientLiabilityId",
                table: "Loop_2430_837I",
                column: "AMT_RemainingPatientLiabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837I_DTP_LineCheckorRemittanceDateId",
                table: "Loop_2430_837I",
                column: "DTP_LineCheckorRemittanceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837I_Loop_2400_837IId",
                table: "Loop_2430_837I",
                column: "Loop_2400_837IId");

            migrationBuilder.CreateIndex(
                name: "IX_Loop_2430_837I_SVD_LineAdjudicationInformationId",
                table: "Loop_2430_837I",
                column: "SVD_LineAdjudicationInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SV2_InstitutionalServiceLine_CompositeMedicalProcedureIdentifier_02Id",
                table: "SV2_InstitutionalServiceLine",
                column: "CompositeMedicalProcedureIdentifier_02Id");

            migrationBuilder.CreateIndex(
                name: "IX_SV3_DentalService_CompositeDiagnosisCodePointer_11Id",
                table: "SV3_DentalService",
                column: "CompositeDiagnosisCodePointer_11Id");

            migrationBuilder.CreateIndex(
                name: "IX_SV3_DentalService_CompositeMedicalProcedureIdentifier_01Id",
                table: "SV3_DentalService",
                column: "CompositeMedicalProcedureIdentifier_01Id");

            migrationBuilder.CreateIndex(
                name: "IX_SV3_DentalService_OralCavityDesignation_04Id",
                table: "SV3_DentalService",
                column: "OralCavityDesignation_04Id");

            migrationBuilder.CreateIndex(
                name: "IX_TOO_ToothInformation_Loop_2400_837DId",
                table: "TOO_ToothInformation",
                column: "Loop_2400_837DId");

            migrationBuilder.CreateIndex(
                name: "IX_TOO_ToothInformation_ToothSurface_03Id",
                table: "TOO_ToothInformation",
                column: "ToothSurface_03Id");

            migrationBuilder.CreateIndex(
                name: "IX_TS837D_AllNM1Id",
                table: "TS837D",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_TS837D_BHT_BeginningOfHierarchicalTransactionId",
                table: "TS837D",
                column: "BHT_BeginningOfHierarchicalTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TS837D_SEId",
                table: "TS837D",
                column: "SEId");

            migrationBuilder.CreateIndex(
                name: "IX_TS837D_STId",
                table: "TS837D",
                column: "STId");

            migrationBuilder.CreateIndex(
                name: "IX_TS837I_AllNM1Id",
                table: "TS837I",
                column: "AllNM1Id");

            migrationBuilder.CreateIndex(
                name: "IX_TS837I_BHT_BeginningOfHierarchicalTransactionId",
                table: "TS837I",
                column: "BHT_BeginningOfHierarchicalTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TS837I_SEId",
                table: "TS837I",
                column: "SEId");

            migrationBuilder.CreateIndex(
                name: "IX_TS837I_STId",
                table: "TS837I",
                column: "STId");

            migrationBuilder.AddForeignKey(
                name: "FK_CAS_Loop_2320_837D_Loop_2320_837DId",
                table: "CAS",
                column: "Loop_2320_837DId",
                principalTable: "Loop_2320_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CAS_Loop_2320_837I_Loop_2320_837IId",
                table: "CAS",
                column: "Loop_2320_837IId",
                principalTable: "Loop_2320_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CAS_Loop_2430_837D_Loop_2430_837DId",
                table: "CAS",
                column: "Loop_2430_837DId",
                principalTable: "Loop_2430_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CAS_Loop_2430_837I_Loop_2430_837IId",
                table: "CAS",
                column: "Loop_2430_837IId",
                principalTable: "Loop_2430_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CLM_C023_CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id",
                table: "CLM",
                column: "CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id",
                principalTable: "C023",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CLM_C023_CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id",
                table: "CLM",
                column: "CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id",
                principalTable: "C023",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CLM_C024_CLM_ClaimInformation_2_RelatedCausesInformation_11Id",
                table: "CLM",
                column: "CLM_ClaimInformation_2_RelatedCausesInformation_11Id",
                principalTable: "C024",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CLM_C024_CLM_ClaimInformation_3_RelatedCausesInformation_11Id",
                table: "CLM",
                column: "CLM_ClaimInformation_3_RelatedCausesInformation_11Id",
                principalTable: "C024",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_All_HI_837I_All_HI_837IId",
                table: "HI",
                column: "All_HI_837IId",
                principalTable: "All_HI_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_All_HI_837I_HI_OccurrenceInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OccurrenceInformation_All_HI_837IId",
                principalTable: "All_HI_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_All_HI_837I_HI_OccurrenceSpanInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_All_HI_837IId",
                principalTable: "All_HI_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_All_HI_837I_HI_OtherDiagnosisInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_All_HI_837IId",
                principalTable: "All_HI_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_All_HI_837I_HI_OtherProcedureInformation_All_HI_837IId",
                table: "HI",
                column: "HI_OtherProcedureInformation_All_HI_837IId",
                principalTable: "All_HI_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_All_HI_837I_HI_TreatmentCodeInformation_All_HI_837IId",
                table: "HI",
                column: "HI_TreatmentCodeInformation_All_HI_837IId",
                principalTable: "All_HI_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_All_HI_837I_HI_ValueInformation_All_HI_837IId",
                table: "HI",
                column: "HI_ValueInformation_All_HI_837IId",
                principalTable: "All_HI_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OccurrenceInformation_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_OtherProcedureInformation_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_Patient_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_01Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_01Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_02Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_02Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_03Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_03Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_04Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_04Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_05Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_05Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_06Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_06Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_07Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_07Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_08Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_08Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_09Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_09Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_10Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_10Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_11Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_11Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_12Id",
                table: "HI",
                column: "HI_ValueInformation_HealthCareCodeInformation_12Id",
                principalTable: "C022",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_K3_Loop_2300_837D_Loop_2300_837DId",
                table: "K3",
                column: "Loop_2300_837DId",
                principalTable: "Loop_2300_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_K3_Loop_2300_837I_Loop_2300_837IId",
                table: "K3",
                column: "Loop_2300_837IId",
                principalTable: "Loop_2300_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_K3_Loop_2400_837D_Loop_2400_837DId",
                table: "K3",
                column: "Loop_2400_837DId",
                principalTable: "Loop_2400_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NTE_All_NTE_837I_All_NTE_837IId",
                table: "NTE",
                column: "All_NTE_837IId",
                principalTable: "All_NTE_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NTE_Loop_2300_837D_Loop_2300_837DId",
                table: "NTE",
                column: "Loop_2300_837DId",
                principalTable: "Loop_2300_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PER_Loop_1000A_837D_Loop_1000A_837DId",
                table: "PER",
                column: "Loop_1000A_837DId",
                principalTable: "Loop_1000A_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PER_Loop_1000A_837I_Loop_1000A_837IId",
                table: "PER",
                column: "Loop_1000A_837IId",
                principalTable: "Loop_1000A_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PER_Loop_2010AA_837D_Loop_2010AA_837DId",
                table: "PER",
                column: "Loop_2010AA_837DId",
                principalTable: "Loop_2010AA_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PER_Loop_2010AA_837I_Loop_2010AA_837IId",
                table: "PER",
                column: "Loop_2010AA_837IId",
                principalTable: "Loop_2010AA_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PRV_C035_PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                column: "PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                principalTable: "C035",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PRV_C035_PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                column: "PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                principalTable: "C035",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PRV_C035_PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV",
                column: "PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                principalTable: "C035",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PWK_C002_PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id",
                table: "PWK",
                column: "PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id",
                principalTable: "C002",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PWK_Loop_2300_837D_Loop_2300_837DId",
                table: "PWK",
                column: "Loop_2300_837DId",
                principalTable: "Loop_2300_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PWK_Loop_2300_837I_Loop_2300_837IId",
                table: "PWK",
                column: "Loop_2300_837IId",
                principalTable: "Loop_2300_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PWK_Loop_2400_837I_Loop_2400_837IId",
                table: "PWK",
                column: "Loop_2400_837IId",
                principalTable: "Loop_2400_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837D_2_All_REF_837D_2Id",
                table: "REF",
                column: "All_REF_837D_2Id",
                principalTable: "All_REF_837D_2",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837D_2_REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id",
                table: "REF",
                column: "REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id",
                principalTable: "All_REF_837D_2",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837D_2_REF_OtherPayerReferralNumber_2_All_REF_837D_2Id",
                table: "REF",
                column: "REF_OtherPayerReferralNumber_2_All_REF_837D_2Id",
                principalTable: "All_REF_837D_2",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837D_5_All_REF_837D_5Id",
                table: "REF",
                column: "All_REF_837D_5Id",
                principalTable: "All_REF_837D_5",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837D_8_All_REF_837D_8Id",
                table: "REF",
                column: "All_REF_837D_8Id",
                principalTable: "All_REF_837D_8",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837D_All_REF_837DId",
                table: "REF",
                column: "All_REF_837DId",
                principalTable: "All_REF_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837I_3_All_REF_837I_3Id",
                table: "REF",
                column: "All_REF_837I_3Id",
                principalTable: "All_REF_837I_3",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837I_4_All_REF_837I_4Id",
                table: "REF",
                column: "All_REF_837I_4Id",
                principalTable: "All_REF_837I_4",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_All_REF_837I_5_All_REF_837I_5Id",
                table: "REF",
                column: "All_REF_837I_5Id",
                principalTable: "All_REF_837I_5",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_C040_REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id",
                principalTable: "C040",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_C040_REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id",
                principalTable: "C040",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_C040_REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id",
                principalTable: "C040",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_C040_REF_PeerReviewOrganization_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_PeerReviewOrganization_ReferenceIdentifier_04Id",
                principalTable: "C040",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_C040_REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id",
                table: "REF",
                column: "REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id",
                principalTable: "C040",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310A_837D_Loop_2310A_837DId",
                table: "REF",
                column: "Loop_2310A_837DId",
                principalTable: "Loop_2310A_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310A_837I_Loop_2310A_837IId",
                table: "REF",
                column: "Loop_2310A_837IId",
                principalTable: "Loop_2310A_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310B_837D_Loop_2310B_837DId",
                table: "REF",
                column: "Loop_2310B_837DId",
                principalTable: "Loop_2310B_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310B_837I_Loop_2310B_837IId",
                table: "REF",
                column: "Loop_2310B_837IId",
                principalTable: "Loop_2310B_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310C_837D_Loop_2310C_837DId",
                table: "REF",
                column: "Loop_2310C_837DId",
                principalTable: "Loop_2310C_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310C_837I_Loop_2310C_837IId",
                table: "REF",
                column: "Loop_2310C_837IId",
                principalTable: "Loop_2310C_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310D_837D_Loop_2310D_837DId",
                table: "REF",
                column: "Loop_2310D_837DId",
                principalTable: "Loop_2310D_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310D_837I_Loop_2310D_837IId",
                table: "REF",
                column: "Loop_2310D_837IId",
                principalTable: "Loop_2310D_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310E_837D_Loop_2310E_837DId",
                table: "REF",
                column: "Loop_2310E_837DId",
                principalTable: "Loop_2310E_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310E_837I_Loop_2310E_837IId",
                table: "REF",
                column: "Loop_2310E_837IId",
                principalTable: "Loop_2310E_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2310F_837I_Loop_2310F_837IId",
                table: "REF",
                column: "Loop_2310F_837IId",
                principalTable: "Loop_2310F_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330A_837D_Loop_2330A_837DId",
                table: "REF",
                column: "Loop_2330A_837DId",
                principalTable: "Loop_2330A_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330A_837I_Loop_2330A_837IId",
                table: "REF",
                column: "Loop_2330A_837IId",
                principalTable: "Loop_2330A_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330C_837D_Loop_2330C_837DId",
                table: "REF",
                column: "Loop_2330C_837DId",
                principalTable: "Loop_2330C_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330C_837I_Loop_2330C_837IId",
                table: "REF",
                column: "Loop_2330C_837IId",
                principalTable: "Loop_2330C_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330D_837D_Loop_2330D_837DId",
                table: "REF",
                column: "Loop_2330D_837DId",
                principalTable: "Loop_2330D_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330D_837I_Loop_2330D_837IId",
                table: "REF",
                column: "Loop_2330D_837IId",
                principalTable: "Loop_2330D_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330E_837D_Loop_2330E_837DId",
                table: "REF",
                column: "Loop_2330E_837DId",
                principalTable: "Loop_2330E_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330E_837I_Loop_2330E_837IId",
                table: "REF",
                column: "Loop_2330E_837IId",
                principalTable: "Loop_2330E_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330F_837D_Loop_2330F_837DId",
                table: "REF",
                column: "Loop_2330F_837DId",
                principalTable: "Loop_2330F_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330F_837I_Loop_2330F_837IId",
                table: "REF",
                column: "Loop_2330F_837IId",
                principalTable: "Loop_2330F_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330G_837D_Loop_2330G_837DId",
                table: "REF",
                column: "Loop_2330G_837DId",
                principalTable: "Loop_2330G_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330G_837I_Loop_2330G_837IId",
                table: "REF",
                column: "Loop_2330G_837IId",
                principalTable: "Loop_2330G_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330H_837D_Loop_2330H_837DId",
                table: "REF",
                column: "Loop_2330H_837DId",
                principalTable: "Loop_2330H_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330H_837I_Loop_2330H_837IId",
                table: "REF",
                column: "Loop_2330H_837IId",
                principalTable: "Loop_2330H_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2330I_837I_Loop_2330I_837IId",
                table: "REF",
                column: "Loop_2330I_837IId",
                principalTable: "Loop_2330I_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420A_837D_Loop_2420A_837DId",
                table: "REF",
                column: "Loop_2420A_837DId",
                principalTable: "Loop_2420A_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420A_837I_Loop_2420A_837IId",
                table: "REF",
                column: "Loop_2420A_837IId",
                principalTable: "Loop_2420A_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420B_837D_Loop_2420B_837DId",
                table: "REF",
                column: "Loop_2420B_837DId",
                principalTable: "Loop_2420B_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420B_837I_Loop_2420B_837IId",
                table: "REF",
                column: "Loop_2420B_837IId",
                principalTable: "Loop_2420B_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420C_837D_Loop_2420C_837DId",
                table: "REF",
                column: "Loop_2420C_837DId",
                principalTable: "Loop_2420C_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420C_837I_Loop_2420C_837IId",
                table: "REF",
                column: "Loop_2420C_837IId",
                principalTable: "Loop_2420C_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420D_837D_Loop_2420D_837DId",
                table: "REF",
                column: "Loop_2420D_837DId",
                principalTable: "Loop_2420D_837D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_REF_Loop_2420D_837I_Loop_2420D_837IId",
                table: "REF",
                column: "Loop_2420D_837IId",
                principalTable: "Loop_2420D_837I",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SVD_C003_SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD",
                column: "SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id",
                principalTable: "C003",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SVD_C003_SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD",
                column: "SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id",
                principalTable: "C003",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CAS_Loop_2320_837D_Loop_2320_837DId",
                table: "CAS");

            migrationBuilder.DropForeignKey(
                name: "FK_CAS_Loop_2320_837I_Loop_2320_837IId",
                table: "CAS");

            migrationBuilder.DropForeignKey(
                name: "FK_CAS_Loop_2430_837D_Loop_2430_837DId",
                table: "CAS");

            migrationBuilder.DropForeignKey(
                name: "FK_CAS_Loop_2430_837I_Loop_2430_837IId",
                table: "CAS");

            migrationBuilder.DropForeignKey(
                name: "FK_CLM_C023_CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id",
                table: "CLM");

            migrationBuilder.DropForeignKey(
                name: "FK_CLM_C023_CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id",
                table: "CLM");

            migrationBuilder.DropForeignKey(
                name: "FK_CLM_C024_CLM_ClaimInformation_2_RelatedCausesInformation_11Id",
                table: "CLM");

            migrationBuilder.DropForeignKey(
                name: "FK_CLM_C024_CLM_ClaimInformation_3_RelatedCausesInformation_11Id",
                table: "CLM");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_All_HI_837I_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_All_HI_837I_HI_OccurrenceInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_All_HI_837I_HI_OccurrenceSpanInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_All_HI_837I_HI_OtherDiagnosisInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_All_HI_837I_HI_OtherProcedureInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_All_HI_837I_HI_TreatmentCodeInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_All_HI_837I_HI_ValueInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_OtherProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_Patient_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_HI_C022_HI_ValueInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropForeignKey(
                name: "FK_K3_Loop_2300_837D_Loop_2300_837DId",
                table: "K3");

            migrationBuilder.DropForeignKey(
                name: "FK_K3_Loop_2300_837I_Loop_2300_837IId",
                table: "K3");

            migrationBuilder.DropForeignKey(
                name: "FK_K3_Loop_2400_837D_Loop_2400_837DId",
                table: "K3");

            migrationBuilder.DropForeignKey(
                name: "FK_NTE_All_NTE_837I_All_NTE_837IId",
                table: "NTE");

            migrationBuilder.DropForeignKey(
                name: "FK_NTE_Loop_2300_837D_Loop_2300_837DId",
                table: "NTE");

            migrationBuilder.DropForeignKey(
                name: "FK_PER_Loop_1000A_837D_Loop_1000A_837DId",
                table: "PER");

            migrationBuilder.DropForeignKey(
                name: "FK_PER_Loop_1000A_837I_Loop_1000A_837IId",
                table: "PER");

            migrationBuilder.DropForeignKey(
                name: "FK_PER_Loop_2010AA_837D_Loop_2010AA_837DId",
                table: "PER");

            migrationBuilder.DropForeignKey(
                name: "FK_PER_Loop_2010AA_837I_Loop_2010AA_837IId",
                table: "PER");

            migrationBuilder.DropForeignKey(
                name: "FK_PRV_C035_PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropForeignKey(
                name: "FK_PRV_C035_PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropForeignKey(
                name: "FK_PRV_C035_PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropForeignKey(
                name: "FK_PWK_C002_PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id",
                table: "PWK");

            migrationBuilder.DropForeignKey(
                name: "FK_PWK_Loop_2300_837D_Loop_2300_837DId",
                table: "PWK");

            migrationBuilder.DropForeignKey(
                name: "FK_PWK_Loop_2300_837I_Loop_2300_837IId",
                table: "PWK");

            migrationBuilder.DropForeignKey(
                name: "FK_PWK_Loop_2400_837I_Loop_2400_837IId",
                table: "PWK");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837D_2_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837D_2_REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837D_2_REF_OtherPayerReferralNumber_2_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837D_5_All_REF_837D_5Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837D_8_All_REF_837D_8Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837D_All_REF_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837I_3_All_REF_837I_3Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837I_4_All_REF_837I_4Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_All_REF_837I_5_All_REF_837I_5Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_C040_REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_C040_REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_C040_REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_C040_REF_PeerReviewOrganization_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_C040_REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310A_837D_Loop_2310A_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310A_837I_Loop_2310A_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310B_837D_Loop_2310B_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310B_837I_Loop_2310B_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310C_837D_Loop_2310C_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310C_837I_Loop_2310C_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310D_837D_Loop_2310D_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310D_837I_Loop_2310D_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310E_837D_Loop_2310E_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310E_837I_Loop_2310E_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2310F_837I_Loop_2310F_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330A_837D_Loop_2330A_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330A_837I_Loop_2330A_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330C_837D_Loop_2330C_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330C_837I_Loop_2330C_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330D_837D_Loop_2330D_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330D_837I_Loop_2330D_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330E_837D_Loop_2330E_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330E_837I_Loop_2330E_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330F_837D_Loop_2330F_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330F_837I_Loop_2330F_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330G_837D_Loop_2330G_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330G_837I_Loop_2330G_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330H_837D_Loop_2330H_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330H_837I_Loop_2330H_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2330I_837I_Loop_2330I_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420A_837D_Loop_2420A_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420A_837I_Loop_2420A_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420B_837D_Loop_2420B_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420B_837I_Loop_2420B_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420C_837D_Loop_2420C_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420C_837I_Loop_2420C_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420D_837D_Loop_2420D_837DId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_REF_Loop_2420D_837I_Loop_2420D_837IId",
                table: "REF");

            migrationBuilder.DropForeignKey(
                name: "FK_SVD_C003_SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD");

            migrationBuilder.DropForeignKey(
                name: "FK_SVD_C003_SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD");

            migrationBuilder.DropTable(
                name: "DN2_ToothStatus");

            migrationBuilder.DropTable(
                name: "Loop_2310A_837D");

            migrationBuilder.DropTable(
                name: "Loop_2320_837D");

            migrationBuilder.DropTable(
                name: "Loop_2320_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330C_837D");

            migrationBuilder.DropTable(
                name: "Loop_2430_837D");

            migrationBuilder.DropTable(
                name: "Loop_2430_837I");

            migrationBuilder.DropTable(
                name: "TOO_ToothInformation");

            migrationBuilder.DropTable(
                name: "All_AMT_837D");

            migrationBuilder.DropTable(
                name: "All_AMT_837I_2");

            migrationBuilder.DropTable(
                name: "All_NM1_837I_4");

            migrationBuilder.DropTable(
                name: "MIA_InpatientAdjudicationInformation");

            migrationBuilder.DropTable(
                name: "All_NM1_837D_4");

            migrationBuilder.DropTable(
                name: "Loop_2400_837I");

            migrationBuilder.DropTable(
                name: "C005_ToothSurface");

            migrationBuilder.DropTable(
                name: "Loop_2400_837D");

            migrationBuilder.DropTable(
                name: "Loop_2330A_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330B_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330C_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330D_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330E_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330F_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330G_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330H_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330I_837I");

            migrationBuilder.DropTable(
                name: "Loop_2330A_837D");

            migrationBuilder.DropTable(
                name: "Loop_2330B_837D");

            migrationBuilder.DropTable(
                name: "Loop_2330D_837D");

            migrationBuilder.DropTable(
                name: "Loop_2330E_837D");

            migrationBuilder.DropTable(
                name: "Loop_2330F_837D");

            migrationBuilder.DropTable(
                name: "Loop_2330G_837D");

            migrationBuilder.DropTable(
                name: "Loop_2330H_837D");

            migrationBuilder.DropTable(
                name: "All_AMT_837I");

            migrationBuilder.DropTable(
                name: "All_NM1_837I_5");

            migrationBuilder.DropTable(
                name: "All_REF_837I");

            migrationBuilder.DropTable(
                name: "Loop_2300_837I");

            migrationBuilder.DropTable(
                name: "Loop_2410_837I");

            migrationBuilder.DropTable(
                name: "SV2_InstitutionalServiceLine");

            migrationBuilder.DropTable(
                name: "All_DTP_837D");

            migrationBuilder.DropTable(
                name: "All_NM1_837D_5");

            migrationBuilder.DropTable(
                name: "All_REF_837D_2");

            migrationBuilder.DropTable(
                name: "Loop_2300_837D");

            migrationBuilder.DropTable(
                name: "SV3_DentalService");

            migrationBuilder.DropTable(
                name: "All_REF_837I_5");

            migrationBuilder.DropTable(
                name: "All_REF_837D");

            migrationBuilder.DropTable(
                name: "Loop_2420A_837I");

            migrationBuilder.DropTable(
                name: "Loop_2420B_837I");

            migrationBuilder.DropTable(
                name: "Loop_2420C_837I");

            migrationBuilder.DropTable(
                name: "Loop_2420D_837I");

            migrationBuilder.DropTable(
                name: "All_DTP_837I");

            migrationBuilder.DropTable(
                name: "All_HI_837I");

            migrationBuilder.DropTable(
                name: "All_NM1_837I_3");

            migrationBuilder.DropTable(
                name: "All_NTE_837I");

            migrationBuilder.DropTable(
                name: "All_REF_837I_4");

            migrationBuilder.DropTable(
                name: "CL1_InstitutionalClaimCode");

            migrationBuilder.DropTable(
                name: "Loop_2000C_837I");

            migrationBuilder.DropTable(
                name: "Loop_2420A_837D");

            migrationBuilder.DropTable(
                name: "Loop_2420B_837D");

            migrationBuilder.DropTable(
                name: "Loop_2420C_837D");

            migrationBuilder.DropTable(
                name: "Loop_2420D_837D");

            migrationBuilder.DropTable(
                name: "All_DTP_837D_2");

            migrationBuilder.DropTable(
                name: "All_NM1_837D_3");

            migrationBuilder.DropTable(
                name: "All_REF_837D_6");

            migrationBuilder.DropTable(
                name: "DN1_OrthodonticTotalMonthsofTreatment");

            migrationBuilder.DropTable(
                name: "Loop_2000C_837D");

            migrationBuilder.DropTable(
                name: "C006_OralCavityDesignation");

            migrationBuilder.DropTable(
                name: "Loop_2310A_837I");

            migrationBuilder.DropTable(
                name: "Loop_2310B_837I");

            migrationBuilder.DropTable(
                name: "Loop_2310C_837I");

            migrationBuilder.DropTable(
                name: "Loop_2310D_837I");

            migrationBuilder.DropTable(
                name: "Loop_2310E_837I");

            migrationBuilder.DropTable(
                name: "Loop_2310F_837I");

            migrationBuilder.DropTable(
                name: "Loop_2000B_837I");

            migrationBuilder.DropTable(
                name: "Loop_2010CA_837I");

            migrationBuilder.DropTable(
                name: "Loop_2310B_837D");

            migrationBuilder.DropTable(
                name: "Loop_2310C_837D");

            migrationBuilder.DropTable(
                name: "Loop_2310D_837D");

            migrationBuilder.DropTable(
                name: "Loop_2310E_837D");

            migrationBuilder.DropTable(
                name: "Loop_2000B_837D");

            migrationBuilder.DropTable(
                name: "Loop_2010CA_837D");

            migrationBuilder.DropTable(
                name: "All_NM1_837I_2");

            migrationBuilder.DropTable(
                name: "Loop_2000A_837I");

            migrationBuilder.DropTable(
                name: "All_REF_837I_6");

            migrationBuilder.DropTable(
                name: "All_NM1_837D_2");

            migrationBuilder.DropTable(
                name: "Loop_2000A_837D");

            migrationBuilder.DropTable(
                name: "All_REF_837D_7");

            migrationBuilder.DropTable(
                name: "Loop_2010BA_837I");

            migrationBuilder.DropTable(
                name: "Loop_2010BB_837I");

            migrationBuilder.DropTable(
                name: "All_NM1_837I");

            migrationBuilder.DropTable(
                name: "TS837I");

            migrationBuilder.DropTable(
                name: "Loop_2010BA_837D");

            migrationBuilder.DropTable(
                name: "Loop_2010BB_837D");

            migrationBuilder.DropTable(
                name: "All_NM1_837D");

            migrationBuilder.DropTable(
                name: "TS837D");

            migrationBuilder.DropTable(
                name: "All_REF_837I_2");

            migrationBuilder.DropTable(
                name: "All_REF_837I_3");

            migrationBuilder.DropTable(
                name: "Loop_2010AA_837I");

            migrationBuilder.DropTable(
                name: "Loop_2010AB_837I");

            migrationBuilder.DropTable(
                name: "Loop_2010AC_837I");

            migrationBuilder.DropTable(
                name: "All_NM1_837I_6");

            migrationBuilder.DropTable(
                name: "All_REF_837D_4");

            migrationBuilder.DropTable(
                name: "All_REF_837D_5");

            migrationBuilder.DropTable(
                name: "Loop_2010AA_837D");

            migrationBuilder.DropTable(
                name: "Loop_2010AB_837D");

            migrationBuilder.DropTable(
                name: "Loop_2010AC_837D");

            migrationBuilder.DropTable(
                name: "All_NM1_837D_6");

            migrationBuilder.DropTable(
                name: "All_REF_837I_7");

            migrationBuilder.DropTable(
                name: "Loop_1000A_837I");

            migrationBuilder.DropTable(
                name: "Loop_1000B_837I");

            migrationBuilder.DropTable(
                name: "All_REF_837D_8");

            migrationBuilder.DropTable(
                name: "All_REF_837D_3");

            migrationBuilder.DropTable(
                name: "Loop_1000A_837D");

            migrationBuilder.DropTable(
                name: "Loop_1000B_837D");

            migrationBuilder.DropIndex(
                name: "IX_SVD_SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD");

            migrationBuilder.DropIndex(
                name: "IX_SVD_SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD");

            migrationBuilder.DropIndex(
                name: "IX_REF_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_All_REF_837D_5Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_All_REF_837D_8Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_All_REF_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_All_REF_837I_3Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_All_REF_837I_4Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_All_REF_837I_5Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310A_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310A_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310B_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310B_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310C_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310C_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310D_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310D_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310E_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310E_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2310F_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330A_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330A_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330C_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330C_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330D_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330D_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330E_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330E_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330F_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330F_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330G_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330G_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330H_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330H_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2330I_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420A_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420A_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420B_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420B_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420C_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420C_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420D_837DId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_Loop_2420D_837IId",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_REF_OtherPayerReferralNumber_2_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_REF_PeerReviewOrganization_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_REF_REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropIndex(
                name: "IX_PWK_Loop_2300_837DId",
                table: "PWK");

            migrationBuilder.DropIndex(
                name: "IX_PWK_Loop_2300_837IId",
                table: "PWK");

            migrationBuilder.DropIndex(
                name: "IX_PWK_Loop_2400_837IId",
                table: "PWK");

            migrationBuilder.DropIndex(
                name: "IX_PWK_PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id",
                table: "PWK");

            migrationBuilder.DropIndex(
                name: "IX_PRV_PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropIndex(
                name: "IX_PRV_PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropIndex(
                name: "IX_PRV_PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropIndex(
                name: "IX_PER_Loop_1000A_837DId",
                table: "PER");

            migrationBuilder.DropIndex(
                name: "IX_PER_Loop_1000A_837IId",
                table: "PER");

            migrationBuilder.DropIndex(
                name: "IX_PER_Loop_2010AA_837DId",
                table: "PER");

            migrationBuilder.DropIndex(
                name: "IX_PER_Loop_2010AA_837IId",
                table: "PER");

            migrationBuilder.DropIndex(
                name: "IX_NTE_All_NTE_837IId",
                table: "NTE");

            migrationBuilder.DropIndex(
                name: "IX_NTE_Loop_2300_837DId",
                table: "NTE");

            migrationBuilder.DropIndex(
                name: "IX_K3_Loop_2300_837DId",
                table: "K3");

            migrationBuilder.DropIndex(
                name: "IX_K3_Loop_2300_837IId",
                table: "K3");

            migrationBuilder.DropIndex(
                name: "IX_K3_Loop_2400_837DId",
                table: "K3");

            migrationBuilder.DropIndex(
                name: "IX_HI_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_OtherProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_Patient_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_HI_HI_ValueInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropIndex(
                name: "IX_CLM_CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id",
                table: "CLM");

            migrationBuilder.DropIndex(
                name: "IX_CLM_CLM_ClaimInformation_2_RelatedCausesInformation_11Id",
                table: "CLM");

            migrationBuilder.DropIndex(
                name: "IX_CLM_CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id",
                table: "CLM");

            migrationBuilder.DropIndex(
                name: "IX_CLM_CLM_ClaimInformation_3_RelatedCausesInformation_11Id",
                table: "CLM");

            migrationBuilder.DropIndex(
                name: "IX_CAS_Loop_2320_837DId",
                table: "CAS");

            migrationBuilder.DropIndex(
                name: "IX_CAS_Loop_2320_837IId",
                table: "CAS");

            migrationBuilder.DropIndex(
                name: "IX_CAS_Loop_2430_837DId",
                table: "CAS");

            migrationBuilder.DropIndex(
                name: "IX_CAS_Loop_2430_837IId",
                table: "CAS");

            migrationBuilder.DropColumn(
                name: "SVD_LineAdjudicationInformation_2_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD");

            migrationBuilder.DropColumn(
                name: "SVD_LineAdjudicationInformation_3_CompositeMedicalProcedureIdentifier_03Id",
                table: "SVD");

            migrationBuilder.DropColumn(
                name: "All_REF_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "All_REF_837D_5Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "All_REF_837D_8Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "All_REF_837I_3Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "All_REF_837I_4Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "All_REF_837I_5Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310A_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310A_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310B_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310B_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310C_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310C_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310D_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310D_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310E_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310E_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2310F_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330A_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330A_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330C_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330C_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330D_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330D_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330E_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330E_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330F_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330F_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330G_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330G_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330H_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330H_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2330I_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420A_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420A_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420B_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420B_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420C_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420C_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420D_837DId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2420D_837IId",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "REF_ApplicationorLocationSystemIdentifier_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "REF_OtherPayerPredeterminationIdentification_2_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "REF_OtherPayerPredeterminationIdentification_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "REF_OtherPayerPriorAuthorizationNumber_2_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "REF_OtherPayerReferralNumber_2_All_REF_837D_2Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "REF_PeerReviewOrganization_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "REF_ServiceFacilityLocationSecondaryIdentification_ReferenceIdentifier_04Id",
                table: "REF");

            migrationBuilder.DropColumn(
                name: "Loop_2300_837DId",
                table: "PWK");

            migrationBuilder.DropColumn(
                name: "Loop_2300_837IId",
                table: "PWK");

            migrationBuilder.DropColumn(
                name: "Loop_2400_837IId",
                table: "PWK");

            migrationBuilder.DropColumn(
                name: "PWK_ClaimSupplementalInformation_2_ActionsIndicated_08Id",
                table: "PWK");

            migrationBuilder.DropColumn(
                name: "PRV_AttendingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropColumn(
                name: "PRV_BillingProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropColumn(
                name: "PRV_ReferringProviderSpecialtyInformation_ProviderSpecialtyInformation_05Id",
                table: "PRV");

            migrationBuilder.DropColumn(
                name: "Loop_1000A_837DId",
                table: "PER");

            migrationBuilder.DropColumn(
                name: "Loop_1000A_837IId",
                table: "PER");

            migrationBuilder.DropColumn(
                name: "Loop_2010AA_837DId",
                table: "PER");

            migrationBuilder.DropColumn(
                name: "Loop_2010AA_837IId",
                table: "PER");

            migrationBuilder.DropColumn(
                name: "All_NTE_837IId",
                table: "NTE");

            migrationBuilder.DropColumn(
                name: "Loop_2300_837DId",
                table: "NTE");

            migrationBuilder.DropColumn(
                name: "Loop_2300_837DId",
                table: "K3");

            migrationBuilder.DropColumn(
                name: "Loop_2300_837IId",
                table: "K3");

            migrationBuilder.DropColumn(
                name: "Loop_2400_837DId",
                table: "K3");

            migrationBuilder.DropColumn(
                name: "All_HI_837IId",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_AnesthesiaRelatedProcedure_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_DiagnosisRelatedGroup_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ExternalCauseofInjury_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_HealthCareDiagnosisCode_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OccurrenceSpanInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherDiagnosisInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_OtherProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_Patient_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalDiagnosis_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_PrincipalProcedureInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_TreatmentCodeInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_All_HI_837IId",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_01Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_02Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_03Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_04Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_05Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_06Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_07Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_08Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_09Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_10Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_11Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "HI_ValueInformation_HealthCareCodeInformation_12Id",
                table: "HI");

            migrationBuilder.DropColumn(
                name: "CLM_ClaimInformation_2_HealthCareServiceLocationInformation_05Id",
                table: "CLM");

            migrationBuilder.DropColumn(
                name: "CLM_ClaimInformation_2_RelatedCausesInformation_11Id",
                table: "CLM");

            migrationBuilder.DropColumn(
                name: "CLM_ClaimInformation_3_HealthCareServiceLocationInformation_05Id",
                table: "CLM");

            migrationBuilder.DropColumn(
                name: "CLM_ClaimInformation_3_RelatedCausesInformation_11Id",
                table: "CLM");

            migrationBuilder.DropColumn(
                name: "Loop_2320_837DId",
                table: "CAS");

            migrationBuilder.DropColumn(
                name: "Loop_2320_837IId",
                table: "CAS");

            migrationBuilder.DropColumn(
                name: "Loop_2430_837DId",
                table: "CAS");

            migrationBuilder.DropColumn(
                name: "Loop_2430_837IId",
                table: "CAS");
        }
    }
}
