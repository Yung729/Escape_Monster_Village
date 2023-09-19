using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    public PlayerLife player;
    public PlayerMovement control;
    public AtackArea damage;

    [SerializeField] private AudioSource healthSound;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource speedSound;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Potions"))
        {
            Destroy(collision.gameObject);
            player.addHealth(30);
            healthSound.Play();
            
        }

        if (collision.gameObject.CompareTag("Potions1"))
        {
            Destroy(collision.gameObject);
            damage.increaseDamage(2);
            damageSound.Play();
        }

        if (collision.gameObject.CompareTag("Potions2"))
        {
            Destroy(collision.gameObject);
            control.increaseSpeed(2.0F);
            speedSound.Play();
        }

    }

}
