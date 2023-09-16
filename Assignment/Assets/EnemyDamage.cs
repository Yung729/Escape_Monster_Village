using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerLife palyerLife;
    private Animator anim;
    // Start is called before the first frame update

    private Health health;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        anim.SetBool("Attack", true);
        if (collision.gameObject.tag =="Player")
        {
            palyerLife.takeDamage(damage);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Attack", false);
        
    }


}
