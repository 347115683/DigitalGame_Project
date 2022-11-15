using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpSpeed = 14f;
    [SerializeField]private float jumpPower = 14f;
    [SerializeField]private float doubleJumpSpeed =14f;

    private float wallJumpColldown;
    private BoxCollider2D coll;

    private enum MovementState{idle,running,jumping,falling,wallJump,doubleJump,doubleFall}

    [SerializeField]private LayerMask jumpableGround;
    
    [SerializeField]private LayerMask jumpableWall;

    [SerializeField] private AudioSource JumpSoundEffect;

    private bool canDoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAnimatonState();
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
         if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        else if (onWall() && !IsGrounded())
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.gravityScale = 3;
        }
    }
    
    private void Jump()
    {
        if (IsGrounded())
        {
        JumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x,jumpPower); 
        canDoubleJump = true;
        }
        else if (onWall() && !IsGrounded())
        {
            JumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed); 
        }
        else
        {
            if (canDoubleJump)
            {
                JumpSoundEffect.Play();
                Vector2 doubleJumpVel = new Vector2(0.0f,doubleJumpSpeed);
                rb.velocity = Vector2.up*doubleJumpVel;
                canDoubleJump = false;
            }
        }
    }
    
    private void UpdateAnimatonState()
    {
        MovementState state;

        if (dirX > 0f && IsGrounded())
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f && IsGrounded())
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else if (rb.velocity.y > .1f && dirX > 0f && canDoubleJump)
        {
            state = MovementState.jumping;
            sprite.flipX = false;
        }
        else if (rb.velocity.y > .1f && dirX < 0f && canDoubleJump)
        {
            state = MovementState.jumping;
            sprite.flipX = true;
        }
        else if (rb.velocity.y > .1f && !canDoubleJump &&  dirX > 0f )
        {
            state = MovementState.doubleJump;
            sprite.flipX = false;
        }
        else if (rb.velocity.y > .1f && !canDoubleJump &&  dirX < 0f )
        {
            state = MovementState.doubleJump;
            sprite.flipX = true;
        }
        else if (rb.velocity.y < -.1f && !IsGrounded())
        {
            state = MovementState.falling;
        }
        else if (!IsGrounded() && onWall())
        {
            state = MovementState.wallJump;
        }
        else if (!canDoubleJump && !IsGrounded() && !canDoubleJump)
        {
            state = MovementState.doubleFall;
        }
        else
        {

            state = MovementState.idle;
  
        }
       

        anim.SetInteger("state",(int)state);
    }

    private bool IsGrounded()
    {
        //return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        return raycastHit.collider !=null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, jumpableWall);
        return raycastHit.collider !=null;
    }
}
