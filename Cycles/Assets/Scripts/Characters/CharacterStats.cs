using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth { get; private set; } //any class can get the value only change it in this class

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxhealth; //initial value
    }

    public void Update()
    {

    }

    public void TakeDamage(int damage)
    {
         
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //prevents negative damage values 

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way, should be overriden
        Debug.Log(transform.name + " died.");

    }
}
