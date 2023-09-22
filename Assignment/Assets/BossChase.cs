using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public float speed;
    public float radius;

    private Transform playerTransform;
    private SpriteRenderer sprite;
    private bool facingRight = true;

    private GameObject hitBox = default;
    private GameObject hitBox1 = default;

    public void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hitBox = transform.GetChild(0).gameObject;
        hitBox1 = transform.GetChild(1).gameObject;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
                if ((playerTransform.position.x < transform.position.x && facingRight) ||
                    (playerTransform.position.x > transform.position.x && !facingRight))
                {
                    FlipBossDirection();
                }
            }
        }
    }



    private void FlipBossDirection()
    {
        sprite.flipX = facingRight;
        facingRight = !facingRight; // Toggle the facing direction

        Vector3 hitBoxScale = hitBox.transform.localScale;
        Vector3 hitBox1Scale = hitBox1.transform.localScale;
        // Apply the new local scale to flip the boss
        if (facingRight || !facingRight)
        {
            hitBoxScale.x *= -1;
            hitBox1Scale.x *= -1;
        }

        // Flip the X-axis of the hitBox and hitBox1 local scales as well
        
        
        hitBox.transform.localScale = hitBoxScale;

        
        
        hitBox1.transform.localScale = hitBox1Scale;
    }
}
