using EdiFabric.Core.Model.Edi;

namespace PayerEdi.Pharmacy.Services;

/// <summary>
/// Runs additional pipeline behavior after parse and before persistence.
/// </summary>
public interface IIngestionPreSaveHook
{
    /// <summary>
    /// Executes hook behavior against parsed items before persistence begins.
    /// </summary>
    Task OnBeforeSaveAsync(List<IEdiItem> items, CancellationToken cancellationToken = default);
}
