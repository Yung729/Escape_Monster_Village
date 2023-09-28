using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShootingScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    private Animator anim;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, 0).normalized * force;

        float rot = Mathf.Atan2(0, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Explode", true);
            other.gameObject.GetComponent<PlayerLife>().takeDamage(20);
            Destroy(gameObject);
        }

    }

}
