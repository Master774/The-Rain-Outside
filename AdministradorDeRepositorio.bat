@echo off
SETLOCAL

REM Obtén la ruta del directorio donde se encuentra este archivo .bat
SET "SCRIPT_DIR=%~dp0"

REM Define la ruta del directorio del repositorio
SET "REPO_DIR=%SCRIPT_DIR%The-Rain-Outside"

REM Cambia al directorio del repositorio
cd "%REPO_DIR%"

REM Actualiza el repositorio
echo Actualizando el repositorio...
git pull origin main

REM Pregunta si el usuario quiere subir cambios
set /p pushChanges="¿Quieres subir tus cambios? (s/n): "
IF /I "%pushChanges%"=="s" (
    echo Subiendo cambios al repositorio...
    git add .
    set /p commitMessage="Introduce el mensaje del commit: "
    git commit -m "%commitMessage%"
    git push origin main
) ELSE (
    echo No se subirán cambios.
)

echo Proceso completado.
ENDLOCAL
pause
