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
- Override defaults with environment variables:
  - `PAYEREDI_S3_HOST`
  - `PAYEREDI_S3_PORT`

If setup says Python is missing, install it once:

```powershell
winget install -e --id Python.Python.3.12
```

Then rerun `./setup.ps1`.

## Run it end-to-end (local)
Fast path (single command):

```powershell
cd src/PayerEdi.S3Service
.\run_phase2_once.ps1
```

This starts moto in the background, seeds sample `.edi` files, runs the async service once, then stops moto.

## Moto-only run (recommended for C# unit tests)
Start only the moto S3 service:

```powershell
cd src/PayerEdi.S3Service
.\start_moto.ps1
```

or press Run in Visual Studio (startup file `launch.py`).

Manual path:

Open terminal A:

```powershell
cd src/PayerEdi.S3Service
.\start_moto.ps1
```

Open terminal B:

```powershell
cd src/PayerEdi.S3Service
.\seed_s3.ps1 -Bucket payeredi-edi -Prefix inbound
.\run_service.ps1 -Bucket payeredi-edi -Prefix inbound -Once
```

Expected result:
- `.edi` files are picked up from `inbound/`
- service logs each file as processed
- files are moved to `processed/` by default

## Optional downstream processor
By default, the service uses a built-in validation processor (checks file is readable).

To run your own processor per file, pass `--command` directly:

```powershell
.\.venv\Scripts\python.exe .\PayerEdi.S3Service.py --bucket payeredi-edi --prefix inbound --once --command dotnet run --project src/PayerEdi.EdiFabric.Console --
```

The service appends the local downloaded file path as the final argument.