$ErrorActionPreference = "Continue"

$base = "C:\Users\WORK\Documents\GitHub\dark-soul-collector\Assets\Assets\_Project"
$ninja = "$base\Art\Sprites\Player\Ninja Adventure - Asset Pack"
$art = "$base\Art"

Write-Host "=== Starting reorganization ==="

# --- STEP 3: Move Weapons ---
Write-Host "STEP 3: Moving Weapons..."
$weapSrc = "$ninja\_TempWeapons2"
$weapDst = "$art\Sprites\Weapons"
if (Test-Path $weapSrc) {
    if (-not (Test-Path $weapDst)) { New-Item $weapDst -ItemType Directory -Force | Out-Null }
    $items = Get-ChildItem -LiteralPath $weapSrc
    foreach ($item in $items) {
        Move-Item -LiteralPath $item.FullName -Destination (Join-Path $weapDst $item.Name) -Force
    }
    Remove-Item -LiteralPath $weapSrc -Recurse -Force -ErrorAction SilentlyContinue
    Remove-Item -LiteralPath "$weapSrc.meta" -Force -ErrorAction SilentlyContinue
    Write-Host "  OK: $((Get-ChildItem -LiteralPath $weapDst -Directory).Count) weapon folders"
} else { Write-Host "  SKIP: already moved" }

# --- STEP 5: Move Backgrounds -> Environment ---
Write-Host "STEP 5: Moving Backgrounds..."
$bgSrc = "$ninja\Backgrounds"
$envDst = "$art\Sprites\Environment"
if (Test-Path $bgSrc) {
    if (-not (Test-Path $envDst)) { New-Item $envDst -ItemType Directory -Force | Out-Null }
    
    # Animated
    if (Test-Path "$bgSrc\Animated") {
        Move-Item -LiteralPath "$bgSrc\Animated" -Destination "$envDst\Animated" -Force
        if (Test-Path "$bgSrc\Animated.meta") { Move-Item -LiteralPath "$bgSrc\Animated.meta" -Destination "$envDst\Animated.meta" -Force }
        Write-Host "  OK: Animated"
    }
    # Vehicles
    if (Test-Path "$bgSrc\Vehicles") {
        Move-Item -LiteralPath "$bgSrc\Vehicles" -Destination "$envDst\Vehicles" -Force
        if (Test-Path "$bgSrc\Vehicles.meta") { Move-Item -LiteralPath "$bgSrc\Vehicles.meta" -Destination "$envDst\Vehicles.meta" -Force }
        Write-Host "  OK: Vehicles"
    }
    # Tilesets (already moved in previous run to Art/Tilesets, check)
    if (Test-Path "$bgSrc\Tilesets") {
        $tileDst = "$art\Tilesets"
        if (-not (Test-Path $tileDst)) { New-Item $tileDst -ItemType Directory -Force | Out-Null }
        Move-Item -LiteralPath "$bgSrc\Tilesets" -Destination "$tileDst\NinjaAdventure" -Force
        if (Test-Path "$bgSrc\Tilesets.meta") { Move-Item -LiteralPath "$bgSrc\Tilesets.meta" -Destination "$tileDst\NinjaAdventure.meta" -Force }
        Write-Host "  OK: Tilesets"
    }
    
    # Clean up empty Backgrounds
    $remaining = Get-ChildItem -LiteralPath $bgSrc -ErrorAction SilentlyContinue
    if ($null -eq $remaining -or $remaining.Count -eq 0) {
        Remove-Item -LiteralPath $bgSrc -Recurse -Force -ErrorAction SilentlyContinue
        Remove-Item -LiteralPath "$bgSrc.meta" -Force -ErrorAction SilentlyContinue
        Write-Host "  Cleaned up empty Backgrounds"
    }
} else { Write-Host "  SKIP: already moved" }

# --- STEP 6: Move Ui -> Art/UI ---
Write-Host "STEP 6: Moving UI..."
$uiSrc = "$ninja\Ui"
$uiDst = "$art\UI"
if (Test-Path $uiSrc) {
    $uiItems = Get-ChildItem -LiteralPath $uiSrc
    foreach ($item in $uiItems) {
        if ($item.Extension -eq ".meta") { continue }
        $dest = Join-Path $uiDst $item.Name
        if (-not (Test-Path $dest)) {
            Move-Item -LiteralPath $item.FullName -Destination $dest -Force
            $meta = "$($item.FullName).meta"
            if (Test-Path $meta) { Move-Item -LiteralPath $meta -Destination "$dest.meta" -Force }
            Write-Host "  OK: $($item.Name)"
        } else {
            Write-Host "  EXISTS: $($item.Name) - merging contents"
            if ($item.PSIsContainer) {
                Get-ChildItem -LiteralPath $item.FullName | ForEach-Object {
                    Move-Item -LiteralPath $_.FullName -Destination (Join-Path $dest $_.Name) -Force
                }
                Remove-Item -LiteralPath $item.FullName -Recurse -Force
                $meta = "$($item.FullName).meta"
                if (Test-Path $meta) { Remove-Item -LiteralPath $meta -Force }
            }
        }
    }
    # Clean up
    $remaining = Get-ChildItem -LiteralPath $uiSrc -ErrorAction SilentlyContinue
    if ($null -eq $remaining -or $remaining.Count -eq 0) {
        Remove-Item -LiteralPath $uiSrc -Recurse -Force -ErrorAction SilentlyContinue
        Remove-Item -LiteralPath "$uiSrc.meta" -Force -ErrorAction SilentlyContinue
    }
}

# --- STEP 7: Move Audio ---
Write-Host "STEP 7: Moving Audio..."
$audioSrc = "$ninja\Audio"
if (Test-Path $audioSrc) {
    # Jingles -> Audio/SFX/Jingles
    if (Test-Path "$audioSrc\Jingles") {
        $jDst = "$base\Audio\SFX\Jingles"
        if (-not (Test-Path $jDst)) { New-Item $jDst -ItemType Directory -Force | Out-Null }
        Move-Item -LiteralPath "$audioSrc\Jingles" -Destination $jDst -Force -ErrorAction SilentlyContinue
        Get-ChildItem -LiteralPath "$audioSrc\Jingles" -ErrorAction SilentlyContinue | ForEach-Object {
            Move-Item -LiteralPath $_.FullName -Destination (Join-Path $jDst $_.Name) -Force
        }
        Write-Host "  OK: Jingles"
    }
    # Musics -> Audio/Music/NinjaAdventure
    if (Test-Path "$audioSrc\Musics") {
        $mDst = "$base\Audio\Music\NinjaAdventure"
        New-Item $mDst -ItemType Directory -Force | Out-Null
        Get-ChildItem -LiteralPath "$audioSrc\Musics" | ForEach-Object {
            Move-Item -LiteralPath $_.FullName -Destination (Join-Path $mDst $_.Name) -Force
        }
        Remove-Item -LiteralPath "$audioSrc\Musics" -Recurse -Force -ErrorAction SilentlyContinue
        Remove-Item -LiteralPath "$audioSrc\Musics.meta" -Force -ErrorAction SilentlyContinue
        Write-Host "  OK: Musics"
    }
    # Sounds -> Audio/SFX/NinjaAdventure
    if (Test-Path "$audioSrc\Sounds") {
        $sDst = "$base\Audio\SFX\NinjaAdventure"
        New-Item $sDst -ItemType Directory -Force | Out-Null
        Get-ChildItem -LiteralPath "$audioSrc\Sounds" | ForEach-Object {
            Move-Item -LiteralPath $_.FullName -Destination (Join-Path $sDst $_.Name) -Force
        }
        Remove-Item -LiteralPath "$audioSrc\Sounds" -Recurse -Force -ErrorAction SilentlyContinue
        Remove-Item -LiteralPath "$audioSrc\Sounds.meta" -Force -ErrorAction SilentlyContinue
        Write-Host "  OK: Sounds"
    }
    # Clean up
    $remaining = Get-ChildItem -LiteralPath $audioSrc -ErrorAction SilentlyContinue
    if ($null -eq $remaining -or $remaining.Count -eq 0) {
        Remove-Item -LiteralPath $audioSrc -Recurse -Force -ErrorAction SilentlyContinue
        Remove-Item -LiteralPath "$audioSrc.meta" -Force -ErrorAction SilentlyContinue
    }
}

# --- STEP 8: Move Monster -> Enemies ---
Write-Host "STEP 8: Moving Monsters to Enemies..."
$monSrc = "$art\Sprites\Other\Monster"
$monDst = "$art\Sprites\Enemies\Monster"
if (Test-Path $monSrc) {
    Move-Item -LiteralPath $monSrc -Destination $monDst -Force
    if (Test-Path "$monSrc.meta") { Move-Item -LiteralPath "$monSrc.meta" -Destination "$monDst.meta" -Force }
    Write-Host "  OK: Monster moved to Enemies"
}

# --- STEP 9: Remove duplicate folders ---
Write-Host "STEP 9: Removing duplicates..."
$dupes = @(
    "$art\Sprites\Enemies\Boss 1",
    "$art\Sprites\Other\Animal 1"
)
foreach ($d in $dupes) {
    if (Test-Path $d) {
        Remove-Item -LiteralPath $d -Recurse -Force
        Remove-Item -LiteralPath "$d.meta" -Force -ErrorAction SilentlyContinue
        Write-Host "  DELETED: $d"
    }
}

# --- STEP 10: Clean up preview files ---
Write-Host "STEP 10: Cleaning up..."
$cleanFiles = @("preview-part-1.png", "preview-part-1.png.meta", "preview-part-2.png", "preview-part-2.png.meta", "MusicCover.png", "MusicCover.png.meta", "Palette.png", "Palette.png.meta")
foreach ($f in $cleanFiles) {
    $p = Join-Path $ninja $f
    if (Test-Path $p) {
        Remove-Item -LiteralPath $p -Force
        Write-Host "  Deleted: $f"
    }
}

Write-Host "`n=== VERIFICATION ==="
Write-Host "Sprites/Weapons: $(if(Test-Path '$art\Sprites\Weapons'){(Get-ChildItem -LiteralPath '$art\Sprites\Weapons' -Directory).Count} else {'NOT FOUND'})"
Write-Host "Sprites/VFX: $(if(Test-Path '$art\Sprites\VFX'){(Get-ChildItem -LiteralPath '$art\Sprites\VFX' -Directory).Count} else {'NOT FOUND'})"
Write-Host "Sprites/Items: $(if(Test-Path '$art\Sprites\Items'){(Get-ChildItem -LiteralPath '$art\Sprites\Items' -Directory).Count} else {'NOT FOUND'})"
Write-Host "Sprites/Environment: $(if(Test-Path '$art\Sprites\Environment'){(Get-ChildItem -LiteralPath '$art\Sprites\Environment' -Directory).Count} else {'NOT FOUND'})"
Write-Host "Tilesets: $(Test-Path '$art\Tilesets')"
Write-Host "Enemies/Monster: $(Test-Path '$art\Sprites\Enemies\Monster')"
Write-Host "Enemies/Boss 1: $(Test-Path '$art\Sprites\Enemies\Boss 1') (should be False)"
Write-Host "Other/Animal 1: $(Test-Path '$art\Sprites\Other\Animal 1') (should be False)"

Write-Host "`n=== Remaining in Ninja Pack ==="
Get-ChildItem -LiteralPath $ninja -ErrorAction SilentlyContinue | Where-Object { $_.Extension -ne ".meta" } | Select Name

Write-Host "`n=== DONE ==="
