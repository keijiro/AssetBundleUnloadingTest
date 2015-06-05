using UnityEngine;
using UnityEditor;

public class AssetBundleTool
{
    [MenuItem("Custom/Build AssetBundles")]
    static void BuildAssetBundles()
    {
        var mainAsset = AssetDatabase.LoadMainAssetAtPath("Assets/Constructor/Constructor.fbx");
        Object[] assets = { mainAsset };
        BuildPipeline.BuildAssetBundle(mainAsset, assets, "Assets/StreamingAssets/test", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.iPhone);
    }
}
