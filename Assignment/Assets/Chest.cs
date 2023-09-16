using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject healthPotion;
    public float time;

    private bool canOpen;
    private bool isOpened;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (canOpen && !isOpened)
            {
                anim.SetTrigger("Opening");
                isOpened = true;
                Invoke("GetItem", time);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player") )
        {
            canOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Player") )
        {
            canOpen = false;
        }
    }

    void GetItem() {
        Instantiate(healthPotion, transform.position, Quaternion.identity);
    }
}
