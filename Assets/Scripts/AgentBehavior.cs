using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    public float updateRandomPosInterval = 10.0f;
    private float updateRandomPosTimer;
    public Transform minRandomMoveDistanceXZ;
    public Transform maxRandoMoveDistanceXZ;
    private Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        updateRandomPosTimer = updateRandomPosInterval;
        agent = GetComponent<NavMeshAgent>();
        randomPosition = GetRandomPos();
        agent.destination = randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        randomPosition = GetRandomPos();
        agent.destination = randomPosition;
    }

    public Vector3 GetRandomPos()
    {
        // 一定間隔でランダム座標を取得する
        updateRandomPosTimer += Time.deltaTime;
        if (updateRandomPosTimer >= updateRandomPosInterval)
        {
            // ランダム座標
            float randomPosX = Random.Range(minRandomMoveDistanceXZ.position.x, maxRandoMoveDistanceXZ.position.z);
            float randomPosZ = Random.Range(minRandomMoveDistanceXZ.position.x, maxRandoMoveDistanceXZ.position.z);

            // NavMesh上の座標を取得
            NavMeshHit hit;
            if (NavMesh.SamplePosition(new Vector3(randomPosX, gameObject.transform.position.y, randomPosZ), out hit, 1.0f, NavMesh.AllAreas))
            {
                randomPosition = hit.position;
                updateRandomPosTimer = 0;
                return randomPosition;
            }
        }
        return randomPosition;
    }
}
