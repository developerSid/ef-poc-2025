using PayerEDI.Data.Exceptions;

namespace PayerEDI.Data.Helpers;

public static class EdiValueHelper
{
    public static string? EdiValue(this string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    
    public static string RequireNm1(this string? value, string element) => // this is a very naive implementation, and I wish I could tag this per property somehow
        string.IsNullOrWhiteSpace(value)
            ? throw new InvalidNm1Exception($"{element} is required for an NM1 identity.")
            : value.Trim();
}
