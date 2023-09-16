using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;


    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private bool isJumping; //added
    private bool doubleJump;
    private enum MovementState {idle,running,jumping,falling,crouch}
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        attackArea = transform.GetChild(0).gameObject;
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
            Attack();
            anim.SetTrigger("Attack");
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Crouch");
            coll.size = new Vector2(0.3447157F, 0.7626788F);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("Reload");
            coll.size = new Vector2(0.3447157F, 1.160765F);
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
            attackArea.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            attackArea.transform.localScale = new Vector3(-1, 1, 1);
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

    public void increaseSpeed(float speed) {
        
        moveSpeed += speed;
        

    }

    private void Attack() {
        attacking = true;
        attackArea.SetActive(attacking);
    }

}
