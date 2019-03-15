using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickAnimator : MonoBehaviour
{
    const float animSmoothTime = .1f;
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
       // animator.SetFloat("moveSpeed", speedPercent, animSmoothTime, Time.deltaTime);
        if(agent.hasPath)
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsEat", false);
            animator.SetBool("IsSleep", false);
            animator.SetBool("IsSit", false);
        }
        else
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsEat", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsSleep", false);
            animator.SetBool("IsSit", false);
        }
    }
}
