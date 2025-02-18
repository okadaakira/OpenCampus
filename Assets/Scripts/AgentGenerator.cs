﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AgentGenerator : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> gameObjects = new List<GameObject>();
    private int texCount;
    private List<string> texsName = new List<string>();
    private string directory = "Assets/Textures/";
    private DirectoryInfo di = new DirectoryInfo("Assets/Textures");
    private FileInfo[] files;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        { 
            agentGen();
        }
    }

    void agentGen()
    {
        texCount = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly).Length / 2; // Textureの数を取得
        files = di.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);

        if (texCount != gameObjects.Count)
        {
            for (int i = 0; i < texCount; i++)
            {
                var str = Path.GetFileNameWithoutExtension(files[i].ToString());
                if (texsName.Contains(str)) //　名前被り回避
                    continue;

                texsName.Add(str);
            }

            for (int i = gameObjects.Count; i < texCount; i++)
            {
                var instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, gameObject.transform);
                gameObjects.Add(instance);
                PrefabUtility.UnpackPrefabInstance(instance, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
                instance.transform.parent = transform;
                instance.gameObject.name = texsName[i];

                var child = instance.transform.Find("Hitogata01").gameObject;
                var materials = child.GetComponent<SkinnedMeshRenderer>().materials;

                Texture texture = AssetDatabase.LoadAssetAtPath(directory + texsName[i] + ".jpg", typeof(Texture)) as Texture;
                foreach (var mt in materials)
                {
                    mt.SetTexture("_MainTex", texture);
                }
            }
        }
    }
}
