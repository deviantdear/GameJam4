using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        AttackManager.instance.onAttackChanged += onAttackChanged;
    }

    void OnAttackChanged(AttackModifier newAttack, AttackModifier oldAttack)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
