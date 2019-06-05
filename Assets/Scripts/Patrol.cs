using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
    // 移動に関するフィールド値
    private Transform[] points;
    private int destPoint;
    private NavMeshAgent agent;

    // 建物観察に関するフィールド値
    private Transform[] buildings;
    private Transform nearBuilding = null;
    private float watchTime;
    private float count = 0.0f;

    void Start()
    {
        // 移動に関するフィールドの初期化
        agent = GetComponent<NavMeshAgent>();
        var movePoint = GameObject.FindGameObjectWithTag("MovePoint");
        points = new Transform[movePoint.transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = movePoint.transform.GetChild(i).transform;
        }

        // 建物観察に関するフィールド値
        var buildingsObjects = GameObject.FindGameObjectsWithTag("Building");
        buildings = new Transform[buildingsObjects.Length];

        for (int i = 0; i < buildingsObjects.Length; i++)
        {
            buildings[i] = buildingsObjects[i].transform;
        }

        destPoint = Random.Range(0, points.Length - 1);
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // 配列内の次の位置を目標地点をランダムで設定
        // 同じ場所は目的地に設定しないようにする
        var index = destPoint;
        while (index == destPoint)
        {
            index = Random.Range(0, points.Length - 1);
        }
        destPoint = index;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 目的地までの距離をランダムで設定
        agent.stoppingDistance = Random.Range(0.0f, 15.0f);

        // 建物を見る時間の設定
        watchTime = Random.Range(10.0f, 30.0f);
    }

    void LookAtNearBuildings()
    {
        if (nearBuilding == null)
        {
            var minDistance = (buildings[0].position - gameObject.transform.position).magnitude;
            Transform near = buildings[0];
            for (int i = 1; i < buildings.Length; i++)
            {
                var distance = (buildings[i].position - gameObject.transform.position).magnitude;
                if (minDistance > distance)
                {
                    minDistance = distance;
                    near = buildings[i];
                }
            }
            nearBuilding = near;
            Debug.Log(nearBuilding);
        }

        Vector3 targetPosition = nearBuilding.position;
        if (transform.position.y != nearBuilding.position.y)
        {
            targetPosition = new Vector3(nearBuilding.position.x, transform.position.y, nearBuilding.position.z);
        }
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }


    void Update()
    {
        // エージェントが現目標地点に近づいてきたら、
        // 近くの建物を観察し、観察が終わったら
        // 次の目標地点を選択します
        if (agent.remainingDistance < agent.stoppingDistance + 0.5f && count < watchTime && !agent.pathPending)
        {
            count += Time.deltaTime;
            LookAtNearBuildings();
        }
        else if (!agent.pathPending && count >= watchTime)
        {
            GotoNextPoint();
            nearBuilding = null; // 次の場所の場所で近くの建物を再建策するためにnullを代入
            count = 0.0f;
        }
    }
}
