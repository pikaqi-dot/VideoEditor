[Setup]
AppName=MyApp
AppVersion=1.0
DefaultDirName={code:GetProgramFilesPath}
DefaultGroupName=MyApp
OutputDir=.
OutputBaseFilename=MyAppInstaller
Compression=lzma2
SolidCompression=yes
[Code]
function GetProgramFilesPath(Param: String): String;
begin
  if IsWin64 then
    Result := 'C:\Program Files\MyApp'
  else
    Result := 'C:\Program Files (x86)\MyApp';
end;

[Files]
Source: "C:\Users\ZHAOL\Desktop\workplace\VideoMaker\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
[Tasks]
Name: "desktopicon"; Description: "创建桌面快捷方式"; GroupDescription: "快捷方式:";Flags: checkedonce
[Icons]
Name: "{userdesktop}\VideoMaker"; Filename: "{app}\VideoMaker.exe";Tasks: desktopicon

[Run]
Filename: "{app}\VideoMaker.exe"; Description: "Launch MyApp"; Flags: nowait postinstall skipifsilent