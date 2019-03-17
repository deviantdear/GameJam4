using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    CharacterStats myStats;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>(); //refers to saved values in Character stats
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown != 0f) //Checks to see if we can attack after cooldown
        {
            targetStats.TakeDamage(myStats.damage.GetValue()); //finds out what the players stats are with modifiers
            attackCooldown = 1f / attackSpeed;
        }
    }
    
}
