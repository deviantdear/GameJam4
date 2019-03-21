using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : CharacterAnimator
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


        if (agent.hasPath)
        {
            animator.SetTrigger("isRun");

        }
        else if (charCombat.InCombat)
        {
            animator.SetTrigger("isAttack");
        }
        else
        {
            animator.SetTrigger("isIdle");
        }
    }
}
