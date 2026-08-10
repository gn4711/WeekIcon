dotnet publish WeekIcon.csproj ^
  -c Release ^
  -r win-x64 ^
  --self-contained false ^
  -p:PublishSingleFile=true ^
  -p:IncludeNativeLibrariesForSelfExtract=true ^
  -p:AllowedReferenceRelatedFileExtensions=none ^
  -p:DebugType=none ^
  -p:DebugSymbols=false ^
  -o "publish"

"C:\Program Files (x86)\NSIS\makensis.exe" install.nsi

pause
