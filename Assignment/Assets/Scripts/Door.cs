using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator anim;

    private bool isDoor;
    private Transform player;
    private GameObject key = default;
    private GameObject message = default;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        key = transform.GetChild(0).gameObject;
        key.SetActive(false);
        message = transform.GetChild(1).gameObject;
        message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EnterDoor();
    }

    void EnterDoor() {
        if (isDoor && Input.GetKeyDown(KeyCode.I) )
        {
            if (ItemCollecter.getKey() == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                message.SetActive(true);
            }
            
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
