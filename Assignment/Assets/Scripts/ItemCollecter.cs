using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    public PlayerLife player;
    public PlayerMovement control;
    public AtackArea damage;

    [SerializeField] private AudioSource healthSound;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Potions"))
        {
            Destroy(collision.gameObject);
            player.addHealth(20);
            healthSound.Play();
            
        }

        if (collision.gameObject.CompareTag("Potions1"))
        {
            Destroy(collision.gameObject);
            damage.increaseDamage(1);
        }

        if (collision.gameObject.CompareTag("Potions2"))
        {
            Destroy(collision.gameObject);
            control.increaseSpeed(1.0F);

        }

    }

}
