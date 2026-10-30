$outerrLog = Join-Path $PSScriptRoot 'tru-run.err.log'
$outLog = Join-Path $PSScriptRoot 'tru-run.log'
$pidFile = Join-Path $PSScriptRoot 'tru.pid'
$csproj = Join-Path $PSScriptRoot 'TRU.csproj'

if (-not (Test-Path $csproj)) {
    Write-Error "Cannot find $csproj."
    exit 1
}

# Launch TRU in the background using the same settings as a normal dotnet run.
# This ensures the application behaves exactly the same as the development workflow,
# including configuration, static files, and environment settings.

try {
    $p = Start-Process -FilePath 'dotnet' `
        -ArgumentList @(
            'run',
            '--project', "`"$csproj`"",
            '-c', 'Release',
            '--urls', 'http://localhost:5067'
        ) `
        -WorkingDirectory $PSScriptRoot `
        -WindowStyle Hidden `
        -PassThru `
        -RedirectStandardOutput $outLog `
        -RedirectStandardError $errLog

    $p.Id | Out-File -Encoding ascii -NoNewline $pidFile

    Write-Host "Started TRU, PID $($p.Id)"
}
catch {
    Write-Error "Failed to start TRU: $_"
    exit 1
}