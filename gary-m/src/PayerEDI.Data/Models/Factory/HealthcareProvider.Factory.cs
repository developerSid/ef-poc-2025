using EdiFabric.Templates.Hipaa5010;

namespace PayerEDI.Data.Models.Factory;

public static class HealthcareProviderFactory
{
    extension(HealthcareProvider)
    {
        public static IList<HealthcareProvider> New(All_NM1_837P_3 nm1)
        {
            var result = nm1
                .Loop2310A.Select(p => Person.New(p))
                .Select(p => new ReferringProvider(p));

            return result.ToList<HealthcareProvider>();
        }

        public static IList<HealthcareProvider> New(All_NM1_837D_3 nm1)
        {
            var result = new List<HealthcareProvider>();

            return result;
        }

        public static IList<HealthcareProvider> New(TS837P claim) =>
            claim
                .Loop2000A.SelectMany(billing => billing.Loop2000B)
                .SelectMany(subscriber => subscriber.Loop2000C)
                .SelectMany(o => o.Loop2300)
                .SelectMany(healthcareProvider => New(healthcareProvider.AllNM1))
                .ToList();

        public static IList<HealthcareProvider> New(TS837D claim) =>
            claim
                .Loop2000A.SelectMany(billing => billing.Loop2000B)
                .SelectMany(subscriber => subscriber.Loop2000C)
                .SelectMany(o => o.Loop2300)
                .SelectMany(healthcareProvider => New(healthcareProvider.AllNM1))
                .ToList();
    }
}
