using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PayerEdi.Ingestion.Validation;
using PayerEdi.Ingestion.Validation.x12;
using System.Linq;

namespace PayerEdi.Pharmacy.Services;

/// <summary>
/// Applies configured X12 SNIP validation before persistence.
/// </summary>
public sealed class X12SnipValidationPreSaveHook(
    ILogger<X12SnipValidationPreSaveHook> logger,
    IX12ValidatorCache validatorCache,
    IOptions<SnipValidationOptions> options) : IIngestionPreSaveHook
{
    /// <inheritdoc />
    public Task OnBeforeSaveAsync(List<IEdiItem> items, CancellationToken cancellationToken = default)
    {
        var config = options.Value;
        if (!config.Enabled)
            return Task.CompletedTask;

        if (config.Level < RuleTier.SNIP1 || config.Level > RuleTier.SNIP4)
            throw new InvalidOperationException(
                $"Configured SNIP level '{config.Level}' is not supported. Supported levels are SNIP1-SNIP4.");

        var transactions = items.OfType<TS837P>().ToList();
        if (transactions.Count == 0)
            return Task.CompletedTask;

        // ISA/GS/ST provide lookup scope for validator cache selection.
        var isa = items.OfType<ISA>().FirstOrDefault()
            ?? throw new InvalidOperationException("Validation requires ISA envelope data, but none was parsed.");
        var gs = items.OfType<GS>().FirstOrDefault();
        // Execute validation cumulatively from SNIP1 through configured SNIP level.
        var tiers = Enumerable.Range((int)RuleTier.SNIP1, (int)config.Level).Select(x => (RuleTier)x);

        foreach (var transaction in transactions)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var st = transaction.ST
                ?? throw new InvalidOperationException("Validation requires ST transaction header, but TS837P.ST was null.");

            foreach (var tier in tiers)
            {
                var validators = validatorCache.GetValidators<TS837P>(tier, isa, gs, st);
                foreach (var validator in validators)
                {
                    var (isValid, error) = validator.Validate(isa, gs, st, transaction);
                    if (!isValid)
                        throw new InvalidOperationException(error ?? $"{tier} validation failed.");
                }
            }
        }

        logger.LogInformation(
            "SNIP validation passed for {Count} TS837P transaction(s) at level {Level}.",
            transactions.Count,
            config.Level);

        return Task.CompletedTask;
    }
}
