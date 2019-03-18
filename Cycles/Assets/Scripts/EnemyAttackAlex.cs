using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // Damage done to player by enemy


    Animator anim;                               // Annimator component.
    GameObject player;                           // Player GameObject.
    PlayerHealthsss playerHealth;                // Player's health.
    //EnemyHealth enemyHealth;                   // Enemy's health.
    bool playerInRange;                          // Whether player is within the trigger collider and can be attacked.
    float timer;                                 // Timer for counting up to the next attack.


    void Awake()
    {
        // References to interactions with the player
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealthsss>();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If entering collider is the main player
        if (other.gameObject == player)
        {
            //Player now in range
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If collider of player is leaving
        if (other.gameObject == player)
        {
            // Pla
            playerInRange = false;
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
      //  if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack();
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }
}