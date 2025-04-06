 ```bash
 <WindowsPackageType>None</WindowsPackageType>
  dotnet publish -c Release -f net8.0-windows10.0.19041.0 -r win-x64    /p:PublishSingleFile=true
  ```

  ![](Images/Snipaste_2025-04-06_11-55-11.png)
  dotnet publish -c Release -f net8.0-windows10.0.19041.0 -r win-x64    /p:PublishSingleFile=false  -o ./publish
  ![](Images/Snipaste_2025-04-06_12-00-18.png)
  innosetup构建SetUp.exe
  ![](Images/Snipaste_2025-04-06_12-01-27.png)