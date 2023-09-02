using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private bool isJumping; //added
    private bool doubleJump;
    private enum MovementState {idle,running,jumping,falling}
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded() && !isJumping && !doubleJump) //is jumping added
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            isJumping = true;
            doubleJump = true;
        }
        else if (Input.GetButtonDown("Jump") && isJumping && doubleJump )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.8f);
            isJumping = false;
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("Attack");
        }

        UpdateAnimationUpdate();


    }

    void OnCollisionEnter2D(Collision2D other) // added
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            doubleJump = false;
        }
    }

    private void UpdateAnimationUpdate() {

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
