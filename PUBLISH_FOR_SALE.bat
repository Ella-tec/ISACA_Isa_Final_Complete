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
echo Copy that folder to the @echo off
cd /d "%~dp0"

echo ============================================
echo Building TRU Windows Release
echo ============================================
echo.
echo Publishing self-contained Windows build
echo (No .NET installation required on target PC)
echo.

dotnet publish ^
-c Release ^
-r win-x64 ^
--self-contained true ^
-o ".\publish\TRUWindows" ^
/p:PublishSingleFile=false

if errorlevel 1 (
    echo.
    echo TRU publish failed.
    pause
    exit /b 1
)

echo.
echo ============================================
echo TRU Build Complete
echo ============================================
echo.
echo Output Folder:
echo publish\TRUWindows
echo.
echo Copy the TRUWindows folder to another PC
echo and run:
echo.
echo TRU.exe
echo.
echo Or start TRU on your network:
echo.
echo TRU.exe --urls http://0.0.0.0:8080
echo.
echo Then open from another device:
echo.
echo http://YOUR-PC-IP:8080
echo.
echo Example:
echo http://192.168.1.174:8080
echo.
pauseother computer and run IsaChatApp.exe
echo Or run:  IsaChatApp.exe --urls http://0.0.0.0:8080
pause
