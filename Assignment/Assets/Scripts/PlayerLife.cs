using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public int maxHealth = 100;
    public int currentHealth = 0;

    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            takeDamage(100);
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void takeDamage(int damage) {
        if (currentHealth <= 0 )
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
            else
            {
                anim.SetTrigger("Hurt");
            }
            
        }

        healthBar.SetHealth(currentHealth);
    }

    private IEnumerator VisualIndicator(Color color) {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void addHealth(int health)
    {
        int healthCheck = currentHealth;
        healthCheck += health;
        StartCoroutine(VisualIndicator(Color.green));
        if (healthCheck >= 100)
        {
            currentHealth = 100;
        }
        else {
            currentHealth += health;
        }

     
    
     healthBar.SetHealth(currentHealth);
    }



}
