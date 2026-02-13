param(
    [string]$Bucket = 'payeredi-edi',
    [string]$Prefix = 'inbound',
    [string]$SourceDir = '..\..\samples',
    [string]$Glob = '*.edi',
    [string]$HostName = '127.0.0.1',
    [int]$Port = 5000
)

$ErrorActionPreference = 'Stop'
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir

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