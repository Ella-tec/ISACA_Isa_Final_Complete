# TRU-launcher.ps1 -- a small window with a button for each script, and a check of
# everything needed to run the project.
# Open it with TRU-launcher.bat (double-click). It only starts the existing .bat / .ps1 files
# in this folder, each in its own console window, so you can see the output.

Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing
[System.Windows.Forms.Application]::EnableVisualStyles()

$script:root = $PSScriptRoot
$script:appUrl = 'http://localhost:5067'

# ---- helpers -------------------------------------------------------------

function Show-Problem($text) {
    [void][System.Windows.Forms.MessageBox]::Show($text, 'TRU launcher', 'OK', 'Warning')
}

function Run-Bat($name) {
    $path = Join-Path $script:root $name
    if (-not (Test-Path $path)) { Show-Problem "Cannot find $name in $script:root"; return }
    Start-Process -FilePath 'cmd.exe' -ArgumentList @('/k', $name) -WorkingDirectory $script:root
}

function Run-Ps($commandText) {
    $arg = '"' + $commandText + '"'
    Start-Process -FilePath 'powershell.exe' -WorkingDirectory $script:root `
        -ArgumentList @('-NoExit', '-NoProfile', '-ExecutionPolicy', 'Bypass', '-Command', $arg)
}

function Run-Script($name, $extra) {
    $path = Join-Path $script:root $name
    if (-not (Test-Path $path)) { Show-Problem "Cannot find $name in $script:root"; return }
    Run-Ps ("& '.\" + $name + "' " + $extra)
}

function Run-Cmd($commandText) {
    Start-Process -FilePath 'cmd.exe' -ArgumentList @('/k', $commandText) -WorkingDirectory $script:root
}

function Clean-Text($text) {
    return (($text -replace '"', '') -replace "'", '').Trim()
}

function Test-Port($port) {
    try {
        $client = New-Object System.Net.Sockets.TcpClient
        $result = $client.BeginConnect('localhost', $port, $null, $null)
        $ok = $result.AsyncWaitHandle.WaitOne(400)
        if ($ok) { try { $client.EndConnect($result) } catch { $ok = $false } }
        $client.Close()
        return $ok
    } catch { return $false }
}

# ---- window layout: two columns -----------------------------------------

$form = New-Object System.Windows.Forms.Form
$form.Text = 'TRU launcher'
$form.StartPosition = 'CenterScreen'
$form.ClientSize = New-Object System.Drawing.Size(1290, 640)
$form.MinimumSize = New-Object System.Drawing.Size(700, 400)
$form.Font = New-Object System.Drawing.Font('Segoe UI', 9)

# Prefer TRU icon, fall back to old isa-icon.ico
$iconPath = Join-Path $script:root 'tru-icon.ico'
if (-not (Test-Path $iconPath)) { $iconPath = Join-Path $script:root 'isa-icon.ico' }
if (Test-Path $iconPath) { try { $form.Icon = New-Object System.Drawing.Icon($iconPath) } catch { } }

$split = New-Object System.Windows.Forms.TableLayoutPanel
$split.Dock = 'Fill'
$split.ColumnCount = 2
$split.RowCount = 1
[void]$split.ColumnStyles.Add((New-Object System.Windows.Forms.ColumnStyle('Percent', 50)))
[void]$split.ColumnStyles.Add((New-Object System.Windows.Forms.ColumnStyle('Percent', 50)))
[void]$split.RowStyles.Add((New-Object System.Windows.Forms.RowStyle('Percent', 100)))
$form.Controls.Add($split)

function New-Column() {
    $c = New-Object System.Windows.Forms.FlowLayoutPanel
    $c.Dock = 'Fill'
    $c.FlowDirection = 'TopDown'
    $c.WrapContents = $false
    $c.AutoScroll = $true
    $c.Padding = New-Object System.Windows.Forms.Padding(8)
    return $c
}
$left = New-Column
$right = New-Column
$split.Controls.Add($left, 0, 0)
$split.Controls.Add($right, 1, 0)

function New-Group($column, $title, $rows) {
    $g = New-Object System.Windows.Forms.GroupBox
    $g.Text = $title
    $g.Width = 606
    $g.Height = 28 + ($rows * 38) + 8
    $g.Margin = New-Object System.Windows.Forms.Padding(3, 3, 3, 8)
    $p = New-Object System.Windows.Forms.FlowLayoutPanel
    $p.Dock = 'Fill'
    $p.WrapContents = $true
    $p.FlowDirection = 'LeftToRight'
    $g.Controls.Add($p)
    $column.Controls.Add($g)
    return $p
}

$toolTip = New-Object System.Windows.Forms.ToolTip
$toolTip.AutoPopDelay = 8000

function Add-Btn($panel, $text, $tip, [scriptblock]$onClick) {
    $b = New-Object System.Windows.Forms.Button
    $b.Text = $text
    $b.Width = 188
    $b.Height = 32
    $b.Margin = New-Object System.Windows.Forms.Padding(3)
    $b.Add_Click($onClick)
    $toolTip.SetToolTip($b, $tip)
    $panel.Controls.Add($b)
}

# ---- LEFT: app, keycloak, tests, open -----------------------------------

$pApp = New-Group $left 'App' 2
Add-Btn $pApp 'Start TRU' 'start-isa.bat: checks prerequisites, starts the app in the background.' { Run-Bat 'start-isa.bat' }
Add-Btn $pApp 'Start TRU (debug window)' 'start-isa-debug.bat: runs the app in a visible window, errors show there.' { Run-Bat 'start-isa-debug.bat' }
Add-Btn $pApp 'Stop TRU' 'stop-isa.bat: stops the background app and frees port 5067.' { Run-Bat 'stop-isa.bat' }
Add-Btn $pApp 'Stop TRU (debug)' 'stop-isa-debug.bat' { Run-Bat 'stop-isa-debug.bat' }
Add-Btn $pApp 'Watch problems' 'watch-isa.bat: shows warnings and errors from the running app.' { Run-Bat 'watch-isa.bat' }
Add-Btn $pApp 'Watch ALL log lines' 'watch-isa.bat ALL: shows every log line.' { Run-Cmd 'watch-isa.bat ALL' }

$pKc = New-Group $left 'Keycloak (needs Docker Desktop running)' 2
Add-Btn $pKc 'Start Keycloak' 'docker compose up -d' { Run-Cmd 'docker compose up -d' }
Add-Btn $pKc 'Stop Keycloak' 'docker compose down (keeps its data)' { Run-Cmd 'docker compose down' }
Add-Btn $pKc 'Reset Keycloak' 'reset-keycloak.bat: wipes Keycloak data and re-imports the realm file as it is.' { Run-Bat 'reset-keycloak.bat' }
Add-Btn $pKc 'Reset + rebuild realm' 'reset-keycloak-rebuild.bat: rebuilds the realm file with Python first, then resets.' { Run-Bat 'reset-keycloak-rebuild.bat' }
Add-Btn $pKc 'Keycloak logs' 'docker compose logs keycloak (last 100 lines, then follows)' { Run-Cmd 'docker compose logs --tail 100 -f keycloak' }

$pTest = New-Group $left 'Tests (the app must be running)' 1
Add-Btn $pTest 'Run test paths' 'test-paths.ps1: sign-in checks and the test paths (five questions, Spanish, English), signed in as d.whitfield.' { Run-Script 'test-paths.ps1' '' }
Add-Btn $pTest 'Run test paths (no token)' 'test-paths.ps1 -NoToken: sends no token, only works while DevBypass is on.' { Run-Script 'test-paths.ps1' '-NoToken' }
Add-Btn $pTest 'Test Salesforce' 'test-salesforce.ps1: creates one test Case using dev-keys.json.' { Run-Script 'test-salesforce.ps1' '' }

$pOpen = New-Group $left 'Open' 2
Add-Btn $pOpen 'Open TRU in browser' 'http://localhost:5067' { Start-Process $script:appUrl }
Add-Btn $pOpen 'Open Dev Dashboard' '/dev-dashboard (Models, RAG, access & ticketing has the Salesforce settings)' { Start-Process 