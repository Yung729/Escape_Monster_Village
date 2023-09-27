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
    [SerializeField] private AudioSource attackSound;
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

        if (distance < 50)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                
                timer = 0;
                shoot();

            }
        }

    }

    void shoot()
    {
        attackSound.Play();
        Instantiate(lazer, lazerPos.position, Quaternion.identity);
    }


}
