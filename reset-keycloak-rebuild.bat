@echo off
cd /d "%~dp0"

echo ============================================
echo  TRU Keycloak Realm Management
echo ============================================
echo.
echo Rebuilds the TRU realm configuration,
echo then resets Keycloak and re-imports it.
echo.

powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0reset-keycloak.ps1" -Rebuild

echo.
echo TRU Keycloak setup complete.
echo.

pause