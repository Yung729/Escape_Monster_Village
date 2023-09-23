using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackArea : MonoBehaviour
{
    [SerializeField] private int damage = 3;
    public SpriteRenderer sprite;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }

        if (collider.GetComponent<BossHealth>() != null)
        {
            BossHealth health = collider.GetComponent<BossHealth>();
            health.Damage(damage);
        }

    }

    

    public void increaseDamage(int input) {
        
        damage += input;
        
    }

}
