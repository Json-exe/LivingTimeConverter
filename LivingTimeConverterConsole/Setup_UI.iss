; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "LivingTimeConverterUI"
#define MyAppVersion "1.0.0.0"
#define MyAppExeName "LivingTimeConverterUI.exe"
#define public Dependency_NoExampleSetup
#include "CodeDependencies.iss"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{AB73B5A8-4451-4E4B-8BC7-B8E3E0C9A9BD}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputDir={#SourcePath}\output
OutputBaseFilename=LivingTimeConverterUI
Compression=lzma
SolidCompression=yes
WizardStyle=modern
UninstallDisplayName={#MyAppName}
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#SourcePath}LivingTimeConverterUI\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}LivingTimeConverterUI\bin\Release\LivingTimeConverterUI.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}LivingTimeConverterUI\bin\Release\MaterialDesignColors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}LivingTimeConverterUI\bin\Release\MaterialDesignThemes.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}LivingTimeConverterUI\bin\Release\MaterialDesignThemes.Wpf.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}SetupSRC\*"; Flags: dontcopy noencryption
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Registry]
Root: HKCU; Subkey: "SOFTWARE\JDS"; Flags: uninsdeletekeyifempty
Root: HKCU; Subkey: "SOFTWARE\JDS\{#MyAppName}"; Flags: uninsdeletekey; Permissions: users-full
Root: HKCU; Subkey: "SOFTWARE\JDS\{#MyAppName}"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"; Permissions: users-full
Root: HKCU; Subkey: "SOFTWARE\JDS\{#MyAppName}"; ValueType: string; ValueName: "ExeName"; ValueData: "{#MyAppExeName}"; Permissions: users-full
Root: HKCU; Subkey: "SOFTWARE\JDS\{#MyAppName}"; ValueType: string; ValueName: "UninstallPath"; ValueData: "{uninstallexe}"; Permissions: users-full
Root: HKCU; Subkey: "SOFTWARE\JDS\{#MyAppName}"; ValueType: string; ValueName: "Version"; ValueData: "{#MyAppVersion}"; Permissions: users-full

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function InitializeSetup: Boolean;
begin
  // add the dependencies you need
  Dependency_AddDotNet48;

  Result := True;
end;