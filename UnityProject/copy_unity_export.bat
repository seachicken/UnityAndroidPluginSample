@rem 古いデータを削除
rd /s /q ..\AndroidPluginFactory\app\build
rd /s /q ..\AndroidPluginFactory\app\libs
rd /s /q ..\AndroidPluginFactory\app\src

@rem Unityからエクスポートしたデータを、プラグイン開発プロジェクトへコピー
echo A | xcopy /e /EXCLUDE:exclude_unity_export.list ..\UnityExport\UnityProject ..\AndroidPluginFactory\app\

pause
