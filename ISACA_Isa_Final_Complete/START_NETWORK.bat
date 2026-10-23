@echo off
cd /d "%~dp0"
echo === Isa — Network mode (other devices) ===
set ASPNETCORE_URLS=http://0.0.0.0:5067
set ASPNETCORE_ENVIRONMENT=Development
echo.
echo 1. Allow port 5067 in Windows Firewall if asked.
echo 2. On this PC open:  http://localhost:5067
echo 3. On phone/tablet same Wi-Fi:  http://THIS-PC-IP:5067
echo    (Run: ipconfig   and use IPv4 Address)
echo.
dotnet run --no-launch-profile --urls http://0.0.0.0:5067
pause
