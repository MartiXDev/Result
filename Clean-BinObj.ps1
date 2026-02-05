# Remove all bin and obj folders from the solution
$sourceFolder = $PSScriptRoot

Write-Host "Searching for bin and obj folders in $sourceFolder..." -ForegroundColor Cyan
Write-Host ""

# Find all bin and obj directories
$foldersToDelete = Get-ChildItem -Path $sourceFolder -Include "bin", "obj" -Recurse -Directory -Force

if ($foldersToDelete.Count -eq 0) {
  Write-Host "No bin or obj folders found." -ForegroundColor Yellow
  exit 0
}

Write-Host "Found $($foldersToDelete.Count) folder(s) to delete" -ForegroundColor Yellow
Write-Host ""

# Delete each folder
$deletedCount = 0
foreach ($folder in $foldersToDelete) {
  try {
    $relativePath = $folder.FullName.Substring($sourceFolder.Length + 1)
    Write-Host "Deleting: $relativePath" -ForegroundColor White
    Remove-Item -Path $folder.FullName -Recurse -Force -ErrorAction Stop
    $deletedCount++
  }
  catch {
    Write-Host "  Failed to delete: $($_.Exception.Message)" -ForegroundColor Red
  }
}

Write-Host ""
Write-Host "Successfully deleted $deletedCount folder(s)" -ForegroundColor Green
