using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag =="Player")
        {
            
            anim.SetBool("Attack", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Attack", false);
        
    }

    public void DiePatrol() {
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }


}
