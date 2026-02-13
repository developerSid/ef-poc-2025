param(
    [Parameter(Mandatory=$true)]
    [string]$Bucket,
    [string]$Prefix = 'inbound',
    [string]$SourceDir = '..\..\samples',
    [string]$Glob = '*.edi',
    [string]$EndpointUrl = 'http://127.0.0.1:5000',
    [string]$Region = 'us-east-1'
)

$ErrorActionPreference = 'Stop'
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir

$venvPython = Join-Path $scriptDir '.venv\Scripts\python.exe'
if (-not (Test-Path $venvPython)) {
    Write-Error "Virtual environment not found. Run .\setup.ps1 first."
}

& $venvPython seed_bucket.py --endpoint-url $EndpointUrl --region $Region --bucket $Bucket --source-dir $SourceDir --glob $Glob --prefix $Prefix