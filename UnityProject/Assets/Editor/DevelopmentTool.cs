using System.Diagnostics;
using System.Linq;
using UnityEditor;

public class DevelopmentTool
{
    [MenuItem("Tools/Sync Android Studio")]
    public static void SyncAndroidStudio()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);

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
        var mergeTool = new Process();
        var info = mergeTool.StartInfo;
        info.FileName = @"{Application.dataPath}\..\copy_unity_export.bat";
        info.UseShellExecute = false;
        mergeTool.Start();
        mergeTool.WaitForExit();
        mergeTool.Close();
    }
}
