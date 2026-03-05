param(
    [string]$Bucket,
    [string]$Prefix,
    [string]$SourceDir,
    [string]$Glob,
    [string]$HostName,
    [int]$Port
)

$ErrorActionPreference = 'Stop'
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir
$repoRoot = Resolve-Path (Join-Path $scriptDir '..\..')
$settingsPath = Join-Path $repoRoot 'appsettings.json'
$settings = Get-Content -Raw $settingsPath | ConvertFrom-Json

if (-not $PSBoundParameters.ContainsKey('Bucket')) {
    $Bucket = [string]$settings.S3.Bucket
}
if (-not $PSBoundParameters.ContainsKey('Prefix')) {
    $Prefix = [string]$settings.S3.Prefix
}
if (-not $PSBoundParameters.ContainsKey('SourceDir')) {
    $SourceDir = [string]$settings.Seeder.SourceDir
}
if (-not $PSBoundParameters.ContainsKey('Glob')) {
    $Glob = [string]$settings.Seeder.Glob
}
if (-not $PSBoundParameters.ContainsKey('HostName')) {
    $HostName = [string]$settings.S3.Moto.Host
}
if (-not $PSBoundParameters.ContainsKey('Port')) {
    $Port = [int]$settings.S3.Moto.Port
}

$venvPython = Join-Path $scriptDir '.venv\Scripts\python.exe'
if (-not (Test-Path $venvPython)) {
    .\setup.ps1
}

if (-not (Test-Path $venvPython)) {
    Write-Error "Virtual environment not found. Run .\setup.ps1 first."
}

$motoArgs = @('run_moto_s3.py', '--host', $HostName, '--port', $Port)
$motoProcess = Start-Process -FilePath $venvPython -ArgumentList $motoArgs -PassThru -WindowStyle Hidden

try {
    Start-Sleep -Seconds 2
    $endpointUrl = "http://$HostName`:$Port"

    .\seed_s3.ps1 -Bucket $Bucket -Prefix $Prefix -SourceDir $SourceDir -Glob $Glob -EndpointUrl $endpointUrl
    .\run_service.ps1 -Bucket $Bucket -Prefix $Prefix -EndpointUrl $endpointUrl -Once
}
finally {
    if ($motoProcess -and -not $motoProcess.HasExited) {
        Stop-Process -Id $motoProcess.Id -Force
    }
}
