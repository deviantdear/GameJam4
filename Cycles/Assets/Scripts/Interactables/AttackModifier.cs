using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack PU", menuName = "Inventory/Equipment")]
public class AttackModifier : Item
{
    public int equipSlot = 0;
    public int damageModifier;
    public int armorModifier;

    public override void Use()
    {
        base.Use();

        //Equip Attack
        AttackManager.instance.Equip(this);

        //Remove from inventory
        RemoveFromInventory();
    }

}