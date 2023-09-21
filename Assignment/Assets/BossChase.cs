using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public float speed;
    public float radius;

    private Transform playerTransform;
    private bool facingRight = true;

    private GameObject hitBox = default;
    private GameObject hitBox1 = default;

    public void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hitBox = transform.GetChild(0).gameObject;
        hitBox1 = transform.GetChild(1).gameObject;
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
        facingRight = !facingRight; // Toggle the facing direction

        // Get the current local scale of the boss
        Vector3 scale = transform.localScale;

        // Flip the X-axis of the local scale to change the boss's direction
        scale.x *= -1;

        // Apply the new local scale to flip the boss
        transform.localScale = scale;

        // Flip the X-axis of the hitBox and hitBox1 local scales as well
        Vector3 hitBoxScale = hitBox.transform.localScale;
        hitBoxScale.x = -1;
        hitBox.transform.localScale = hitBoxScale;

        Vector3 hitBox1Scale = hitBox1.transform.localScale;
        hitBox1Scale.x = -1;
        hitBox1.transform.localScale = hitBox1Scale;
    }
}
