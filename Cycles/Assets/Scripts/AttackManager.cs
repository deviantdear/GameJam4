using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    #region Singleton
    public static AttackManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    AttackModifier[] currentAttack;

    public delegate void OnAttackChanged(AttackModifier newAttack, AttackModifier defaultAttack);
    public OnAttackChanged onAttackChanged;

    public int numAttacks;

    public void Start()
    {
        currentAttack = new AttackModifier[numAttacks];
    }

    public void Equip (AttackModifier newAttack)
    {
        int slotIndex = newAttack.equipSlot;

        AttackModifier defaultAttack = null;

        if(onAttackChanged != null)
        {
            onAttackChanged.Invoke(newAttack, defaultAttack);
        }

        currentAttack[slotIndex] = newAttack; //changes from default to special
    }

    public void Unequip(int slotIndex)
    {
        AttackModifier defaultAttack = currentAttack[slotIndex];

        //set to a default attack

        if (onAttackChanged != null) //Communicates that the attack has changed
        {
            onAttackChanged.Invoke(null, defaultAttack);
        }
    }

}
