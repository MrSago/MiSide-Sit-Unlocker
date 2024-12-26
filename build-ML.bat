@echo off
setlocal EnableDelayedExpansion

dotnet build -c ML
if errorlevel 1 goto :error

set "SOURCE=.\bin\Release"
set "DEST=C:\Program Files (x86)\Steam\steamapps\common\MiSide\Mods"
set "FILE=SitUnlocker.MelonLoader.dll"

robocopy "%SOURCE%" "%DEST%" "%FILE%" /NFL /NDL /NJH /NJS
if errorlevel 8 goto :error

echo Build and copy completed successfully
exit /b 0

:error
echo Failed with error #%errorlevel%.
exit /b %errorlevel%
