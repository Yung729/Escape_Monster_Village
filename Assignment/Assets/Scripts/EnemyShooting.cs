using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;


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

        if (distance < 5)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                anim.SetBool("Attack", true);
                timer = 0;
                //shoot();
                StartCoroutine(Reload());
            }
            
            
        }

    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        anim.SetBool("Attack", false);
    }

    
}
