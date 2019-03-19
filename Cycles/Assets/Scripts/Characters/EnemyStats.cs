using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    int healthGained = 20;
    int xpGained = 100;

    public override void Die()
    {
        base.Die();

        PlayerManager.instance.charStats.Heal(healthGained); //references character stats in the Playermanager Health
        PlayerManager.instance.charStats.gainXP(xpGained); //references character stats in the Playermanager XP;

        //Death Animation

        Destroy(gameObject);
    }
}
