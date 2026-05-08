using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using X12EDI837.Ingestion.Domain;
using X12EDI837.Ingestion.Infrastructure;
using X12EDI837.Ingestion.Infrastructure.FileSource;

namespace X12EDI837.Ingestion.Services;

public class EdiIngestionService
{
    private readonly IFileSource _fileSource;
    private readonly IEdiParser _parser;
    private readonly AppDbContext _db;
    private readonly ILogger<EdiIngestionService> _logger;
    private readonly string _fileSourceProvider;

    public EdiIngestionService(
        IFileSource fileSource,
        IEdiParser parser,
        AppDbContext db,
        IOptions<FileSourceOptions> opts,
        ILogger<EdiIngestionService> logger)
    {
        _fileSource         = fileSource;
        _parser             = parser;
        _db                 = db;
        _logger             = logger;
        _fileSourceProvider = opts.Value.Provider; // "local" or "s3"
    }

    public async Task RunAsync(CancellationToken ct = default)
    {
        IEnumerable<string> files;

        try
        {
            files = await _fileSource.ListFilesAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Failed to list files from source provider: {Provider}", _fileSourceProvider);
            throw;
        }

        foreach (var fileName in files)
        {
            _logger.LogInformation("Processing: {FileName}", fileName);
            try
            {
                await ProcessFileAsync(fileName, ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed processing: {FileName}", fileName);
            }
        }
    }

    /// <summary>
    /// Parses a single EDI file, skips duplicate claims, and saves all new
    /// claims in one batch (one SaveChangesAsync per file — not per claim).
    /// </summary>
    public async Task ProcessFileAsync(string fileName, CancellationToken ct = default)
    {
        // ── Open file stream ──────────────────────────────────────────────────
        Stream stream;
        try
        {
            stream = await _fileSource.OpenReadAsync(fileName, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to open file: {FileName}", fileName);
            throw;
        }

        await using (stream)
        {
            // ── Parse EDI file ────────────────────────────────────────────────
            IEnumerable<EdiParseResult> results;
            try
            {
                results = _parser.Parse(stream, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EDI parsing failed for file: {FileName}", fileName);
                throw;
            }

            int savedCount   = 0;
            int skippedCount = 0;
            int invalidCount = 0;

            foreach (var result in results)
            {
                // ── Map EDI transaction to claims ─────────────────────────────
                IEnumerable<Claim> claims;
                try
                {
                    claims = MapToClaims(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "Failed to map transaction {ControlNumber} in file {FileName} — skipping transaction",
                        result.TransactionControlNumber, fileName);
                    continue;
                }

                foreach (var claim in claims)
                {
                    try
                    {
                        // ── Set validation status and file source on every claim ──
                        claim.IsValid        = result.IsValid;
                        claim.SnipErrorCount = result.ValidationErrors.Count;
                        claim.FileSource     = _fileSourceProvider;

                        if (!result.IsValid)
                        {
                            // ── Save claim WITH its SNIP errors for full audit trail ──
                            _logger.LogWarning(
                                "Invalid transaction {ControlNumber} ({ErrorCount} SNIP errors) — saving for audit",
                                result.TransactionControlNumber, result.ValidationErrors.Count);

                            bool invalidExists = await _db.Claims
                                .AnyAsync(c => c.ClaimId == claim.ClaimId, ct);

                            if (invalidExists)
                            {
                                _logger.LogWarning(
                                    "Skipping duplicate invalid ClaimId {ClaimId} — already in database",
                                    claim.ClaimId);
                                skippedCount++;
                                continue;
                            }

                            await _db.Claims.AddAsync(claim, ct);
                            invalidCount++;
                            continue;
                        }

                        // ── Valid claim: check for duplicate before saving ────
                        bool alreadyExists = await _db.Claims
                            .AnyAsync(c => c.ClaimId == claim.ClaimId, ct);

                        if (alreadyExists)
                        {
                            _logger.LogWarning(
                                "Skipping duplicate ClaimId {ClaimId} from {ControlNumber} — already in database",
                                claim.ClaimId, result.TransactionControlNumber);
                            skippedCount++;
                            continue;
                        }

                        await _db.Claims.AddAsync(claim, ct);
                        savedCount++;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex,
                            "Failed to process ClaimId {ClaimId} from {ControlNumber} — skipping claim",
                            claim.ClaimId, result.TransactionControlNumber);
                    }
                }
            }

            // ── One SaveChangesAsync per file (valid + invalid claims batched) ──
            if (savedCount + invalidCount > 0)
            {
                try
                {
                    await _db.SaveChangesAsync(ct);
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "Database save failed for file: {FileName}", fileName);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error during database save for file: {FileName}", fileName);
                    throw;
                }
            }

            _logger.LogInformation(
                "File {FileName} complete — saved: {Saved}, invalid (saved for audit): {Invalid}, duplicates skipped: {Skipped}",
                fileName, savedCount, invalidCount, skippedCount);
        }
    }

    private static IEnumerable<Claim> MapToClaims(EdiParseResult result)
    {
        var tx = result.Transaction;
        var a  = tx.Loop2000A?.FirstOrDefault();

        // Billing Provider is at the 2000A/2010AA level — shared across all claims in this transaction
        BillingProvider? billingProvider = null;
        var loop2010AA = a?.AllNM1?.Loop2010AA;
        if (loop2010AA is not null)
        {
            var nm1 = loop2010AA.NM1_BillingProviderName;
            var n3  = loop2010AA.N3_BillingProviderAddress;
            var n4  = loop2010AA.N4_BillingProviderCity_State_ZIPCode;
            billingProvider = new BillingProvider
            {
                Npi              = nm1?.ResponseContactIdentifier_09 ?? string.Empty,
                OrganizationName = nm1?.ResponseContactLastorOrganizationName_03 ?? string.Empty,
                FirstName        = nm1?.ResponseContactFirstName_04 ?? string.Empty,
                LastName         = nm1?.ResponseContactLastorOrganizationName_03 ?? string.Empty,
                AddressLine1     = n3?.ResponseContactAddressLine_01 ?? string.Empty,
                City             = n4?.AdditionalPatientInformationContactCityName_01 ?? string.Empty,
                State            = n4?.AdditionalPatientInformationContactStateCode_02 ?? string.Empty,
                Zip              = n4?.AdditionalPatientInformationContactPostalZoneorZIPCode_03 ?? string.Empty,
            };
        }

        // Iterate ALL Loop2000B (one per subscriber/patient)
        foreach (var b in a?.Loop2000B ?? [])
        {
            // Iterate ALL Loop2300 (one per CLM segment) within this subscriber
            foreach (var loop2300 in b?.Loop2300 ?? [])
            {
                var clm = loop2300.CLM_ClaimInformation;

                var claim = new Claim
                {
                    SourceFileName              = result.SourceFileName,
                    TransactionSetControlNumber = result.TransactionControlNumber,
                    InterchangeControlNumber    = result.InterchangeControlNumber,
                    GroupControlNumber          = result.GroupControlNumber,
                    ClaimId                     = clm?.PatientControlNumber_01 ?? string.Empty,
                    TotalChargeAmount           = decimal.TryParse(clm?.TotalClaimChargeAmount_02, out var amt) ? amt : 0m,
                    FacilityTypeCode            = clm?.HealthCareServiceLocationInformation_05?.FacilityTypeCode_01 ?? string.Empty,
                    AssignmentOfBenefits        = clm?.AssignmentorPlanParticipationCode_07 ?? string.Empty,
                    ReleaseOfInformation        = clm?.ReleaseofInformationCode_09 ?? string.Empty,
                };

                // Attach a fresh copy of billing provider per claim (separate FK row)
                if (billingProvider is not null)
                    claim.BillingProvider = new BillingProvider
                    {
                        Npi              = billingProvider.Npi,
                        OrganizationName = billingProvider.OrganizationName,
                        FirstName        = billingProvider.FirstName,
                        LastName         = billingProvider.LastName,
                        AddressLine1     = billingProvider.AddressLine1,
                        City             = billingProvider.City,
                        State            = billingProvider.State,
                        Zip              = billingProvider.Zip,
                    };

                // Subscriber - Loop 2010BA
                var loop2010BA = b?.AllNM1?.Loop2010BA;
                if (loop2010BA is not null)
                {
                    var nm1 = loop2010BA.NM1_SubscriberName;
                    var n3  = loop2010BA.N3_SubscriberAddress;
                    var n4  = loop2010BA.N4_SubscriberCity_State_ZIPCode;
                    var dmg = loop2010BA.DMG_SubscriberDemographicInformation;
                    claim.Subscriber = new Subscriber
                    {
                        MemberId     = nm1?.ResponseContactIdentifier_09 ?? string.Empty,
                        LastName     = nm1?.ResponseContactLastorOrganizationName_03 ?? string.Empty,
                        FirstName    = nm1?.ResponseContactFirstName_04 ?? string.Empty,
                        MiddleName   = nm1?.ResponseContactMiddleName_05 ?? string.Empty,
                        DateOfBirth  = ParseDate(dmg?.DependentBirthDate_02),
                        Gender       = dmg?.DependentGenderCode_03 ?? string.Empty,
                        AddressLine1 = n3?.ResponseContactAddressLine_01 ?? string.Empty,
                        City         = n4?.AdditionalPatientInformationContactCityName_01 ?? string.Empty,
                        State        = n4?.AdditionalPatientInformationContactStateCode_02 ?? string.Empty,
                        Zip          = n4?.AdditionalPatientInformationContactPostalZoneorZIPCode_03 ?? string.Empty,
                    };
                }

                // Service Lines - Loop 2400
                foreach (var line in loop2300.Loop2400 ?? [])
                {
                    var sv1  = line.SV1_ProfessionalService;
                    if (sv1 is null) continue;
                    var proc = sv1.CompositeMedicalProcedureIdentifier_01;
                    var diag = sv1.CompositeDiagnosisCodePointer_07;
                    claim.ServiceLines.Add(new ServiceLine
                    {
                        LineNumber           = int.TryParse(line.LX_ServiceLineNumber?.AssignedNumber_01, out var ln) ? ln : 0,
                        ProcedureCode        = proc?.ProcedureCode_02 ?? string.Empty,
                        Modifier1            = proc?.ProcedureModifier_03 ?? string.Empty,
                        Modifier2            = proc?.ProcedureModifier_04 ?? string.Empty,
                        LineChargeAmount     = decimal.TryParse(sv1.LineItemChargeAmount_02, out var la) ? la : 0m,
                        UnitOfMeasure        = sv1.UnitorBasisforMeasurementCode_03 ?? string.Empty,
                        Quantity             = decimal.TryParse(sv1.ServiceUnitCount_04, out var qty) ? qty : 0m,
                        DiagnosisCodePointer = diag?.DiagnosisCodePointer_01 ?? string.Empty,
                        ServiceDate          = ParseDate(line.AllDTP?.DTP_Date_ServiceDate?.DateTimePeriod_03),
                    });
                }

                // Diagnosis Codes - HI segment
                var hi = loop2300.AllHI?.HI_HealthCareDiagnosisCode;
                if (hi is not null)
                {
                    if (!string.IsNullOrWhiteSpace(hi.HealthCareCodeInformation_01?.IndustryCode_02))
                        claim.DiagnosisCodes.Add(new DiagnosisCode
                        {
                            SequenceNumber = 1,
                            Qualifier      = hi.HealthCareCodeInformation_01.CodeListQualifierCode_01 ?? string.Empty,
                            Code           = hi.HealthCareCodeInformation_01.IndustryCode_02,
                        });

                    var seq = 2;
                    foreach (var dx in new[] {
                        hi.HealthCareCodeInformation_02, hi.HealthCareCodeInformation_03,
                        hi.HealthCareCodeInformation_04, hi.HealthCareCodeInformation_05,
                        hi.HealthCareCodeInformation_06, hi.HealthCareCodeInformation_07,
                        hi.HealthCareCodeInformation_08, hi.HealthCareCodeInformation_09,
                        hi.HealthCareCodeInformation_10, hi.HealthCareCodeInformation_11,
                        hi.HealthCareCodeInformation_12 })
                    {
                        if (string.IsNullOrWhiteSpace(dx?.IndustryCode_02)) continue;
                        claim.DiagnosisCodes.Add(new DiagnosisCode
                        {
                            SequenceNumber = seq++,
                            Qualifier      = dx.CodeListQualifierCode_01 ?? string.Empty,
                            Code           = dx.IndustryCode_02,
                        });
                    }
                }

                // SNIP validation errors (attached to every claim in the transaction)
                foreach (var err in result.ValidationErrors)
                    claim.SnipValidationErrors.Add(new SnipValidationError
                    {
                        SnipLevel       = err.SnipLevel,
                        Segment         = err.Segment,
                        SegmentPosition = err.SegmentPosition,
                        ErrorMessage    = err.ErrorMessage,
                    });

                yield return claim;
            }
        }
    }

    private static DateTime? ParseDate(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        return DateTime.TryParseExact(value, "yyyyMMdd",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out var dt) ? dt : null;
    }
}