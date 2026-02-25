# PayerEdi.S3Service

## What this is
A self-contained Python service for Phase 2 S3 integration:
- runs against local moto S3
- reads `.edi` files from a bucket
- processes files asynchronously
- optionally moves or deletes files after success

## Prerequisites
- Python 3.12+
- For optional downstream `.NET` processing: .NET SDK and SQL Server Express configured for the console app

## One-time setup
From repo root:

```powershell
cd src/PayerEdi.S3Service
.\setup.ps1
```

For Visual Studio:
- Open Python Environments for `PayerEdi.S3Service`.
- Select interpreter `src\PayerEdi.S3Service\.venv\Scripts\python.exe`.
- If the environment does not appear automatically, add it as an existing environment using that path.
- Startup file is `launch.py` so pressing Run starts moto only (no S3 file seed/process I/O).
- Default Run values (when no args are passed):
  - `--host 127.0.0.1`
  - `--port 5000`
- Defaults are loaded from root `appsettings.json` (`S3:Moto:Host`, `S3:Moto:Port`).
- See `docs/CONFIGURATION.md` for full configuration keys.

If setup says Python is missing, install it once:

```powershell
winget install -e --id Python.Python.3.12
```

Then rerun `./setup.ps1`.

## Phase 2 Run Modes

### Mode A: Python service only (end-to-end local)
Fast path (single command):

```powershell
cd src/PayerEdi.S3Service
.\run_phase2_once.ps1
```

This starts moto in the background, seeds sample `.edi` files, runs the async service once, then stops moto.

Manual path (two terminals):

Open terminal A (moto):

```powershell
cd src/PayerEdi.S3Service
.\start_moto.ps1
```

Open terminal B (seed + process once):

```powershell
cd src/PayerEdi.S3Service
.\seed_s3.ps1 -Bucket payeredi-edi -Prefix inbound
.\run_service.ps1 -Bucket payeredi-edi -Prefix inbound -Once
```

Expected result:
- `.edi` files are picked up from `inbound/`
- service logs each file as processed
- files are moved to `processed/` by default
- Visual Studio alternative: press Run on `PayerEdi.S3Service` to start moto only (`launch.py`).

### Mode B: Visual Studio integration run (`PayerEdi.S3Service` + `PayerEdi.EdiFabric.MotoConsole`)
Use this mode when you want Phase 2 S3 ingestion and .NET SQL persistence validation in the same run.

Visual Studio project setup:
- Open solution `PayerEdi.Pharmacy.slnx`.
- Set startup projects to `Multiple startup projects`.
- Set `PayerEdi.S3Service` to `Start`.
- Set `PayerEdi.EdiFabric.MotoConsole` to `Start`.

Expected outcome:
- `PayerEdi.EdiFabric.MotoConsole` uploads `837p-sample.edi` to `inbound/`
- the file is downloaded and ingested
- `TS837P` persistence is validated in SQL Server

Notes:
- `PayerEdi.EdiFabric.MotoConsole` includes a short startup wait to reduce race conditions while moto starts listening.
- If moto uses a non-default endpoint, pass `--endpoint` to `MotoConsole`.

### Mode C: Visual Studio validated integration run (`PayerEdi.S3Service` + `PayerEdi.EdiFabric.ValidatedConsole`)
Use this mode when you want S3 ingestion, SQL persistence, and SNIP pre-save validation in one run.

Visual Studio project setup:
- Open solution `PayerEdi.Pharmacy.slnx`.
- Set startup projects to `Multiple startup projects`.
- Set `PayerEdi.S3Service` to `Start`.
- Set `PayerEdi.EdiFabric.ValidatedConsole` to `Start`.

Expected outcome:
- `PayerEdi.EdiFabric.ValidatedConsole` uploads `837p-sample.edi` to `inbound/`.
- The file is downloaded and processed through configured SNIP validation (`SnipValidation:Level`).
- Valid transactions persist to SQL Server.

Notes:
- Validated mode currently supports SNIP levels 1-4.
- Validation is applied before persistence via the `IIngestionPreSaveHook` pipeline.

## Solution Launch Profiles
The repository includes `PayerEdi.Pharmacy.slnLaunch` with these named launch profiles:
- `Console`
- `MotoConsole`
- `ValidatedConsole`

## Optional downstream processor
By default, the service uses a built-in validation processor (checks file is readable).

To run your own processor per file, pass `--command` directly:

```powershell
.\.venv\Scripts\python.exe .\PayerEdi.S3Service.py --bucket payeredi-edi --prefix inbound --once --command dotnet run --project src/PayerEdi.EdiFabric.Console --
```

The service appends the local downloaded file path as the final argument.
