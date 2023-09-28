using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShootingScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public GameObject prefab;
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
            lastPos = gameObject.transform;
            Destroy(gameObject);
            StartCoroutine(Explode());

        }


        if (other.gameObject.CompareTag("Ground"))
            Destroy(gameObject);

    }

    private IEnumerator Explode()
    {
        GameObject instantiatedPrefab = Instantiate(prefab, lastPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(instantiatedPrefab); // Destroy the instantiated object, not the prefab
    }
}
