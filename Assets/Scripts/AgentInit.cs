using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AgentInit : MonoBehaviour
{
    private GameObject child;
    private string texPath = "Assets/Textures/";

    // Start is called before the first frame update
    void Start()
    {
        child = transform.Find("Hitogata01").gameObject;
        var materials = child.GetComponent<SkinnedMeshRenderer>().materials;

        Texture texture = AssetDatabase.LoadAssetAtPath(texPath + "03.jpg", typeof(Texture)) as Texture;

        foreach (var mt in materials) { 
            mt.SetTexture("_MainTex", texture);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
