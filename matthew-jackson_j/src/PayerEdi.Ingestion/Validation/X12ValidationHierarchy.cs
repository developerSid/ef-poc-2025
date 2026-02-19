using System.Text;

using EdiFabric.Core.Model.Edi.X12;

namespace PayerEdi.Ingestion.Validation;

public class X12ValidationHierarchy : ValidationHierarchy
{
    protected override string GetCanonicalKey()
    {
        var builder = new StringBuilder();

        if (Scope.HasFlag(RuleScope.Partner))
        {
            var isa = this.OfType<ISA>().FirstOrDefault();

            builder.Append(isa?.SenderIDQualifier_5?.Trim() ?? string.Empty);
            builder.AppendLine();

            builder.Append(isa?.InterchangeSenderID_6?.Trim() ?? string.Empty);
            builder.AppendLine();

            builder.Append(isa?.ReceiverIDQualifier_7?.Trim() ?? string.Empty);
            builder.AppendLine();

            builder.Append(isa?.InterchangeReceiverID_8?.Trim() ?? string.Empty);
            builder.AppendLine();
        }

        if (Scope.HasFlag(RuleScope.Application))
        {
            var gs = this.OfType<GS>().FirstOrDefault();

            builder.Append(gs?.SenderIDCode_2?.Trim() ?? string.Empty);
            builder.AppendLine();

            builder.Append(gs?.ReceiverIDCode_3?.Trim() ?? string.Empty);
            builder.AppendLine();
        }

        if (Scope.HasFlag(RuleScope.Schema))
        {
            var st = this.OfType<ST>().FirstOrDefault();
            var gs = this.OfType<GS>().FirstOrDefault();

            builder.Append(st?.TransactionSetIdentifierCode_01?.Trim() ?? string.Empty);
            builder.AppendLine();

            builder.Append((st?.ImplementationConventionPreference_03 ?? gs?.VersionAndRelease_8)?.Trim() ?? string.Empty);
            builder.AppendLine();
        }

        return builder.ToString();
    }
}