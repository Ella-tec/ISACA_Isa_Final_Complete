@echo off
cd /d "%~dp0"
echo === Isa Chapter Support Assistant ===
echo Starting on this computer (localhost + network)...
set ASPNETCORE_URLS=http://0.0.0.0:5067
set ASPNETCORE_ENVIRONMENT=Development
dotnet restore
dotnet build
if errorlevel 1 (
  echo BUILD FAILED. Do not run from an old duplicated folder.
  pause
  exit /b 1
)
echo.
echo Open on THIS computer:  http://localhost:5067
echo Open on PHONE / other PC on same Wi-Fi:  http://YOUR-PC-IP:5067
echo Find your IP with:  ipconfig
echo.
dotnet run --urls http://0.0.0.0:5067
pause
