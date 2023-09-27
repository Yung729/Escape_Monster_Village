using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealing : MonoBehaviour
{
    public int damage;
    public PlayerLife playerLife;
    public PlayerMovement playerMovement;
    [SerializeField] private AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attackSound.Play();
            playerMovement.KBCounter = playerMovement.KBTotalTime;
         
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            else
            {
                playerMovement.KnockFromRight = false;
            }
            
            playerLife.takeDamage(damage);
        }
    }


}
