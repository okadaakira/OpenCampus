using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentWarp : MonoBehaviour
{
    private float count = 0.0f;
    public float randomWarpTime = 15.0f;
    private Transform minRandomMoveDistanceXZ;
    private Transform maxRandomMoveDistanceXZ;

    // Start is called before the first frame update
    void Start()
    {
        minRandomMoveDistanceXZ = GameObject.Find("minPos").transform;
        maxRandomMoveDistanceXZ = GameObject.Find("maxPos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        // 一定間隔でランダム座標を取得する
        if (count >= randomWarpTime)
        {
            GetRandomPos();
        }
    }

    public void GetRandomPos()
    {
        // ランダム座標
        float randomPosX = Random.Range(minRandomMoveDistanceXZ.position.x, maxRandomMoveDistanceXZ.position.z);
        float randomPosZ = Random.Range(minRandomMoveDistanceXZ.position.x, maxRandomMoveDistanceXZ.position.z);

        // NavMesh上の座標を取得
        NavMeshHit hit;
        if (NavMesh.SamplePosition(new Vector3(randomPosX, gameObject.transform.position.y, randomPosZ), out hit, 1.0f, NavMesh.AllAreas))
        {
            gameObject.transform.position = hit.position;
            count = 0;
        }
    }
}
