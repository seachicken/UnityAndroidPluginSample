rd /s /q .\AndroidPluginFactory\app\src\main\assets\bin\Data
xcopy /e /EXCLUDE:.\exclude.list ..\UnityExport\UnityProject\assets\bin .\AndroidPluginFactory\app\src\main\assets\bin

copy ..\UnityExport\UnityProject\AndroidManifest.xml .\AndroidPluginFactory\app\src\main\AndroidManifest.xml

pause
