# Copy all NuGet packages to local NuGet folder
$destinationFolder = "C:\Git\MartiXDev\NuGetPrivate"
$sourceFolder = $PSScriptRoot

Write-Host "Searching for .nupkg files in $sourceFolder..." -ForegroundColor Cyan

# Create destination folder if it doesn't exist
if (-not (Test-Path $destinationFolder)) {
    New-Item -ItemType Directory -Path $destinationFolder -Force | Out-Null
    Write-Host "Created destination folder: $destinationFolder" -ForegroundColor Green
}

# Find all .nupkg files recursively
$nupkgFiles = Get-ChildItem -Path $sourceFolder -Filter "*.nupkg" -Recurse -File

if ($nupkgFiles.Count -eq 0) {
    Write-Host "No .nupkg files found." -ForegroundColor Yellow
    exit 0
}

Write-Host "Found $($nupkgFiles.Count) package(s)" -ForegroundColor Green
Write-Host ""

# Copy each file
foreach ($file in $nupkgFiles) {
    $relativePath = $file.FullName.Substring($sourceFolder.Length + 1)
    Write-Host "Copying: $relativePath" -ForegroundColor White
    Copy-Item -Path $file.FullName -Destination $destinationFolder -Force
}

Write-Host ""
Write-Host "Successfully copied $($nupkgFiles.Count) package(s) to $destinationFolder" -ForegroundColor Green
