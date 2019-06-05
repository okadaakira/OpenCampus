using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitogataAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);

        // AnimationSpeed調整
        if (agent.velocity.magnitude > 1.0f)
            animator.SetFloat("AnimationSpeedWalk", agent.velocity.magnitude / 3.0f);
        else if (agent.velocity.magnitude > 5.0f)
            animator.SetFloat("AnimationSpeedRun", agent.velocity.magnitude / 5.0f);
    }
}
