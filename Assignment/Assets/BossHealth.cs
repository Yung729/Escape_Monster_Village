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
    public GameObject panel;


    public FadeAnim fade;

    
    // Update is called once per frame
    

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

    public void showUI()
    {
        panel.SetActive(true);
        fade.setStatus(true);

    }

    public void Damage(int damage)
    {
        damage -= armor;
        StartCoroutine(VisualIndicator(Color.red));

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
                anim.SetTrigger("Death");
                Destroy(gameObject);
                showUI();
                currentHealth = 0;
            }

        }
        healthBar.SetHealth(currentHealth);
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
