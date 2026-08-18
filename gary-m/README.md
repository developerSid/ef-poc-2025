# Gary's X12 Onboarding

## Progress

Developer status checklist

| Phase      | Task             | Sub-Task                                       | Status |
|------------|------------------|------------------------------------------------|:------:|
| 🟩 Phase 1 | Setup Project    | Create .NET 10 console/web app                 |   ✅   |
| 🟩 Phase 1 | Setup Project    | Add EdiFabric NuGet Packages                   |   ✅   |
| 🟩 Phase 1 | Setup Project    | Configure SQL Server Express connection        |   ✅   |
| 🟩 Phase 1 | Setup Project    | Use Entity Framework Core                      |   🟨   |
| 🟩 Phase 1 | Implementation   | Ingest sample 837 EDI file using EdiFabric     |   ✅   |
| 🟩 Phase 1 | Implementation   | Parse EDI segments (ISA, GS, ST, BHT, etc.)    |   ✅   |
| 🟩 Phase 1 | Implementation   | Map to database entities                       |   🟨   |
| 🟩 Phase 1 | Implementation   | Store parsed data in SQL Server Express        |   🟨   |
| 🟩 Phase 1 | Implementation   | Include 1 unit test (XUnit/NUnit)              |   ✅   |
| 🟩 Phase 1 | Deliverables     | Working C# application                         |   ✅   |
| 🟩 Phase 1 | Deliverables     | Database schema/migrations                     |   ✅   |
| 🟩 Phase 1 | Deliverables     | Sample 837 test file                           |   ✅   |
| 🟩 Phase 1 | Deliverables     | Unit test coverage                             |   🟨   |
| 🟩 Phase 1 | Deliverables     | README with setup instructions                 |   🟨   |
| 🟩 Phase 1 | Deliverables     | Phase 1 demo                                   |   ⬛   |
| 🟦 Phase 2 | S3 Integration   | Use moto.py for S3                             |   ⬛   |
| 🟦 Phase 2 | S3 Integration   | Read EDI file from S3 bucket                   |   ⬛   |
| 🟦 Phase 2 | S3 Integration   | Process files asynchronously                   |   ⬛   |
| 🟦 Phase 2 | Success Criteria | Application successfully parses 837 EDI file   |   ⬛   |
| 🟦 Phase 2 | Success Criteria | Data is correctly stored in SQL Server Express |   ⬛   |
| 🟦 Phase 2 | Success Criteria | At least one unit test passes                  |   ⬛   |
| 🟦 Phase 2 | Success Criteria | Code is properly documented                    |   ⬛   |
| 🟦 Phase 2 | Success Criteria | Peer review completed                          |   ⬛   |
| 🟦 Phase 2 | Success Criteria | Phase 2 demo                                   |   ⬛   |
| 🟥 Phase 3 | SNIP Validation  | Add SNIP Validation Level                      |   ⬛   |

**Status Key**

- `⬛` Not started
- `🟨` In progress
- `✅` Complete
- `❌` Blocked


--- 
# Bellow needs a lot of work read at your own peril
## Setup

I am using .NET 10. I used
the [dotnet-install](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script) script with
`dotnet-install.sh -Channel lts` or `dotnet-install.sh -Channel 10.0` to install the tooling. On Linux this will put the
tooling in _~/.dotnet_, so be sure to add that to your path.

### Project Structure

* [src/PayerEDI.Data](./src/PayerEDI.Data/README.md)
    * Domain models and entities for processing X12 EDI data
* [src/PayerEDI.Processor.Console](./src/PayerEDI.Processor.Console/README.md)
    * Simple CLI tool for processing an EDI File
* [tests/]

## Usage

### Quick and dirty

#### The Easy Way

```shell
./.helpers/payeredi-db-start
# TODO: Migrate the db with EF Core
./.helpers/payeredi-dental
./.helpers/payeredi-professional
./.helpers/payeredi-db-stop
```

#### The Hard Way

```shell
docker compose --profile db up -d vadb
# wait a little bit for the db to come up
docker compose --profile db run --rm --no-deps db-init
# You will need EDI_PROCESSOR_KEY__EDIFABRIC set in your terminal
dotnet run --project src/PayerEDI.Processor.Console --launch-profile dental
dotnet run --project src/PayerEDI.Processor.Console --launch-profile professional
dotnet test
docker compose --profile db down --remove-orphans
```

MSSQL is hosted for this branch in docker using docker compose see [docker-compose.yaml](./docker-compose.yaml)

## Local Development Automation

The database architecture intentionally separates setup privileges from runtime privileges:

* `vadb` is the SQL Server container. Its `/var/opt/mssql` directory is backed by the named `vadb` volume, so stopping
  or recreating the container does not remove the database.
* `db-init` is a short-lived SQL command container. It uses `sa` to run `database/bootstrap.sql`, which is safe to run
  repeatedly.
* EF migrations own schema changes and are run with `EDI_PROCESSOR_CONNECTIONSTRINGS__MIGRATION`.
* The console uses `EDI_PROCESSOR_CONNECTIONSTRINGS__DEFAULT` and the restricted `payeredi_app` login. The runtime
  account is not granted permission to create tables or apply migrations.

The default development credentials are `password_123` for `sa` and `payeredi_app_password` for `payeredi_app`. To
override them, create an untracked `.env` file in the repository root:

```dotenv
MSSQL_SA_PASSWORD=replace-this-sa-password
PAYEREDI_APP_PASSWORD=replace-this-app-password
```

When custom credentials are used, update the launch-profile connection string or provide an explicit
`EDI_PROCESSOR_CONNECTIONSTRINGS__DEFAULT` value for the console process as well.

### Local Scripts

The functional-test database is disposable and stores SQL Server data in a Docker `tmpfs`:

```shell
./.helpers/payeredi-ft-db-start
./.helpers/payeredi-ft-test
./.helpers/payeredi-ft-db-stop
```

It runs as `vadb-test` on host port `1434`, while the persistent development database remains `vadb` on
port `1433`. The functional-test project is `tests/PayerEDI.Test.FT`; its connection can be overridden with
`PAYEREDI_TEST_CONNECTION_STRING`.

| Script                    | Purpose                                                                                                  |
|---------------------------|----------------------------------------------------------------------------------------------------------|
| `payeredi-db-start`       | Starts SQL Server, waits for health, and reruns the idempotent database bootstrap.                       |
| `payeredi-db-migrate`     | Applies pending EF Core migrations with the administrative connection.                                   |
| `payeredi-db-stop`        | Stops the Compose services while preserving the `vadb` volume.                                           |
| `payeredi-db-reset --yes` | Destructively removes the Compose services and `vadb` volume. Without `--yes`, it asks for confirmation. |
| `payeredi-dental`         | Runs the console with the `dental` launch profile.                                                       |
| `payeredi-professional`   | Runs the console with the `professional` launch profile.                                                 |
| `payeredi-ft-db-start`    | Starts, bootstraps, and migrates the disposable functional-test SQL Server.                              |
| `payeredi-ft-test`        | Runs the SQL Server-backed `PayerEDI.Tests.FT` project.                                                  |
| `payeredi-ft-db-stop`     | Stops the functional-test SQL Server and discards its tmpfs data.                                        |
| `payeredi-down`            | Stops and removes all Compose containers while preserving named volumes.                                  |
| `pretty-code              | Runs csharpier against _src/_ and _tests/_                                                               |

Use `payeredi-db-stop` for a normal shutdown. Use `payeredi-db-reset --yes` only when the local database should be
recreated from scratch; it deletes all data in the named volume.

## Formatting

To format the code consistently using the .Net default run

### The Easy Way

```shell
./.helpers/pretty-code
```

### The Hard Way

```shell
dotnet csharpier format src/
dotnet csharpier format tests/
```
