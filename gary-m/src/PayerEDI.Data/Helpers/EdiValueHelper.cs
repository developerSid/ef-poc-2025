namespace PayerEDI.Data.Helpers;

public static class EdiValueHelper
{
    public static string? EdiValue(this string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
