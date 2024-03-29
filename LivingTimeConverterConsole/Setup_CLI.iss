; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "LivingTimeConverterCLI"
#define MyAppVersion "1.0.0.0"
#define MyAppExeName "LivingTimeConverterConsole.exe"
#define public Dependency_NoExampleSetup
#include "CodeDependencies.iss"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{DCBD8478-AFFA-4FBA-8C6C-E959A4C6DC47}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputDir={#SourcePath}\output
OutputBaseFilename=LivingTimeConverterCLI
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64
UninstallDisplayName={#MyAppName}


[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#SourcePath}LivingTimeConverterConsole\bin\Release\net6.0\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}LivingTimeConverterConsole\bin\Release\net6.0\LivingTimeConverterConsole.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}LivingTimeConverterConsole\bin\Release\net6.0\LivingTimeConverterConsole.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}LivingTimeConverterConsole\bin\Release\net6.0\LivingTimeConverterConsole.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}SetupSRC\*"; Flags: dontcopy noencryption deleteafterinstall
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
  Dependency_AddDotNet60Desktop;
  Dependency_AddDotNet60;

  Result := True;
end;