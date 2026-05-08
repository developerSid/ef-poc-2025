namespace X12EDI837.Ingestion.Services;

/// <summary>
/// Parses a raw EDI 837P stream and returns one <see cref="EdiParseResult"/>
/// per transaction set, each carrying SNIP validation results.
/// </summary>
public interface IEdiParser
{
    /// <summary>
    /// Parses the given EDI <paramref name="ediStream"/> and returns one
    /// <see cref="EdiParseResult"/> per 837P transaction set found,
    /// each populated with SNIP validation results.
    /// </summary>
    /// <param name="ediStream">Readable stream containing the raw X12 EDI content.</param>
    /// <param name="sourceFileName">
    /// Logical name or path of the file being parsed; used for logging and
    /// stored on each <see cref="EdiParseResult.SourceFileName"/>.
    /// </param>
    /// <returns>
    /// A sequence of <see cref="EdiParseResult"/> — one per transaction set.
    /// Invalid transactions are included with <see cref="EdiParseResult.IsValid"/>
    /// set to <see langword="false"/>.
    /// </returns>
    IEnumerable<EdiParseResult> Parse(Stream ediStream, string sourceFileName);
}
