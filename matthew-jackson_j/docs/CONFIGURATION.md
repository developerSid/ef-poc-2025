# Configuration Reference

Configuration is stored in the repository root file:

- `appsettings.json`

Use colon notation to reference keys.

## Connection Strings

- `ConnectionStrings:HipaaDb`
  - Primary SQL Server connection string for runtime ingestion and EF migrations.
- `ConnectionStrings:SqlServerFallbackDb`
  - Fallback SQL connection string used by tests when `ConnectionStrings:HipaaDb` is not set.
  - Test fixtures override only the database/catalog name per test run.

## EdiFabric

- `EdiFabric:SerialKey`
  - EdiFabric serial key required for ingestion/token initialization.

## Ingestion

- `Ingestion:SampleFilePath`
  - Sample EDI file path used by console entry points (for example, `837p-sample.edi` in output directory).

## SNIP Validation

- `SnipValidation:Enabled`
  - Enables/disables pre-save SNIP validation hook in validated ingestion composition.
- `SnipValidation:Level`
  - Single configured SNIP tier (`SNIP1` to `SNIP4`) executed cumulatively from SNIP1 up to the selected level.

## S3 Core

- `S3:EndpointUrl`
  - S3-compatible endpoint URL (moto/local or real endpoint).
- `S3:Region`
  - AWS region identifier.
- `S3:AccessKey`
  - S3 access key.
- `S3:SecretKey`
  - S3 secret key.
- `S3:Bucket`
  - Source/target S3 bucket name.
- `S3:Prefix`
  - Inbound key prefix used for reads/writes.
- `S3:Suffix`
  - File suffix filter for processing (for example, `.edi`).
- `S3:MoveToPrefix`
  - Destination prefix for successful processing.

## S3 Moto

- `S3:Moto:Host`
  - Host for moto bind/startup.
- `S3:Moto:Port`
  - Port for moto bind/startup.
- `S3:Moto:StartupTimeoutSeconds`
  - Timeout used by test/moto startup wait logic.
- `S3:Moto:StartMoto`
  - Whether the .NET moto console starts moto itself.
- `S3:Moto:KillExistingMoto`
  - Whether to terminate existing moto listener before startup.
- `S3:Moto:KillMotoOnExit`
  - Whether to terminate moto listener on shutdown.

## Python Service

- `Service:WorkingDir`
  - Working directory for downstream command execution.
- `Service:TempDir`
  - Temp directory for downloaded S3 objects.
- `Service:MaxConcurrency`
  - Max number of concurrently processed files.
- `Service:PollIntervalSeconds`
  - Poll delay for continuous mode.
- `Service:LogLevel`
  - Python service logging level.

## Seeder

- `Seeder:SourceDir`
  - Local source directory for files uploaded by seed scripts.
- `Seeder:Glob`
  - File pattern used by seeding (for example, `*.edi`).

## Override Behavior

- .NET: Some console flags (for example `--endpoint`, `--bucket`) override configured values at runtime.
- Python/PowerShell: Script flags/parameters override values loaded from `appsettings.json`.
