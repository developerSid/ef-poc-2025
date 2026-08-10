namespace PayerEDI.Data.Models;

public record CommunicationNumber(string Number, CommunicationNumberQualifier Qualifier);

public static class CommunicationNumberExtensions
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
