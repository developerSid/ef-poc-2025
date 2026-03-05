param(
    [string]$Bucket,
    [string]$Prefix,
    [string]$Suffix,
    [string]$EndpointUrl,
    [int]$MaxConcurrency,
    [switch]$Once,
    [string]$MoveToPrefix
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
if (-not $PSBoundParameters.ContainsKey('Suffix')) {
    $Suffix = [string]$settings.S3.Suffix
}
if (-not $PSBoundParameters.ContainsKey('EndpointUrl')) {
    $EndpointUrl = [string]$settings.S3.EndpointUrl
}
if (-not $PSBoundParameters.ContainsKey('MaxConcurrency')) {
    $MaxConcurrency = [int]$settings.Service.MaxConcurrency
}
if (-not $PSBoundParameters.ContainsKey('MoveToPrefix')) {
    $MoveToPrefix = [string]$settings.S3.MoveToPrefix
}

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
