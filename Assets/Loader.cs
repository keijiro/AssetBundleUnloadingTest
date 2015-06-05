using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return null;

        ShowAssetsCount();

        yield return null;

        var www = new WWW("file:" + Application.streamingAssetsPath + "/test");
        yield return www;

        var go = (GameObject)Instantiate(www.assetBundle.mainAsset, transform.position, transform.rotation);

        yield return null;

        ShowAssetsCount();

        yield return new WaitForSeconds(0.5f);

        //var r = go.GetComponentInChildren<SkinnedMeshRenderer>();
        //var mesh = r.sharedMesh;
        //var texture = r.sharedMaterial.mainTexture;

        Destroy(go);

        yield return null;

        ShowAssetsCount();

        yield return null;

        yield return Resources.UnloadUnusedAssets();
        yield return null;

        ShowAssetsCount();
    }

    static void ShowAssetsCount()
    {
        var meshes = CountAssets<Mesh>();
        var textures = CountAssets<Texture>();
        Debug.Log("Mesh: " + meshes + " / Textures: " + textures);
    }

    static int CountAssets<T>() where T : Object
    {
        return Resources.FindObjectsOfTypeAll<T>().Length;
    }
}
