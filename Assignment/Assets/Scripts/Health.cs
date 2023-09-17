using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{


    public int maxHealth = 10;
    public int currentHealth = 0;
    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }



    public void Damage(int damage)
    {

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
        else
        {
            anim.SetTrigger("Hurt");
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                currentHealth = 0;
            }

        }

    }



}
