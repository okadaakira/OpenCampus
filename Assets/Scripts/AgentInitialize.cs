using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentInitialize : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        var prameters = gameObject.name.Split('-');

        Debug.Log(prameters[1]);
        speedSet(prameters[1][0]);
        moveMethod(prameters[1][1]);
        agentBehavior(prameters[1][2]);
    }

    void speedSet(char pra)
    {
        switch (pra)
        {
            case '1':
                agent.speed = Random.Range(1.5f, 2.5f);
                break;
            case '2':
                agent.speed = Random.Range(2.5f, 3.5f);
                break;
            case '4':
                agent.speed = Random.Range(3.5f, 5.0f);
                break;
            case '5':
                agent.speed = Random.Range(5.0f, 7.0f);
                break;
            default:
                agent.speed = Random.Range(3.0f, 4.0f);
                break;
        }
    }

    void moveMethod(char pra)
    {
        switch (pra)
        {
            case '2':
                gameObject.AddComponent<SpeedChanger>();
                break;
            case '3':
                gameObject.AddComponent<AgentWarp>();
                break;
            case '4':
                gameObject.AddComponent<SpeedChanger>();
                gameObject.AddComponent<AgentWarp>();
                break;
            default:
                break;
        }
    }

    void agentBehavior(char pra)
    {
        switch (pra)
        {
            case '1':
                gameObject.AddComponent<Patrol>();
                break;
            default:
                gameObject.AddComponent<RandomWalk>();
                break;
        }
    }
}
