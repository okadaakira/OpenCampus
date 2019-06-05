using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedChanger : MonoBehaviour
{
    private NavMeshAgent agent;
    private float counter = 0;
    private int counterTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        counterTime = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > counterTime)
        {
            agent.speed = Random.Range(2.0f, 10.0f);
            counter = 0;
            counterTime = Random.Range(5, 15);
        }
    }
}
