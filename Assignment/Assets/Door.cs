using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform backDoor;
    private Animator anim;

    private bool isDoor;
    private Transform player;
    private GameObject key = default;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        key = transform.GetChild(0).gameObject;
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EnterDoor();
    }

    void EnterDoor() {
        if (isDoor && Input.GetKeyDown(KeyCode.I))
        {
            
            player.position = backDoor.position;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Open");
            isDoor = true;
            key.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Close");
            isDoor = false;
            key.SetActive(false);
        }
    }
}
