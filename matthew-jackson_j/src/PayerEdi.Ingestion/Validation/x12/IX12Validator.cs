
using EdiFabric.Core.Model.Edi.X12;

namespace PayerEdi.Ingestion.Validation.x12;

public interface IX12Validator<TModel> where TModel : IEdiItem
{
    (bool, string?) Validate(ISA isa, GS gs, ST st, TModel item);
}