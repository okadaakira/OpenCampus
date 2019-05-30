using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// AssetPostprocessorの拡張クラス
/// </summary>

public class AssetPostporcessor : AssetPostprocessor
{
    //private string materialPath = "Assets/Materials/AgentMaterials/";

    void OnPostprocessTexture(Texture texture)
    {
        string lowerCaseAssetPath = assetPath.ToLower();
        if (lowerCaseAssetPath.IndexOf("/textures/") == -1)
            return;

        string filename = System.IO.Path.GetFileNameWithoutExtension(lowerCaseAssetPath);
        Debug.Log(filename);

        //var instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, gameObject.transform);
        //PrefabUtility.UnpackPrefabInstance(instance, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
        //instance.transform.parent = transform;
        //Material material = new Material(Shader.Find("Standard"));
        //material.SetTexture("_MainTex", texture);

        //materialPath += filename + ".mat";
        //AssetDatabase.CreateAsset(material, materialPath);
    }
}
