@echo off
cd /d "%~dp0"
echo Publishing self-contained Windows build (no .NET install needed on target PC)...
dotnet publish -c Release -r win-x64 --self-contained true -o ".\publish\IsaWindows" /p:PublishSingleFile=false
if errorlevel 1 (
  echo Publish failed.
  pause
  exit /b 1
)
echo.
echo Done. Folder: publish\IsaWindows
echo Copy that folder to the other computer and run IsaChatApp.exe
echo Or run:  IsaChatApp.exe --urls http://0.0.0.0:8080
pause
