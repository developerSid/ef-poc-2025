using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;
using PayerEdi.Ingestion.Validation;
using PayerEdi.Ingestion.Validation.x12;
using PayerEdi.Ingestion.Validation.x12._837p;
using System.Text;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

/// <summary>
/// Verifies SNIP validator behavior for direct failures and chained execution order.
/// </summary>
public sealed class TS837PSnipValidatorsTests(IngestionFixture fixture) : IClassFixture<IngestionFixture>
{
    /// <summary>
    /// Uses an intentionally incomplete transaction to assert SNIP1 syntax validation failure messaging.
    /// </summary>
    [Fact]
    public void ValidateWhenTransactionIsInvalidForSnip1ReturnsFailure()
    {
        var validator = CreateValidator(RuleTier.SNIP1);
        var transaction = CreateTransactionWithStHeader();

        var (isValid, error) = validator.Validate(CreateIsa(), CreateGs(), CreateSt(), transaction);

        Assert.False(isValid);
        Assert.NotNull(error);
        Assert.Contains($"{RuleTier.SNIP1} validation failed:", error);
    }

    /// <summary>
    /// Uses a missing required Loop 1000A field to assert SNIP2 failure detection.
    /// </summary>
    [Fact]
    public void ValidateWhenTransactionIsInvalidForSnip2ReturnsFailure()
    {
        var validator = CreateValidator(RuleTier.SNIP2);
        var transaction = CreateTransactionWith1000A1000BMissingRequiredFieldForSnip2();

        var (isValid, error) = validator.Validate(CreateIsa(), CreateGs(), CreateSt(), transaction);

        Assert.False(isValid);
        Assert.NotNull(error);
        Assert.Contains($"{RuleTier.SNIP2} validation failed:", error);
    }

    /// <summary>
    /// Mutates a balanced amount to force a SNIP3 balancing failure on realistic sample input.
    /// </summary>
    [Fact]
    public void ValidateWhenTransactionIsInvalidForSnip3ReturnsFailure()
    {
        var validator = CreateValidator(RuleTier.SNIP3);
        var transaction = CreateTransactionFromMutatedSample(CreateSnip3BalancingFailurePayload);

        var (isValid, error) = validator.Validate(CreateIsa(), CreateGs(), CreateSt(), transaction);

        Assert.False(isValid);
        Assert.NotNull(error);
        Assert.Contains($"{RuleTier.SNIP3} validation failed:", error);
        Assert.DoesNotContain("RequiredSegmentMissing", error);
    }

    /// <summary>
    /// Mutates date-format qualifiers to force an inter-segment SNIP4 failure.
    /// </summary>
    [Fact]
    public void ValidateWhenTransactionIsInvalidForSnip4ReturnsFailure()
    {
        var validator = CreateValidator(RuleTier.SNIP4);
        var transaction = CreateTransactionFromMutatedSample(CreateSnip4InterSegmentFailurePayload);

        var (isValid, error) = validator.Validate(CreateIsa(), CreateGs(), CreateSt(), transaction);

        Assert.False(isValid);
        Assert.NotNull(error);
        Assert.Contains($"{RuleTier.SNIP4} validation failed:", error);
        Assert.DoesNotContain("RequiredSegmentMissing", error);
    }

    /// <summary>
    /// Ensures a chained pipeline short-circuits at SNIP5 after SNIP1-4 pass.
    /// </summary>
    [Fact]
    public void ValidateSnip5ChainRunsSnip1ToSnip4ThenFailsAtSnip5()
    {
        var transaction = CreateTransactionFromMutatedSample(static edi => edi);
        var validators = new IX12Validator<TS837P>[]
        {
            CreateValidator(RuleTier.SNIP1),
            CreateValidator(RuleTier.SNIP2),
            CreateValidator(RuleTier.SNIP3),
            CreateValidator(RuleTier.SNIP4),
            new StubSnip5FailValidator()
        };

        var result = ValidateChain(validators, transaction);

        Assert.False(result.IsValid);
        Assert.Equal(5, result.ExecutedCount);
        Assert.Equal("SNIP5 stub failure for tests.", result.Error);
    }

    /// <summary>
    /// Ensures a chained pipeline short-circuits at SNIP6 after prior validators pass.
    /// </summary>
    [Fact]
    public void ValidateSnip6ChainRunsThroughSnip5ThenFailsAtSnip6()
    {
        var transaction = CreateTransactionFromMutatedSample(static edi => edi);
        var validators = new IX12Validator<TS837P>[]
        {
            CreateValidator(RuleTier.SNIP1),
            CreateValidator(RuleTier.SNIP2),
            CreateValidator(RuleTier.SNIP3),
            CreateValidator(RuleTier.SNIP4),
            new StubSnip5PassValidator(),
            new StubSnip6FailValidator()
        };

        var result = ValidateChain(validators, transaction);

        Assert.False(result.IsValid);
        Assert.Equal(6, result.ExecutedCount);
        Assert.Equal("SNIP6 stub failure for tests.", result.Error);
    }

    /// <summary>
    /// Ensures a chained pipeline short-circuits at SNIP7 after prior validators pass.
    /// </summary>
    [Fact]
    public void ValidateSnip7ChainRunsThroughSnip6ThenFailsAtSnip7()
    {
        var transaction = CreateTransactionFromMutatedSample(static edi => edi);
        var validators = new IX12Validator<TS837P>[]
        {
            CreateValidator(RuleTier.SNIP1),
            CreateValidator(RuleTier.SNIP2),
            CreateValidator(RuleTier.SNIP3),
            CreateValidator(RuleTier.SNIP4),
            new StubSnip5PassValidator(),
            new StubSnip6PassValidator(),
            new StubSnip7FailValidator()
        };

        var result = ValidateChain(validators, transaction);

        Assert.False(result.IsValid);
        Assert.Equal(7, result.ExecutedCount);
        Assert.Equal("SNIP7 stub failure for tests.", result.Error);
    }

    /// <summary>
    /// Creates the concrete validator used for SNIP1-SNIP4 tests.
    /// </summary>
    private static IX12Validator<TS837P> CreateValidator(RuleTier tier) => tier switch
    {
        RuleTier.SNIP1 => new TS837PSnip1Validator(),
        RuleTier.SNIP2 => new TS837PSnip2Validator(),
        RuleTier.SNIP3 => new TS837PSnip3Validator(),
        RuleTier.SNIP4 => new TS837PSnip4Validator(),
        _ => throw new ArgumentOutOfRangeException(nameof(tier), tier, "Only SNIP1-SNIP4 are supported.")
    };

    private static ISA CreateIsa() => new()
    {
        SenderIDQualifier_5 = "ZZ",
        InterchangeSenderID_6 = "SENDER",
        ReceiverIDQualifier_7 = "ZZ",
        InterchangeReceiverID_8 = "RECEIVER"
    };

    private static GS CreateGs() => new()
    {
        SenderIDCode_2 = "APP-SENDER",
        ReceiverIDCode_3 = "APP-RECEIVER",
        VersionAndRelease_8 = "005010X222A1"
    };

    private static ST CreateSt() => new()
    {
        TransactionSetIdentifierCode_01 = "837",
        TransactionSetControlNumber_02 = "0001",
        ImplementationConventionPreference_03 = "005010X222A1"
    };

    private static TS837P CreateTransactionWithStHeader() => new()
    {
        ST = CreateSt()
    };

    private static TS837P CreateTransactionWith1000A1000BMissingRequiredFieldForSnip2() => new()
    {
        ST = CreateSt(),
        AllNM1 = new All_NM1_837P_6
        {
            Loop1000A = new Loop_1000A_837P
            {
                // Intentionally omit NM103 (NameLastorOrganizationName_12) to trigger SNIP2 required-field failure.
                NM1_SubmitterName = new NM1_InformationReceiverName_4
                {
                    EntityIdentifierCode_01 = "41",
                    EntityTypeQualifier_02 = "2"
                }
            },
            Loop1000B = new Loop_1000B_837P
            {
                NM1_ReceiverName = new NM1_ReceiverName
                {
                    EntityIdentifierCode_01 = "40",
                    EntityTypeQualifier_02 = "2",
                    NameLastorOrganizationName_12 = "RECEIVER"
                }
            }
        }
    };

    /// <summary>
    /// Reads the sample payload, applies a mutation, then rehydrates a transaction object via the standard reader pipeline.
    /// </summary>
    private TS837P CreateTransactionFromMutatedSample(Func<string, string> mutation)
    {
        var original = ReadSample("837p-sample.edi");
        var mutated = mutation(original);

        using var scope = fixture.CreateScope();
        var tokenProvider = scope.ServiceProvider.GetRequiredService<IEdiTokenProvider>();
        tokenProvider.InitToken();

        using var stream = new MemoryStream(Encoding.ASCII.GetBytes(mutated));
        var readerFactory = scope.ServiceProvider.GetRequiredService<IEdiReaderFactory>();
        using var reader = readerFactory.Create(stream);
        var items = reader.ReadAll();

        return Assert.Single(items.OfType<TS837P>());
    }

    private static string ReadSample(string fileName)
    {
        using var stream = SampleFile.Open(fileName);
        using var reader = new StreamReader(stream, Encoding.ASCII, detectEncodingFromByteOrderMarks: true);
        return reader.ReadToEnd();
    }

    private static string CreateSnip3BalancingFailurePayload(string edi) =>
        ReplaceFirst(edi, "SV1*HC:99213*140*UN*1***1~", "SV1*HC:99213*100*UN*1***1~");

    private static string CreateSnip4InterSegmentFailurePayload(string edi) =>
        ReplaceFirst(edi, "DTP*472*D8*20151124~", "DTP*472*RD8*20151124~");

    /// <summary>
    /// Replaces the first matching segment text to produce deterministic invalid sample variants.
    /// </summary>
    private static string ReplaceFirst(string input, string oldValue, string newValue)
    {
        var index = input.IndexOf(oldValue, StringComparison.Ordinal);
        if (index < 0)
            throw new InvalidOperationException($"Could not find '{oldValue}' in sample payload.");

        return string.Concat(
            input.AsSpan(0, index),
            newValue,
            input.AsSpan(index + oldValue.Length));
    }

    /// <summary>
    /// Runs validators in order and returns the first failure plus the execution count.
    /// </summary>
    private static ValidationChainResult ValidateChain(IReadOnlyList<IX12Validator<TS837P>> validators, TS837P transaction)
    {
        var isa = CreateIsa();
        var gs = CreateGs();
        var st = CreateSt();

        var executedCount = 0;
        foreach (var validator in validators)
        {
            executedCount++;
            var (isValid, error) = validator.Validate(isa, gs, st, transaction);
            if (!isValid)
                return new ValidationChainResult(false, error, executedCount);
        }

        return new ValidationChainResult(true, null, executedCount);
    }

    private sealed record ValidationChainResult(bool IsValid, string? Error, int ExecutedCount);

    private sealed class StubSnip5PassValidator : IX12Validator<TS837P>
    {
        public (bool, string?) Validate(ISA isa, GS? gs, ST st, TS837P item) => (true, null);
    }

    private sealed class StubSnip5FailValidator : IX12Validator<TS837P>
    {
        public (bool, string?) Validate(ISA isa, GS? gs, ST st, TS837P item) => (false, "SNIP5 stub failure for tests.");
    }

    private sealed class StubSnip6PassValidator : IX12Validator<TS837P>
    {
        public (bool, string?) Validate(ISA isa, GS? gs, ST st, TS837P item) => (true, null);
    }

    private sealed class StubSnip6FailValidator : IX12Validator<TS837P>
    {
        public (bool, string?) Validate(ISA isa, GS? gs, ST st, TS837P item) => (false, "SNIP6 stub failure for tests.");
    }

    private sealed class StubSnip7FailValidator : IX12Validator<TS837P>
    {
        public (bool, string?) Validate(ISA isa, GS? gs, ST st, TS837P item) => (false, "SNIP7 stub failure for tests.");
    }
}
