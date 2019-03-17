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

    void onAttackChanged(AttackModifier newAttack, AttackModifier defaultAttack)
    {
        if (newAttack != null)
        {
            armor.AddModifier(newAttack.armorModifier);
            damage.AddModifier(newAttack.damageModifier);
        }

        if (defaultAttack != null)
        {
            armor.RemoveModifier(defaultAttack.armorModifier);
            damage.RemoveModifier(defaultAttack.damageModifier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
