using System.Reflection;
using System.Runtime.Serialization;

namespace PayerEDI.Data.Models.Factory;

public static class CommunicationNumberQualifierFactory
{
    extension(CommunicationNumberQualifier)
    {
        public static CommunicationNumberQualifier? FromValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                foreach (var qualifier in Enum.GetValues<CommunicationNumberQualifier>())
                {
                    var member = typeof(CommunicationNumberQualifier).GetMember(
                        qualifier.ToString()
                    )[0];
                    var enumMember = member.GetCustomAttribute<EnumMemberAttribute>();

                    if (string.Equals(enumMember?.Value, value, StringComparison.OrdinalIgnoreCase))
                    {
                        return qualifier;
                    }
                }
            }

            return null;
        }
    }
}

public static class CommunicationNumberFactory
{
    extension(CommunicationNumber)
    {
        public static CommunicationNumber New(string number, string qualifierValue)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException(
                    "Communication number is required and cannot be empty.",
                    nameof(number)
                );
            }

            if (string.IsNullOrWhiteSpace(qualifierValue))
            {
                throw new ArgumentException(
                    "Communication number qualifier is required and cannot be empty.",
                    nameof(qualifierValue)
                );
            }

            var qualifier = CommunicationNumberQualifier.FromValue(qualifierValue);

            if (qualifier is null)
            {
                throw new ArgumentException(
                    $"Unknown communication number qualifier: {qualifierValue}",
                    nameof(qualifierValue)
                );
            }

            return new CommunicationNumber(number, qualifier.Value);
        }

        public static CommunicationNumber? MaybeNew(string? number, string? qualifierValue)
        {
            if (string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(qualifierValue))
            {
                return null;
            }

            try
            {
                return CommunicationNumber.New(number, qualifierValue);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
