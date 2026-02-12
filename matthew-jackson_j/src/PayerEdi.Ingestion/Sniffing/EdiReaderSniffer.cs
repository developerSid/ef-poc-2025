using System.Text;

namespace PayerEdi.Ingestion;

public sealed class EdiReaderSniffer : IEdiReaderSniffer
{
    public EdiStandard DetectStandard(Stream stream)
        => DetectStandard(stream, out _);

    public EdiStandard DetectStandard(Stream stream, out Stream readableStream)
    {
        if (stream is null)
            throw new ArgumentNullException(nameof(stream));

        if (!stream.CanRead)
            throw new ArgumentException("Stream must be readable.", nameof(stream));

        readableStream = stream;
        var originalPosition = stream.CanSeek ? stream.Position : 0L;

        try
        {
            var buffer = ReadProbe(stream, 512);
            var token = ReadLeadingToken(buffer);

            var standard = token switch
            {
                "ISA" => EdiStandard.X12,
                "MSH" => EdiStandard.Hl7,
                "FHS" => EdiStandard.Hl7,
                "BHS" => EdiStandard.Hl7,
                "UNB" => DetectEdifactOrScript(buffer),
                "UNA" => DetectEdifactOrScript(buffer),
                _ => DetectFallback(buffer)
            };

            if (!stream.CanSeek)
                readableStream = new PrefixedStream(buffer, stream);

            return standard;
        }
        finally
        {
            if (stream.CanSeek)
                stream.Position = originalPosition;
        }
    }

    private static byte[] ReadProbe(Stream stream, int length)
    {
        var buffer = new byte[length];
        var read = stream.Read(buffer, 0, length);

        if (read <= 0)
            return Array.Empty<byte>();

        if (read == buffer.Length)
            return buffer;

        var trimmed = new byte[read];
        Buffer.BlockCopy(buffer, 0, trimmed, 0, read);
        return trimmed;
    }

    private static string ReadLeadingToken(byte[] buffer)
    {
        if (buffer.Length == 0)
            return string.Empty;

        var builder = new StringBuilder(3);
        foreach (var b in buffer)
        {
            if (b <= 0x20)
                continue;

            if (builder.Length < 3)
                builder.Append((char)b);

            if (builder.Length == 3)
                break;
        }

        return builder.ToString();
    }

    private static EdiStandard DetectEdifactOrScript(byte[] buffer)
    {
        var content = GetAsciiSnapshot(buffer, 96);

        if (content.Contains("UIB", StringComparison.Ordinal) ||
            content.Contains("UIH", StringComparison.Ordinal))
        {
            return EdiStandard.NcpdpScript;
        }

        return EdiStandard.Edifact;
    }

    private static EdiStandard DetectFallback(byte[] buffer)
    {
        var content = GetAsciiSnapshot(buffer, 128);

        if (content.Contains("UIB", StringComparison.Ordinal) ||
            content.Contains("UIH", StringComparison.Ordinal))
        {
            return EdiStandard.NcpdpScript;
        }

        if (content.Contains("D0B1", StringComparison.Ordinal) ||
            (ContainsControl(buffer, 0x02) && content.Contains("B1", StringComparison.Ordinal)))
        {
            return EdiStandard.NcpdpTelecom;
        }

        return EdiStandard.Unknown;
    }

    private static bool ContainsControl(byte[] buffer, byte value)
    {
        foreach (var b in buffer)
        {
            if (b == value)
                return true;
        }

        return false;
    }

    private static string GetAsciiSnapshot(byte[] buffer, int maxLength)
    {
        var length = Math.Min(buffer.Length, maxLength);
        var chars = new char[length];

        for (var i = 0; i < length; i++)
        {
            var b = buffer[i];
            chars[i] = b < 0x20 ? ' ' : (char)b;
        }

        return new string(chars);
    }

    private sealed class PrefixedStream : Stream
    {
        private readonly byte[] _prefix;
        private int _prefixOffset;
        private readonly Stream _inner;

        public PrefixedStream(byte[] prefix, Stream inner)
        {
            _prefix = prefix ?? Array.Empty<byte>();
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_prefixOffset < _prefix.Length)
            {
                var remaining = _prefix.Length - _prefixOffset;
                var toCopy = Math.Min(remaining, count);
                Buffer.BlockCopy(_prefix, _prefixOffset, buffer, offset, toCopy);
                _prefixOffset += toCopy;
                return toCopy;
            }

            return _inner.Read(buffer, offset, count);
        }

        public override void Flush() { }

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _inner.Dispose();

            base.Dispose(disposing);
        }
    }
}
