using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public int armor = 0;
    public Animator anim;

    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    public void Die()
    {

        Destroy(gameObject);
    }


    public void Damage(int damage)
    {
        damage -= armor;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            anim.SetTrigger("Death");
            
        }
        else
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                currentHealth = 0;
            }

        }
        healthBar.SetHealth(currentHealth);
    }
}
