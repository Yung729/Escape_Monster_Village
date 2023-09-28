using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    public PlayerLife player;
    public PlayerMovement control;
    public AtackArea damage;

    public static int key = 0;

    [SerializeField] private AudioSource healthSound;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource speedSound;
    [SerializeField] private AudioSource keySound;

    private GameObject buff1 = default;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Potions"))
        {
            StartCoroutine(VisualIndicator(Color.green));
            StartCoroutine(bufferEffect(1));
            Destroy(collision.gameObject);
            player.addHealth(30);
            healthSound.Play();
            
        }

        if (collision.gameObject.CompareTag("Potions1"))
        {
            StartCoroutine(VisualIndicator(Color.red));
            StartCoroutine(bufferEffect(2));
            Destroy(collision.gameObject);
            damage.increaseDamage(2);
            damageSound.Play();
        }

        if (collision.gameObject.CompareTag("Potions2"))
        {
            StartCoroutine(VisualIndicator(Color.blue));
            StartCoroutine(bufferEffect(3));
            Destroy(collision.gameObject);
            control.increaseSpeed(2.0F);
            speedSound.Play();
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            keySound.Play();
            Destroy(collision.gameObject);
            key = 1;
        }

    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator bufferEffect(int index)
    {
        buff1 = transform.GetChild(index).gameObject;
        buff1.SetActive(true);
        yield return new WaitForSeconds(1f);
        buff1.SetActive(false);
    }

    public static int getKey() {
        return key;
    }

    public static void setKey(int value)
    {
        key = value;
    }

}
