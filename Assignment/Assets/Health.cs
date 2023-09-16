using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public int maxHealth = 10;
    public int currentHealth = 0;


    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    public void Damage(int damage)
    {

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        else
        {

            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }

        }

    }



}
