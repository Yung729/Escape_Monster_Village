using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShootingScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public GameObject prefab;
    private GameObject instantiatedPrefab;
    private Transform lastPos;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<PlayerLife>().takeDamage(10);
            Destroy(gameObject);
            lastPos = gameObject.transform;
            instantiatedPrefab = Instantiate(prefab, lastPos.position, Quaternion.identity);
            Destroy(instantiatedPrefab,0.5f); // Destroy the instantiated object after waiting
            
        }


        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            lastPos = gameObject.transform;
            instantiatedPrefab = Instantiate(prefab, lastPos.position, Quaternion.identity);
            Destroy(instantiatedPrefab, 0.5f); // Destroy the instantiated object after waiting
        }
    }

}
