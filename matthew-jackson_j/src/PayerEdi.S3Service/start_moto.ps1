param(
    [string]$HostName,
    [int]$Port
)

$ErrorActionPreference = 'Stop'
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir
$repoRoot = Resolve-Path (Join-Path $scriptDir '..\..')
$settingsPath = Join-Path $repoRoot 'appsettings.json'
$settings = Get-Content -Raw $settingsPath | ConvertFrom-Json

if (-not $PSBoundParameters.ContainsKey('HostName')) {
    $HostName = [string]$settings.S3.Moto.Host
}

if (-not $PSBoundParameters.ContainsKey('Port')) {
    $Port = [int]$settings.S3.Moto.Port
}

$venvPython = Join-Path $scriptDir '.venv\Scripts\python.exe'
if (-not (Test-Path $venvPython)) {
    Write-Error "Virtual environment not found. Run .\setup.ps1 first."
}

& $venvPython run_moto_s3.py --host $HostName --port $Port
