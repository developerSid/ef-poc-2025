using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PayerEdi.Pharmacy.Data.Hipaa837p;

var outputPath = ResolveOutputPath(args);
var lines = BuildReport();

Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
File.WriteAllLines(outputPath, lines, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

Console.WriteLine($"Report written: {outputPath}");
Console.WriteLine($"Rows: {Math.Max(lines.Count - 7, 0)}");

return;

static List<string> BuildReport()
{
    using var context = new Hipaa837pDbContextFactory().CreateDbContext(Array.Empty<string>());

    var reportLines = new List<string>
    {
        "# DbContext Metadata Report",
        string.Empty,
        $"Generated (UTC): {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}",
        string.Empty,
        "## Columns",
        "- `dbset`: DbSet property name on `Hipaa837pDbContext`",
        "- `prop`: EF property name",
        "- `null`: `?` nullable, `!` required",
        "- `shadow`: `S` shadow property, `-` CLR-backed property",
        "- `len`: effective length (`2147483647` means SQL `max`)",
        "- `prec`: effective precision",
        "- `scale`: effective scale",
        "- `sql`: SQL type family/source (for example `nvarchar`, `char`, `decimal`)",
        string.Empty,
        "```text",
        "dbset|prop|null|shadow|len|prec|scale|sql"
    };

    var dbSetEntries = typeof(Hipaa837pDbContext)
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(prop =>
            prop.PropertyType.IsGenericType &&
            prop.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
        .Select(prop => new
        {
            DbSetName = prop.Name,
            EntityClrType = prop.PropertyType.GetGenericArguments()[0]
        })
        .DistinctBy(entry => entry.EntityClrType)
        .OrderBy(entry => entry.DbSetName)
        .ToArray();

    if (dbSetEntries.Length == 0)
        throw new InvalidOperationException("No DbSet<> properties found on Hipaa837pDbContext.");

    foreach (var entry in dbSetEntries)
    {
        var entityType = context.Model.FindEntityType(entry.EntityClrType)
            ?? throw new InvalidOperationException($"Entity type '{entry.EntityClrType.Name}' was not found in the EF model.");

        foreach (var property in entityType.GetProperties().OrderBy(p => p.Name))
        {
            var nullability = property.IsNullable ? "?" : "!";
            var shadow = property.IsShadowProperty() ? "S" : "-";
            var modelPrecision = property.GetPrecision();
            var modelScale = property.GetScale();
            var modelMaxLength = property.GetMaxLength();
            var modelColumnType = property.GetColumnType();

            var clrProperty = property.IsShadowProperty()
                ? null
                : entry.EntityClrType.GetProperty(property.Name, BindingFlags.Instance | BindingFlags.Public);
            var maxLengthAttribute = clrProperty?.GetCustomAttribute<MaxLengthAttribute>()?.Length;
            var stringLengthAttribute = clrProperty?.GetCustomAttribute<StringLengthAttribute>()?.MaximumLength;
            var precisionAttribute = clrProperty?.GetCustomAttribute<PrecisionAttribute>();
            var columnAttributeTypeName = clrProperty?.GetCustomAttribute<ColumnAttribute>()?.TypeName;
            var attributeLength = maxLengthAttribute ?? stringLengthAttribute;

            var parsedSqlType = ParseSqlTypeDefinition(modelColumnType ?? columnAttributeTypeName);

            var effectiveLength = modelMaxLength ?? attributeLength ?? parsedSqlType?.Length;
            if (effectiveLength == -1)
                effectiveLength = int.MaxValue;

            var effectivePrecision = modelPrecision ?? precisionAttribute?.Precision ?? parsedSqlType?.Precision;
            var effectiveScale = modelScale ?? precisionAttribute?.Scale ?? parsedSqlType?.Scale;
            var sqlTypeDisplay = parsedSqlType?.TypeName ?? modelColumnType ?? columnAttributeTypeName;

            reportLines.Add(
                $"{entry.DbSetName}|{property.Name}|{nullability}|{shadow}|{DisplayInt(effectiveLength)}|{DisplayInt(effectivePrecision)}|{DisplayInt(effectiveScale)}|{DisplayText(sqlTypeDisplay)}");
        }
    }

    reportLines.Add("```");
    return reportLines;
}

static string DisplayInt(int? value) => value?.ToString() ?? "-";

static string DisplayText(string? value) => string.IsNullOrWhiteSpace(value) ? "-" : value;

static SqlTypeDefinition? ParseSqlTypeDefinition(string? definition)
{
    if (string.IsNullOrWhiteSpace(definition))
        return null;

    var trimmed = definition.Trim();
    var openParen = trimmed.IndexOf('(');
    if (openParen < 0)
        return new SqlTypeDefinition(trimmed.ToLowerInvariant(), null, null, null);

    var closeParen = trimmed.IndexOf(')', openParen + 1);
    if (closeParen < 0)
        return new SqlTypeDefinition(trimmed[..openParen].Trim().ToLowerInvariant(), null, null, null);

    var typeName = trimmed[..openParen].Trim().ToLowerInvariant();
    var args = trimmed[(openParen + 1)..closeParen].Trim();

    if (string.Equals(args, "max", StringComparison.OrdinalIgnoreCase))
        return new SqlTypeDefinition(typeName, -1, null, null);

    var parts = args.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 1 && int.TryParse(parts[0], out var single))
    {
        if (IsLengthBasedType(typeName))
            return new SqlTypeDefinition(typeName, single, null, null);

        return new SqlTypeDefinition(typeName, null, single, null);
    }

    if (parts.Length >= 2 &&
        int.TryParse(parts[0], out var precision) &&
        int.TryParse(parts[1], out var scale))
    {
        return new SqlTypeDefinition(typeName, null, precision, scale);
    }

    return new SqlTypeDefinition(typeName, null, null, null);
}

static bool IsLengthBasedType(string typeName) =>
    typeName is "char" or "nchar" or "varchar" or "nvarchar" or "binary" or "varbinary";

static string ResolveOutputPath(string[] appArgs)
{
    var explicitPath = appArgs.FirstOrDefault();
    if (!string.IsNullOrWhiteSpace(explicitPath))
        return Path.GetFullPath(explicitPath);

    var current = new DirectoryInfo(AppContext.BaseDirectory);
    while (current is not null)
    {
        var docsPath = Path.Combine(current.FullName, "docs");
        if (Directory.Exists(docsPath))
            return Path.Combine(docsPath, "DBCONTEXT_METADATA_REPORT.md");

        current = current.Parent;
    }

    return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "docs", "DBCONTEXT_METADATA_REPORT.md"));
}

internal sealed record SqlTypeDefinition(string TypeName, int? Length, int? Precision, int? Scale);
