using PayerEDI.Data.Exceptions;

namespace PayerEDI.Data.Helpers;

public static class EdiValueHelper
{
    public static string? EdiValue(this string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    public static string RequireNm1<NM1>(
        this NM1 nm1,
        Func<NM1, string?> valueSelector,
        string element
    )
    {
        var value = valueSelector(nm1);
        
        return string.IsNullOrWhiteSpace(value)
            ? throw new InvalidNm1Exception($"{element} is required for an NM1 identity.")
            : value.Trim();
    }
}
