using EdiFabric.Core.Model.Edi;
using PayerEDI.Data.Models.Claims;

namespace PayerEDI.Data.Services;

public interface IEdiProcessor
{
    public List<(EdiMessage, HealthCareClaim)> ProcessEdi(Stream ediStream);
}
