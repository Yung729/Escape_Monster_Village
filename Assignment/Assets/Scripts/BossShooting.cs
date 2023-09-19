using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject lazer;
    public Transform lazerPos;


    private Animator anim;
    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < 10)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                anim.SetTrigger("Lazer");
                timer = 0;
                shoot();

            }
        }

    }

    void shoot()
    {
        Instantiate(lazer, lazerPos.position, Quaternion.identity);
    }
}
