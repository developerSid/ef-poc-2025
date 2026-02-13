param(
    [string]$HostName = '127.0.0.1',
    [int]$Port = 5000
)

$ErrorActionPreference = 'Stop'
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir

$venvPython = Join-Path $scriptDir '.venv\Scripts\python.exe'
if (-not (Test-Path $venvPython)) {
    Write-Error "Virtual environment not found. Run .\setup.ps1 first."
}

& $venvPython run_moto_s3.py --host $HostName --port $Port