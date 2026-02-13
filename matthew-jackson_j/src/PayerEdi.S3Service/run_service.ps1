param(
    [Parameter(Mandatory=$true)]
    [string]$Bucket,
    [string]$Prefix = 'inbound',
    [string]$Suffix = '.edi',
    [string]$EndpointUrl = 'http://127.0.0.1:5000',
    [int]$MaxConcurrency = 4,
    [switch]$Once,
    [string]$MoveToPrefix = 'processed'
)

$ErrorActionPreference = 'Stop'
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir

$venvPython = Join-Path $scriptDir '.venv\Scripts\python.exe'
if (-not (Test-Path $venvPython)) {
    Write-Error "Virtual environment not found. Run .\setup.ps1 first."
}

$args = @(
    'PayerEdi.S3Service.py',
    '--bucket', $Bucket,
    '--prefix', $Prefix,
    '--suffix', $Suffix,
    '--endpoint-url', $EndpointUrl,
    '--max-concurrency', $MaxConcurrency
)

if ($MoveToPrefix) {
    $args += @('--move-to-prefix', $MoveToPrefix)
}

if ($Once.IsPresent) {
    $args += '--once'
}

& $venvPython $args