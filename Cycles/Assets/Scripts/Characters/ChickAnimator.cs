using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickAnimator : CharacterAnimator
{

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        charCombat = PlayerManager.instance.player.GetComponent<Combat>();
        charCombat.OnAttack += OnAttack; //Subscribes it to OnAttack Delegate
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController); //Allows us to swap out clips for other clips
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimSet = defaultAttackAnimSet;
        agent = PlayerManager.instance.navAgent;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(agent.hasPath)
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);

        }
        else if (charCombat.InCombat)
        {
            animator.SetBool("IsAttack", true);
        }
        else
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsWalk", false);
        }
    }
}
