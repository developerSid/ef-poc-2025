using System.Reflection;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.X12;

namespace PayerEDI.Data;

public static class X12TypeFactory
{
    public static TypeInfo GetTypeInfo(ISA isa, GS gs, ST st)
    {
        return st.TransactionSetIdentifierCode_01 switch
        {
            "837" => st.ImplementationConventionPreference_03 switch
            {
                "005010X224A2" or "005010X224" =>
                    typeof(EdiFabric.Templates.Hipaa5010.TS837D).GetTypeInfo(),
                "005010X222A1" => typeof(EdiFabric.Templates.Hipaa5010.TS837P).GetTypeInfo(),
                "005010X223A2" => typeof(EdiFabric.Templates.Hipaa5010.TS837I).GetTypeInfo(),
                var implementationCodePreference => throw new Exception(
                    $"Unsupported implementation code preference. {implementationCodePreference}"
                ),
            },
            var transactionCode => throw new Exception(
                $"Unsupported transaction. {transactionCode}"
            ),
        };
    }
}
