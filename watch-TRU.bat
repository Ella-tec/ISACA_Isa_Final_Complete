@echo off
setlocal

cd /d "%~dp0"

echo ============================================
echo  TRU -- Live Problem Monitor
echo  Displays warnings, errors, and crashes
echo  from the running application in real time.
echo.
echo  Leave this window open while TRU is running.
echo  Press Ctrl+C to close.
echo.
echo  Run:
echo      watch-tru.bat ALL
echo.
echo  to display all log entries.
echo ============================================

powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0watch-tru.ps1" %1

pause