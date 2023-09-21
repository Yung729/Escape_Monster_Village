using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{


    public int maxHealth = 10;
    public int currentHealth = 0;
    public Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask lavaGround;
    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
    }

    private void Update() {
        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, lavaGround))
        {
            Damage(maxHealth);
        }
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
