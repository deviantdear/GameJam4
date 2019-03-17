using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>(); //refers to saved values in Character stats
    }

    public void Attack(CharacterStats targetStats)
    {

        targetStats.TakeDamage(myStats.damage.GetValue()); //finds out what the players stats are with modifiers

    }
    
}
