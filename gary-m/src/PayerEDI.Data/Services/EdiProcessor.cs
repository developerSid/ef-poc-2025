using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.ErrorContexts;
using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Framework.Readers;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.Logging;
using PayerEDI.Data.Models.Claims;
using PayerEDI.Data.Models.Claims.Factory;

namespace PayerEDI.Data.Services;

public class EdiProcessor(ILogger<EdiProcessor> logger)
{
    public IList<HealthCareClaim> ProcessEdi(Stream ediStream)
    {
        var claims = new List<HealthCareClaim>();
        using var edi = new X12Reader(ediStream, X12TypeFactory.GetTypeInfo);
        var transactions = edi.ReadToEnd().ToList();
        // Keep this interface-typed so nested processors share one boxed enumerator instead of advancing copied struct enumerators.
#pragma warning disable CA1859
        IEnumerator<IEdiItem> transactionEnumerator = transactions.GetEnumerator();
#pragma warning restore CA1859

        while (transactionEnumerator.MoveNext()) // maybe use a stack with push and pop semantics instead of this advance with the enumerator
        {
            var transaction = transactionEnumerator.Current;

            switch (transaction)
            {
                case ISA isa:
                    ProcessInterchange(claims, transactionEnumerator, isa);
                    break;
                case null:
                    continue;
                default:
                    logger.LogInformation(
                        "Unhandled transaction type in process Edi File {Transaction}",
                        transaction
                    );
                    break;
            }
        }

        return claims;
    }

    private void ProcessInterchange(
        List<HealthCareClaim> claims,
        IEnumerator<IEdiItem> transactionEnumerator,
        ISA isa
    )
    {
        logger.LogInformation("Transaction Start {Transaction}", isa);
        logger.LogInformation("Interchange Date {InterchangeDate}", isa.InterchangeDate_9);

        while (transactionEnumerator.MoveNext())
        {
            var transaction = transactionEnumerator.Current;

            switch (transaction)
            {
                case GS gs:
                    ProcessFunctionalGroup(claims, transactionEnumerator, isa, gs);
                    break;
                case IEA iea:
                    logger.LogInformation("Transaction End {Transaction}", iea);
                    return; // end of document
                default:
                    logger.LogWarning(
                        "Unhandled transaction type in process interchange {Transaction}",
                        transaction
                    );
                    break;
            }
        }
    }

    private void ProcessFunctionalGroup(
        List<HealthCareClaim> claims,
        IEnumerator<IEdiItem> transactionEnumerator,
        ISA isa,
        GS gs
    )
    {
        logger.LogInformation("GS transaction Begin {Transaction}", gs);
        logger.LogInformation("Functional Group Date {FunctionalGroupDate}", gs.Date_4);
        logger.LogInformation("Control Group Number {Number}", gs.GroupControlNumber_6);

        while (transactionEnumerator.MoveNext())
        {
            var transaction = transactionEnumerator.Current;

            switch (transaction)
            {
                case TS837P ts837P:
                    claims.Add(Process837P(isa, gs, ts837P));
                    break;
                case TS837D ts837D:
                    claims.Add(Process837D(isa, gs, ts837D));
                    break;
                case ReaderErrorContext errorContext:
                    logger.LogError(
                        errorContext.Exception,
                        "Reader error at {ReaderErrorCode}: {ErrorMessage}",
                        errorContext.ReaderErrorCode,
                        errorContext.Exception.Message
                    );
                    break;
                case GE ge:
                    logger.LogInformation("GE transaction End {Transaction}", ge);
                    logger.LogInformation("Control Group Number {Number}", ge.GroupControlNumber_2);
                    return; // end of section
                default:
                    logger.LogInformation(
                        "Unhandled transaction type in functional group {Transaction}",
                        transaction
                    );
                    break;
            }
        }
    }
    
    private ProfessionalCareClaim Process837P(ISA isa, GS gs, TS837P ts837P)
    {
        logger.LogInformation("837P transaction {Transaction}", ts837P);
        logger.LogInformation("837P Model {Model}", ts837P.Model);
        logger.LogInformation("837P ID {Id}", ts837P.Id);
        logger.LogInformation("TS837P Loop 1000A NM1 ID {Id}", ts837P.AllNM1.Loop1000A.Id);
        logger.LogDebug(
            "837D belongs to functional group {GroupControlNumber}",
            gs.GroupControlNumber_6
        );

        ts837P.Loop2000A.ForEach(billingProvider =>
        {
            logger.LogInformation(
                "TS837D Billing Provider First Name: {BillingProviderFirstName}",
                billingProvider
                    .AllNM1
                    .Loop2010AA
                    .NM1_BillingProviderName
                    .ResponseContactFirstName_04
            );
            logger.LogInformation(
                "TS837D Billing Provider Last or Org Name: {BillingProviderLastOrgName}",
                billingProvider
                    .AllNM1
                    .Loop2010AA
                    .NM1_BillingProviderName
                    .ResponseContactLastorOrganizationName_03
            );
        });

        return ProfessionalCareClaim.New(gs.Date_4, gs.Time_5, ts837P);
    }

    private DentalCareClaim Process837D(ISA isa, GS gs, TS837D ts837D)
    {
        logger.LogInformation("837D transaction {Transaction}", ts837D);
        logger.LogInformation("837D Model {Model}", ts837D.Model);
        logger.LogInformation("837D ID {Id}", ts837D.Id);
        logger.LogInformation("TS837D Loop 1000A NM1 ID {Id}", ts837D.AllNM1.Loop1000A.Id);
        logger.LogDebug(
            "837D belongs to functional group {GroupControlNumber}",
            gs.GroupControlNumber_6
        );

        ts837D.Loop2000A.ForEach(billingProvider =>
        {
            logger.LogInformation(
                "TS837D Billing Provider First Name: {BillingProviderFirstName}",
                billingProvider
                    .AllNM1
                    .Loop2010AA
                    .NM1_BillingProviderName
                    .ResponseContactFirstName_04
            );
            logger.LogInformation(
                "TS837D Billing Provider Last or Org Name: {BillingProviderLastOrgName}",
                billingProvider
                    .AllNM1
                    .Loop2010AA
                    .NM1_BillingProviderName
                    .ResponseContactLastorOrganizationName_03
            );
        });

        return DentalCareClaim.New(gs.Date_4, gs.Time_5, ts837D);
    }
}
