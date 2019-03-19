using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth { get; private set; } //any class can get the value only change it in this class
    public int xp;

    public Stat damage;
    public Stat armor;

    public event System.Action<int, int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxhealth; //initial value
    }

    public void TakeDamage(int damage)
    {
         
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //prevents negative damage values 

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxhealth, currentHealth);
        }

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
