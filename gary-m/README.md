# Gary's X12 Onboarding

## Progress

Developer status checklist

| Phase      | Task             | Sub-Task                                       | Status |
|------------|------------------|------------------------------------------------|:------:|
| 🟩 Phase 1 | Setup Project    | Create .NET 10 console/web app                 |   ✅   |
| 🟩 Phase 1 | Setup Project    | Add EdiFabric NuGet Packages                   |   ✅   |
| 🟩 Phase 1 | Setup Project    | Configure SQL Server Express connection        |   ✅   |
| 🟩 Phase 1 | Setup Project    | Use Entity Framework Core                      |   ✅   |
| 🟩 Phase 1 | Implementation   | Ingest sample 837 EDI file using EdiFabric     |   ✅   |
| 🟩 Phase 1 | Implementation   | Parse EDI segments (ISA, GS, ST, BHT, etc.)    |   ✅   |
| 🟩 Phase 1 | Implementation   | Map to database entities                       |   ✅   |
| 🟩 Phase 1 | Implementation   | Store parsed data in SQL Server Express        |   ✅   |
| 🟩 Phase 1 | Implementation   | Include 1 unit test (XUnit/NUnit)              |   ✅   |
| 🟩 Phase 1 | Deliverables     | Working C# application                         |   ✅   |
| 🟩 Phase 1 | Deliverables     | Database schema/migrations                     |   ✅   |
| 🟩 Phase 1 | Deliverables     | Sample 837 test file                           |   ✅   |
| 🟩 Phase 1 | Deliverables     | Unit test coverage                             |   🟨   |
| 🟩 Phase 1 | Deliverables     | README with setup instructions                 |   ✅   |
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

## Project Structure

* [src/PayerEDI.Data](./src/PayerEDI.Data/README.md)
    * Domain models and entities for processing X12 EDI data
* [src/PayerEDI.Processor.Console](./src/PayerEDI.Processor.Console/README.md)
    * Simple CLI tool for processing an EDI File
* [tests/PayerEDI.Tests]
    * Unit tests for small parts of the Data project
* [.github/skills/map-837-to-domain](./.github/skills/map-837-to-domain/SKILL.md)
    * Guidance for mapping EdiFabric transactions to the existing domain factories without assuming a fixed service-line segment

## Setup

I'm running on Fedora Linux 44 (Workstation), and I have Docker installed and my user is in the docker user group so no
sudo is required to run docker commands. If you do this on Linux you may have to prepend `sudo` to the commands bellow.
Note most of this should work on Windows with minor changes, but it is all untested for now.

1. Install .Net 10
    1. Using [dotnet-install](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script) and assuming
       its on your path run `dotnet-install.sh -Channel 10.0` or if 10 is still LTS run
       `dotnet-install.sh -Channel LTS`. This will put the installed tooling in _~/.dotnet_ so be sure you add that to
       your $PATH.
    2. Alternative method would be via package manager or download from Microsoft.
2. Clone the repo and change directory there. All additional steps will take place there.

## Usage

The database is hosted in Docker using Docker Compose.

### The Direct Way

#### Step 1 Start the database in the foreground

`docker compose up vadb`

Wait for the db to become healthy, watch the output from the terminal

Docker Compose gives you the option of detaching by pressing D or padding the `-d` switch you prefer to not watch the
terminal once the db starts up

#### Step 2 Initialize the database

```shell
docker compose run --rm --no-deps db-init
```

```shell 
export EDI_PROCESSOR_CONNECTIONSTRINGS__MIGRATION="Server=localhost,1433;Database=PayerEdi;User Id=sa;Password=password_123;TrustServerCertificate=True"
dotnet tool restore
dotnet ef database update \
    --project src/PayerEDI.Data \
    --startup-project src/PayerEDI.Processor.Console
```

#### Step 3. Run Some Software

A simple console app has been built in src/PayerEDI.Processor.Console that has 3 predefined launch profiles. The app
itself isn't very smart, it just parses and EDI file and somes some data to the database that should be now running and
prepared. An environment variable called **EDI_PROCESSOR_KEY__EDIFABRIC** will need to be exported before running
anything through this console app. Note that the **EDI_PROCESSOR_CONNECTIONSTRINGS__DEFAULT** is stored in the
src/PayerEDI.Processor.Console/Properties/launchSettings.json for each profile configured there. If you run anything
other than the provided launch profiles you'll need to export that as well (See above for that).

Processing the 837D - Dental File

```shell
dotnet run --project src/PayerEDI.Processor.Console --launch-profile dental
```

Processing the simple fields 837P - Professional File

```shell
dotnet run --project src/PayerEDI.Processor.Console --launch-profile professional
```

Processing the all fields 837P - Professional File

```shell
dotnet run --project src/PayerEDI.Processor.Console --launch-profile professionalall
```

#### Step 4 Tear It All Down

```shell
docker compose down --remove-orphans --volumes
```

### The Helper Scripts Way

I had AI generate a bunch of shell scripts to make some this easier

#### With Helper Scripts

```shell
./.helpers/payeredi-db-start
./.helpers/payeredi-db-migrate
./.helpers/payeredi-dental
./.helpers/payeredi-professional
./.helpers/payeredi-professionalall
./.helpers/payeredi-db-stop
./.helpers/payeredi-db-reset --yes
```

Bellow is a breakdown of all the available scripts.

| Script                     | Purpose                                                                                                  |
|----------------------------|----------------------------------------------------------------------------------------------------------|
| `payeredi-db-start`        | Starts SQL Server, waits for health, and reruns the idempotent database bootstrap.                       |
| `payeredi-db-migrate`      | Applies pending EF Core migrations with the administrative connection.                                   |
| `payeredi-db-truncate`     | Truncates / empties all user tables in the `PayerEdi` database.                                          |
| `payeredi-db-stop`         | Stops the Compose services while preserving the `vadb` volume.                                           |
| `payeredi-db-reset --yes`  | Destructively removes the Compose services and `vadb` volume. Without `--yes`, it asks for confirmation. |
| `payeredi-dental`          | Runs the console with the `dental` launch profile.                                                       |
| `payeredi-professional`    | Runs the console with the `professional` launch profile.                                                 |
| `payeredi-professionalall` | Runs the console with the `professionalall` launch profile.                                              |
| `payeredi-down`            | Stops and removes all Compose containers while preserving named volumes.                                 |
| `pretty-code`              | Runs csharpier against _src/_ and _tests/_                                                               |

Use `payeredi-db-truncate` to quickly clear all data from user tables while preserving the database schema and migration
history. Use `payeredi-db-stop` for a normal shutdown. Use `payeredi-db-reset --yes` only when the local database should
be recreated from scratch; it deletes all data in the named volume.

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
