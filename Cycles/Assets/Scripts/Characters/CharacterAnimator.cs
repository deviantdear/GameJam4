﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float animSmoothTime = .1f; //variable to smooth out animations 

    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] defaultAttackAnimSet; //Allows us to create an array of animations to swap through
    protected AnimationClip[] currentAttackAnimSet;

    protected NavMeshAgent agent; 
    protected Animator animator;
    protected Combat charCombat;
    protected AnimatorOverrideController overrideController;

    // Start is called before the first frame update

    protected virtual void Start() //Alows different object to inherit from this animator script
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        charCombat = GetComponent<Combat>();
        charCombat.OnAttack += OnAttack; //Subscribes it to OnAttack Delegate

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController); //Allows us to swap out clips for other clips
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimSet = defaultAttackAnimSet;

    }

    // Update is called once per frame

    protected virtual void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        // animator.SetFloat("moveSpeed", speedPercent, animSmoothTime, Time.deltaTime);

        //animator.SetBool("inCombat", charCombat.InCombat);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("IsAttack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideController[replaceableAttackAnim.name] = currentAttackAnimSet[attackIndex];
    }

    }
