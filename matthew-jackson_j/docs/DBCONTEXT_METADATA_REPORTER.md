# DbContext Metadata Reporter

## Purpose
`PayerEdi.Pharmacy.MetadataReport.Console` generates a compact Markdown report of EF Core property metadata for all `DbSet<>` entities in `Hipaa837pDbContext`.

The output is optimized for quick human/AI scanning with minimal token usage.

## What It Captures
For each EF entity property (including shadow properties), the report emits:

- `null`: `?` for nullable, `!` for required
- `shadow`: `S` if shadow property, `-` otherwise
- `len`: effective string/binary length
- `prec`: effective precision
- `scale`: effective scale
- `sql`: SQL type family/source (`nvarchar`, `char`, `decimal`, etc.)

The tool resolves values from:

1. EF model metadata (`GetMaxLength`, `GetPrecision`, `GetScale`, `GetColumnType`)
2. CLR attributes (`[MaxLength]`, `[StringLength]`, `[Precision]`, `[Column(TypeName=...)]`)
3. Parsed SQL type definitions as a fallback

`len = -1` (`max`) is normalized to `2147483647` (`int.MaxValue`).

## Run
Default output path:
`docs/DBCONTEXT_METADATA_REPORT.md`

```powershell
dotnet run --project src/PayerEdi.Pharmacy.MetadataReport.Console
```

Optional custom output path:

```powershell
dotnet run --project src/PayerEdi.Pharmacy.MetadataReport.Console -- docs/DBCONTEXT_METADATA_REPORT.md
```

## Output Shape
The report is written as a Markdown code block with pipe-delimited lines:

```text
dbset|prop|null|shadow|len|prec|scale|sql
```
