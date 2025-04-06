[Setup]
AppName=VideoMaker
AppVersion=1.0
DefaultDirName={code:GetProgramFilesPath}
DefaultGroupName=VideoMaker
OutputDir=.
OutputBaseFilename=VideoMakerInstaller
Compression=lzma2
SolidCompression=yes

[Code]
function GetProgramFilesPath(Param: String): String;
begin
  if IsWin64 then
    Result := 'C:\Program Files\VideoMaker'
  else
    Result := 'C:\Program Files (x86)\VideoMaker';
end;

[Files]
Source: "C:\Users\ZHAOL\Desktop\workplace\VideoMaker\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\ZHAOL\Desktop\workplace\VideoMaker\ffmpeg\*"; DestDir: "{app}\ffmpeg"; Flags: ignoreversion recursesubdirs createallsubdirs

[Tasks]
Name: "desktopicon"; Description: "创建桌面快捷方式"; GroupDescription: "快捷方式:"; Flags: checkedonce

[Icons]
Name: "{userdesktop}\VideoMaker"; Filename: "{app}\VideoMaker.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\VideoMaker.exe"; Description: "启动VideoMaker"; Flags: nowait postinstall skipifsilent