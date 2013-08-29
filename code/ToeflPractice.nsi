; Full script for making an NSIS installation package for .NET programs,
; Allows installing and uninstalling programs on Windows environment, and unlike the package system 
; integrated with Visual Studio, this one does not suck.
 
;To use this script:
;  1. Download NSIS (http://nsis.sourceforge.net/Download) and install
;  2. Save this script to your project and edit it to include files you want - and display text you want
;  3. Add something like the following into your post-build script (maybe only for Release configuration)
;        "$(DevEnvDir)..\..\..\NSIS\makensis.exe" "$(ProjectDir)Setup\setup.nsi"
;  4. Build your project. 
;
;  This package has been tested latest on Windows 7, Visual Studio 2010 or Visual C# Express 2010, should work on all older version too.
 
; Main constants - define following constants as you want them displayed in your installation wizard
!define PRODUCT_NAME "Toefl Speaking Practicing"
!define PRODUCT_VERSION "1.0"
!define PRODUCT_PUBLISHER "Shiliang Wang"
!define PRODUCT_WEB_SITE "https://sourceforge.net/projects/toeflpractice/"
 
; Following constants you should never change
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"
 
!include "MUI.nsh"
!define MUI_ABORTWARNING
!define MUI_ICON "Study.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"
 
; Wizard pages
!insertmacro MUI_PAGE_WELCOME
; Note: you should create License.txt in the same folder as this file, or remove following line.
!insertmacro MUI_PAGE_LICENSE "License.txt"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_LANGUAGE "English"
 
; Replace the constants bellow to hit suite your project
Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "SetupZawsCC_${PRODUCT_VERSION}.exe"
InstallDir "$PROGRAMFILES\Toefl Speaking Practicing\Toefl Speaking Practicing"
ShowInstDetails show
ShowUnInstDetails show
 
; Following lists the files you want to include, go through this list carefully!
Section "MainSection" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "bin\x86\Release\ToeflPractice.exe"
  File "bin\x86\Release\Microsoft.DirectX.DirectSound.dll"
  File "bin\x86\Release\Microsoft.DirectX.dll"
  File "bin\x86\Release\SQLite.Interop.dll"
  File "bin\x86\Release\System.Data.SQLite.dll"
  File "bin\x86\Release\toeflSpeaking.sqlite"

 
; It is pretty clear what following line does: just rename the file name to your project startup executable.
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\ToeflPractice.exe" ""
SectionEnd
 
Section -Post
  ;Following lines will make uninstaller work - do not change anything, unless you really want to.
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
  
SectionEnd
 
; Replace the following strings to suite your needs
Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "Application was successfully removed from your computer."
FunctionEnd
 
Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Are you sure you want to completely remove ZAwsCC and all of its components?" IDYES +2
  Abort
FunctionEnd
 
; Remove any file that you have added above - removing uninstallation and folders last.
; Note: if there is any file changed or added to these folders, they will not be removed. Also, parent folder (which in my example 
; is company name ZWare) will not be removed if there is any other application installed in it.
Section Uninstall
  Delete "bin\x86\Release\ToeflPractice.exe"
  Delete "bin\x86\Release\Microsoft.DirectX.DirectSound.dll"
  Delete "bin\x86\Release\Microsoft.DirectX.dll"
  Delete "bin\x86\Release\SQLite.Interop.dll"
  Delete "bin\x86\Release\System.Data.SQLite.dll"
  Delete "bin\x86\Release\toeflSpeaking.sqlite"
 
  RMDir "$INSTDIR"
  RMDir "$INSTDIR\.."
 
  SetAutoClose true
SectionEnd