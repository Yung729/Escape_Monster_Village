using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public int damage;
    public PlayerLife playerLife;
    // Start is called before the first frame update

    [SerializeField] private AudioSource attackSound;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            attackSound.Play();
            playerLife.takeDamage(damage);
        }
    }


}
