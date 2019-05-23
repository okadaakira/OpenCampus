using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AgentGenerator : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            agentGen();
    }

    void agentGen()
    {
        var instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, gameObject.transform);
        PrefabUtility.UnpackPrefabInstance(instance, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
        instance.transform.parent = transform;
    }
}
