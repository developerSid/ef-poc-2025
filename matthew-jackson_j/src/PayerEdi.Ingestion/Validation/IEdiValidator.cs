namespace PayerEdi.Ingestion.Validation;

public interface IEdiValidator<TModel> where TModel : IEdiItem
{
    IReadOnlyList<string> Validate(TModel item, IReadOnlyList<IEdiItem>? hierarchy = null);
}