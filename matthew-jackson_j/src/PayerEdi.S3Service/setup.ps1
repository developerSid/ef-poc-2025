$ErrorActionPreference = 'Stop'

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir

$tempDir = Join-Path $scriptDir '.tmp'
New-Item -ItemType Directory -Path $tempDir -Force | Out-Null
$env:TEMP = $tempDir
$env:TMP = $tempDir

$pythonExe = $null
$pythonArgs = @()
if (Get-Command py -ErrorAction SilentlyContinue) {
    $pythonExe = 'py'
    $pythonArgs = @('-3')
} elseif (Get-Command python -ErrorAction SilentlyContinue) {
    $pythonExe = 'python'
} else {
    Write-Error "Python 3 is not installed. Install it with: winget install -e --id Python.Python.3.12"
}

if (-not (Test-Path '.venv')) {
    Write-Host 'Creating virtual environment (.venv)...'
    & $pythonExe @pythonArgs -m venv .venv
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to create virtual environment."
    }
}

$venvPython = Join-Path $scriptDir '.venv\Scripts\python.exe'
if (-not (Test-Path $venvPython)) {
    Write-Error "Virtual environment is missing python executable: $venvPython"
}

$previousErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = 'Continue'
& $venvPython -m pip --version > $null 2>&1
$ErrorActionPreference = $previousErrorActionPreference
if ($LASTEXITCODE -ne 0) {
    Write-Host 'Bootstrapping pip inside virtual environment...'
    & $venvPython -m ensurepip --upgrade
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to bootstrap pip inside virtual environment."
    }
}

Write-Host 'Installing Python dependencies...'
& $venvPython -m pip install --upgrade pip
if ($LASTEXITCODE -ne 0) {
    throw "Failed to upgrade pip."
}

& $venvPython -m pip install -r requirements.txt
if ($LASTEXITCODE -ne 0) {
    throw "Failed to install requirements."
}

Write-Host 'Python setup complete.'