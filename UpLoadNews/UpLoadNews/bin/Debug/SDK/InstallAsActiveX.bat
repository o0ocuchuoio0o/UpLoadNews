@echo off

REM --------------------------------------------------------------------------------------
REM - this batch installs the SDK
REM - for both x86, x64 and x86 emulation modes                                          -
REM - on Windows Vista/7/8/2008/2012 this batch should be run in "As Administrator" mode -
REM --------------------------------------------------------------------------------------


REM change current directory (required for Vista and higher)
@setlocal enableextensions
@cd /d "%~dp0"

SET DLLFILE1=BytescoutImageToVideoFilter.dll
SET DLLFILE2=BytescoutImageToVideo.dll
SET DLLFILE3=BytescoutAudioLoopFilter.dll


SET ERROR=0

ECHO ------------ x86 Windows installation ------------------------

IF NOT EXIST "%systemroot%\SYSWOW64\" (

ECHO.
REM pure x86 mode 
ECHO. 

ECHO.
ECHO copying dll and tlb
ECHO.

ECHO copying System32\%DLLFILE1%
copy "x86\%DLLFILE1%" "%windir%\System32\%DLLFILE1%"

ECHO copying System32\%DLLFILE2%
copy "x86\%DLLFILE2%" "%windir%\System32\%DLLFILE2%"

ECHO copying System32\%DLLFILE3%
copy "x86\%DLLFILE3%" "%windir%\System32\%DLLFILE3%"


ECHO.
ECHO register dll files
ECHO.

ECHO registering System32\%DLLFILE1%
"%systemroot%\system32\regsvr32.exe" /s "%windir%\System32\%DLLFILE1%"
ECHO registering System32\%DLLFILE2%
"%systemroot%\system32\regsvr32.exe" /s "%windir%\System32\%DLLFILE2%"
ECHO registering System32\%DLLFILE3%
"%systemroot%\system32\regsvr32.exe" /s "%windir%\System32\%DLLFILE3%"

)


ECHO ------------ x64 Windows installation ------------------------

REM check if we are on Windows x64 
IF EXIST "%systemroot%\SYSWOW64\" (


ECHO.
ECHO x64 native mode and x86 emulation modes installations
ECHO.

REM --- x86 on x64
ECHO.
ECHO 1 - x86 emulation mode on x64
ECHO.

ECHO copying SYSWOW64\%DLLFILE1%
copy "x86\%DLLFILE1%" "%systemroot%\SYSWOW64\%DLLFILE1%"
ECHO copying SYSWOW64\%DLLFILE2%
copy "x86\%DLLFILE2%" "%systemroot%\SYSWOW64\%DLLFILE2%"
ECHO copying SYSWOW64\%DLLFILE3%
copy "x86\%DLLFILE3%" "%systemroot%\SYSWOW64\%DLLFILE3%"


ECHO.
ECHO register dll files
ECHO.

ECHO registering SYSWOW64\%DLLFILE1%
"%systemroot%\SYSWOW64\regsvr32.exe" /s "%systemroot%\SYSWOW64\%DLLFILE1%"
ECHO registering SYSWOW64\%DLLFILE2%
"%systemroot%\SYSWOW64\regsvr32.exe" /s "%systemroot%\SYSWOW64\%DLLFILE2%"
ECHO registering SYSWOW64\%DLLFILE3%
"%systemroot%\SYSWOW64\regsvr32.exe" /s "%systemroot%\SYSWOW64\%DLLFILE3%"

REM --- x64 mode

ECHO.
ECHO 2 - x64 native mode on x64
ECHO.


REM copy and register files if running in x86 mode (the batch is running in x86 mode)
REM and we use "sysnative" to access x64 system32 folder 

IF EXIST "%systemroot%\sysnative\cmd.exe" (

REM we are calling cmd.exe and regsvr32.exe from "sysnative" folder (special "alias" available when running x86 batch on x64)
REM although we call from "sysnative" folder but we should pass "system32" in the command line parameters to these utilities

ECHO copying sysnative\%DLLFILE1%"
"%systemroot%\sysnative\cmd.exe" /c copy "x64\%DLLFILE1%" "%systemroot%\system32\%DLLFILE1%"
ECHO copying sysnative\%DLLFILE2%"
"%systemroot%\sysnative\cmd.exe" /c copy "x64\%DLLFILE2%" "%systemroot%\system32\%DLLFILE2%"
ECHO copying sysnative\%DLLFILE3%"
"%systemroot%\sysnative\cmd.exe" /c copy "x64\%DLLFILE3%" "%systemroot%\system32\%DLLFILE3%"

REM register dll files

ECHO registering sysnative\%DLLFILE1%"
"%systemroot%\sysnative\regsvr32.exe" /s "%systemroot%\system32\%DLLFILE1%"
ECHO registering sysnative\%DLLFILE2%"
"%systemroot%\sysnative\regsvr32.exe" /s "%systemroot%\system32\%DLLFILE2%"
ECHO registering sysnative\%DLLFILE3%"
"%systemroot%\sysnative\regsvr32.exe" /s "%systemroot%\system32\%DLLFILE3%"

) ELSE (

REM copy and register files if running in x64 mode (the batch is running in x64 mode)
REM and we use "system32" to access x64 system32 folder (sysnative alias works when the batch runs in x86 mode only)

ECHO copying system32\%DLLFILE1%"
"%systemroot%\system32\cmd.exe" /c copy "x64\%DLLFILE1%" "%systemroot%\system32\%DLLFILE1%"
ECHO copying system32\%DLLFILE2%"
"%systemroot%\system32\cmd.exe" /c copy "x64\%DLLFILE2%" "%systemroot%\system32\%DLLFILE2%"
ECHO copying system32\%DLLFILE3%"
"%systemroot%\system32\cmd.exe" /c copy "x64\%DLLFILE3%" "%systemroot%\system32\%DLLFILE3%"

REM register dll files

ECHO registering system32\%DLLFILE1%"
"%systemroot%\system32\regsvr32.exe" /s "%systemroot%\system32\%DLLFILE1%"
ECHO registering system32\%DLLFILE2%"
"%systemroot%\system32\regsvr32.exe" /s "%systemroot%\system32\%DLLFILE2%"
ECHO registering system32\%DLLFILE3%"
"%systemroot%\system32\regsvr32.exe" /s "%systemroot%\system32\%DLLFILE3%"

)




)


if %ERROR% EQU 0 goto :EOF

:SHOWERROR

echo .
echo Error installing the SDK as ActiveX object: %ERROR%
echo .

REM Exit %ERROR%

:EOF