# Skrypt PowerShell do budowania i testowania pluginu VSIX

# 1. Zdefiniuj ścieżki
$repoUrl = "https://github.com/toci888/intotech_common.git"
$localRepoPath = "$HOME\intotech_common"
$vsixProjectPath = "$localRepoPath\PlotTwist\Toci.PlotTwist"

# 2. Klonowanie repozytorium, jeśli jeszcze nie istnieje
if (-not (Test-Path -Path $localRepoPath)) {
    Write-Host "Cloning repository..."
    git clone $repoUrl $localRepoPath
} else {
    Write-Host "Repository already exists. Pulling latest changes..."
    cd $localRepoPath
    git pull
}

# 3. Przejście do folderu projektu
if (-not (Test-Path -Path $vsixProjectPath)) {
    Write-Error "VSIX project path not found: $vsixProjectPath"
    exit 1
}

cd $vsixProjectPath

# 4. Przygotowanie środowiska
Write-Host "Restoring NuGet packages..."
dotnet restore

# 5. Budowanie projektu VSIX
Write-Host "Building VSIX plugin..."
dotnet build --configuration Release 
# 6. Uruchamianie testów jednostkowych
Write-Host "Running unit tests..."
dotnet test

# 7. Publikowanie VSIX (jeśli testy przejdą)
$vsixOutputPath = "$vsixProjectPath\bin\Release"
if (Test-Path -Path "$vsixOutputPath") {
    Write-Host "VSIX built successfully. Output: $vsixOutputPath"
    Write-Host "To install, open Visual Studio and load the .vsix file."
} else {
    Write-Error "Build failed or output not found."
    exit 1
}
