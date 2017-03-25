﻿using System.Diagnostics;
using System.Linq;
using UnityEditor;

public class DevelopmentTool
{
    [MenuItem("Tools/Sync Android Studio")]
    public static void SyncAndroidStudio()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);

        // エクスポートは上書き出力されてゴミが残ってしまう為、事前に古いエクスポートデータをクリアする
        RunBatch(@"{Application.dataPath}\..\clean_unity_export.bat");

        const BuildOptions options = BuildOptions.AcceptExternalModificationsToPlayer
                                   | BuildOptions.Development
                                   | BuildOptions.AllowDebugging;

        BuildPipeline.BuildPlayer(
            (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray(),
            "../UnityExport",
            BuildTarget.Android,
            options
        );

        // プラグイン開発プロジェクトへUnityからエクスポートしたデータをコピー
        RunBatch(@"{Application.dataPath}\..\copy_unity_export.bat");
    }

    private static void RunBatch(string path)
    {
        var process = new Process();
        var info = process.StartInfo;
        info.FileName = path;
        info.UseShellExecute = false;
        process.Start();
        process.WaitForExit();
        process.Close();
    }
}
