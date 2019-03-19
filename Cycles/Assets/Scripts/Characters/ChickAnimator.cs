using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickAnimator : CharacterAnimator
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(agent.hasPath)
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsSleep", false);
            animator.SetBool("IsSit", false);
        }
        else
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsSleep", false);
            animator.SetBool("IsSit", false);
        }
    }
}
