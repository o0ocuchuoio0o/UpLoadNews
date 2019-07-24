@echo off

REM --------------------------------------------------------------------------------------
REM - this batch DEinstalls SDK          -
REM - for both x86, x64 and x86 emulation modes                                          -
REM - on Windows Vista/7/8/2008/2012 this batch should be run in "As Administrator" mode -
REM --------------------------------------------------------------------------------------

SET DLLFILE1=BytescoutImageToVideoFilter.dll
SET DLLFILE2=BytescoutImageToVideo.dll
SET DLLFILE3=BytescoutAudioLoopFilter.dll

SET ERROR=0


ECHO ------------ x86 Windows deinstallation ------------------------


IF NOT EXIST "%systemroot%\SYSWOW64\" (

REM 1st dll
IF NOT "%DLLFILE1%"=="" IF EXIST "%systemroot%\system32\%DLLFILE1%" (


REM unregistering the dll as ActiveX library
"%systemroot%\system32\regsvr32.exe" /s /u "%systemroot%\System32\%DLLFILE1%"

REM removing %DLLFILE1%
DEL "%systemroot%\System32\%DLLFILE1%"


) ELSE (
	ECHO.
	ECHO system32\%DLLFILE1% not found so nothing to deinstall
	ECHO.	
)

REM 2nd dll
IF NOT "%DLLFILE2%"=="" IF EXIST "%systemroot%\system32\%DLLFILE2%" (


REM unregistering the dll as ActiveX library
"%systemroot%\system32\regsvr32.exe" /s /u "%systemroot%\System32\%DLLFILE2%"

REM removing %DLLFILE2%
DEL "%systemroot%\System32\%DLLFILE2%"


) ELSE (
	ECHO.
	ECHO system32\%DLLFILE2% not found so nothing to deinstall
	ECHO.	
)


REM 3rd dll
IF NOT "%DLLFILE3%"=="" IF EXIST "%systemroot%\system32\%DLLFILE3%" (


REM unregistering the dll as ActiveX library
"%systemroot%\system32\regsvr32.exe" /s /u "%systemroot%\System32\%DLLFILE3%"

REM removing %DLLFILE3%
DEL "%systemroot%\System32\%DLLFILE3%"


) ELSE (
	ECHO.
	ECHO system32\%DLLFILE3% not found so nothing to deinstall
	ECHO.	
)


)


ECHO ------------ x64 Windows deinstallation ------------------------


IF NOT "%DLLFILE1%"=="" IF EXIST "%systemroot%\SYSWOW64\%DLLFILE1%" (

REM ------------------------------------------
ECHO uninstall x86 emulation mode files

REM 1st dll
IF NOT "%DLLFILE1%"=="" IF EXIST "%systemroot%\SYSWOW64\%DLLFILE1%" (

ECHO unregistering SYSWOW64\%DLLFILE1%
"%systemroot%\SYSWOW64\regsvr32.exe" /s /u "%systemroot%\SYSWOW64\%DLLFILE1%"

ECHO removing SYSWOW64\%DLLFILE1%
DEL "%systemroot%\SYSWOW64\%DLLFILE1%"


) ELSE (
	ECHO.
	ECHO SYSWOW64\%DLLFILE1% not found so nothing to deinstall
	ECHO.	
)


REM 2nd dll
IF NOT "%DLLFILE2%"=="" IF EXIST "%systemroot%\SYSWOW64\%DLLFILE2%" (

ECHO unregistering SYSWOW64\%DLLFILE2%
"%systemroot%\SYSWOW64\regsvr32.exe" /s /u "%systemroot%\SYSWOW64\%DLLFILE2%"

ECHO removing SYSWOW64\%DLLFILE2%
DEL "%systemroot%\SYSWOW64\%DLLFILE2%"


) ELSE (
	ECHO.
	ECHO SYSWOW64\%DLLFILE2% not found so nothing to deinstall
	ECHO.	
)

REM 3rd dll
IF NOT "%DLLFILE3%"=="" IF EXIST "%systemroot%\SYSWOW64\%DLLFILE3%" (

ECHO unregistering SYSWOW64\%DLLFILE3%
"%systemroot%\SYSWOW64\regsvr32.exe" /s /u "%systemroot%\SYSWOW64\%DLLFILE3%"

ECHO removing SYSWOW64\%DLLFILE3%
DEL "%systemroot%\SYSWOW64\%DLLFILE3%"


) ELSE (
	ECHO.
	ECHO SYSWOW64\%DLLFILE3% not found so nothing to deinstall
	ECHO.	
)

REM ---------------------------
ECHO uninstall x64 native mode files
REM ---------------------------

REM 1st dll - case #1  (when running from x86 console so using sysnative alias)

IF NOT "%DLLFILE1%"=="" IF EXIST "%systemroot%\sysnative\%DLLFILE1%" (

ECHO unregistering sysnative\%DLLFILE1%
"%systemroot%\sysnative\regsvr32.exe" /s /u "%systemroot%\sysnative\%DLLFILE1%"

ECHO removing sysnative\%DLLFILE1%
DEL "%systemroot%\sysnative\%DLLFILE1%"

) ELSE (
	ECHO.
	ECHO sysnative\%DLLFILE1% not found so nothing to deinstall
	ECHO.	
)


REM 1st dll - case #2  (when running from x64 console so using system32 folder)

IF NOT "%DLLFILE1%"=="" IF EXIST "%systemroot%\system32\%DLLFILE1%" (

ECHO unregistering system32\%DLLFILE1%
"%systemroot%\system32\regsvr32.exe" /s /u "%systemroot%\system32\%DLLFILE1%"

ECHO removing system32\%DLLFILE1%
DEL "%systemroot%\system32\%DLLFILE1%"

) ELSE (
	ECHO.
	ECHO system32\%DLLFILE1% not found so nothing to deinstall
	ECHO.	
)


REM 2nd dll - case #1  (when running from x86 console so using sysnative alias)

IF NOT "%DLLFILE2%"=="" IF EXIST "%systemroot%\sysnative\%DLLFILE2%" (

ECHO unregistering sysnative\%DLLFILE2%
"%systemroot%\sysnative\regsvr32.exe" /s /u "%systemroot%\sysnative\%DLLFILE2%"

ECHO removing sysnative\%DLLFILE2%
DEL "%systemroot%\sysnative\%DLLFILE2%"

) ELSE (
	ECHO.
	ECHO sysnative\%DLLFILE2% not found so nothing to deinstall
	ECHO.	
)


REM 2nd dll - case #2  (when running from x64 console so using system32 folder)

IF NOT "%DLLFILE2%"=="" IF EXIST "%systemroot%\system32\%DLLFILE2%" (

ECHO unregistering system32\%DLLFILE2%
"%systemroot%\system32\regsvr32.exe" /s /u "%systemroot%\system32\%DLLFILE2%"

ECHO removing system32\%DLLFILE2%
DEL "%systemroot%\system32\%DLLFILE2%"

) ELSE (
	ECHO.
	ECHO system32\%DLLFILE2% not found so nothing to deinstall
	ECHO.	
)



REM 3rd dll - case #1  (when running from x86 console so using sysnative alias)

IF NOT "%DLLFILE3%"=="" IF EXIST "%systemroot%\sysnative\%DLLFILE3%" (

ECHO unregistering sysnative\%DLLFILE3%
"%systemroot%\sysnative\regsvr32.exe" /s /u "%systemroot%\sysnative\%DLLFILE3%"

ECHO removing sysnative\%DLLFILE3%
DEL "%systemroot%\sysnative\%DLLFILE3%"

) ELSE (
	ECHO.
	ECHO sysnative\%DLLFILE3% not found so nothing to deinstall
	ECHO.	
)


REM 3rd dll - case #2  (when running from x64 console so using system32 folder)

IF NOT "%DLLFILE3%"=="" IF EXIST "%systemroot%\system32\%DLLFILE3%" (

ECHO unregistering system32\%DLLFILE3%
"%systemroot%\system32\regsvr32.exe" /s /u "%systemroot%\system32\%DLLFILE3%"

ECHO removing system\%DLLFILE3%
DEL "%systemroot%\system32\%DLLFILE3%"

) ELSE (
	ECHO.
	ECHO system32\%DLLFILE3% not found so nothing to deinstall
	ECHO.	
)




)

if %ERROR% EQU 0 goto :EOF

:SHOWERROR

echo .
echo Error uninstalling the SDK: %ERROR%
echo .

REM Exit %ERROR%

:EOF
