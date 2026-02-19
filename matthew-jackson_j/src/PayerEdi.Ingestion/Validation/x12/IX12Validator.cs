
using EdiFabric.Core.Model.Edi.X12;

namespace PayerEdi.Ingestion.Validation.x12;

/// <summary>
/// Represents a typed X12 validation rule for a parsed transaction model.
/// </summary>
public interface IX12Validator<TModel> where TModel : class
{
    /// <summary>
    /// Validates the model within ISA/GS/ST envelope context.
    /// </summary>
    /// <returns>A tuple of validation success and optional error message.</returns>
    (bool, string?) Validate(ISA isa, GS? gs, ST st, TModel item);
}