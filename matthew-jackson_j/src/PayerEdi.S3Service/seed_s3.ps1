param(
    [string]$Bucket,
    [string]$Prefix,
    [string]$SourceDir,
    [string]$Glob,
    [string]$EndpointUrl,
    [string]$Region
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
if (-not $PSBoundParameters.ContainsKey('EndpointUrl')) {
    $EndpointUrl = [string]$settings.S3.EndpointUrl
}
if (-not $PSBoundParameters.ContainsKey('Region')) {
    $Region = [string]$settings.S3.Region
}

$venvPython = Join-Path $scriptDir '.venv\Scripts\python.exe'
if (-not (Test-Path $venvPython)) {
    Write-Error "Virtual environment not found. Run .\setup.ps1 first."
}

& $venvPython seed_bucket.py --endpoint-url $EndpointUrl --region $Region --bucket $Bucket --source-dir $SourceDir --glob $Glob --prefix $Prefix
