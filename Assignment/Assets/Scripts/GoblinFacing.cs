using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFacing : MonoBehaviour
{
    public float speed;
    public float radius;

    private Transform playerTransform;
    private bool facingRight = true;

    public Transform player;
    public Rigidbody2D rb;
    private GameObject GoblinHitBox = default;
    public Animator anim;

    public void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GoblinHitBox = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                Vector2 target = new Vector2(player.position.x, rb.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
                if ((playerTransform.position.x < transform.position.x && facingRight) ||
                    (playerTransform.position.x > transform.position.x && !facingRight))
                {
                    FlipDirection();
                }

            }
            else
                anim.SetBool("isRunning", false);
        }
    }

    public void FlipDirection()
    {
        facingRight = !facingRight; // Toggle the facing direction

        // Get the current local scale
        Vector3 scale = transform.localScale;
        Vector3 scale1 = GoblinHitBox.transform.localScale;

        // Flip the X-axis of the local scale
        scale.x *= -1;
        scale1.x *= -1;

        // Apply the new local scale to flip the boss
        transform.localScale = scale;
        GoblinHitBox.transform.localScale = scale1;
    }


}
