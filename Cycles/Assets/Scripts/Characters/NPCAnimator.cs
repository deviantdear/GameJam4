using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    protected Animator animator;
    private string[] idleSet = { "IsIdle", "IsEat"};
    private int rand;

    protected virtual void Start() //Alows different object to inherit from this animator script
    {
        rand = Random.Range(0, idleSet.Length);

        animator = GetComponentInChildren<Animator>();

        animator.SetBool(idleSet[rand], true);
    }

}
