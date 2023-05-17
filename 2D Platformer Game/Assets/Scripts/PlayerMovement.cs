using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    public GameObject snowball;
    public float snowballOffset = 1f;

    private enum MovemonetState { idle, running, jumping, falling}
    private MovemonetState state  = MovemonetState.idle;

    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log("Hello Game! This is Start");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition;
            if (dirX > 0)
            {
                spawnPosition = transform.position + transform.right * snowballOffset;
                //ThrowBalls.instance.setDirection(0);
            }
            else if (dirX < 0)
            {
                spawnPosition = transform.position - transform.right * snowballOffset;
                //ThrowBalls.instance.setDirection(1);
            }
            else
            {
                if(sprite.flipX)
                {
                    spawnPosition = transform.position - transform.right * snowballOffset;
                    //ThrowBalls.instance.setDirection(1);
                }
                else
                {
                    spawnPosition = transform.position + transform.right * snowballOffset;
                    //ThrowBalls.instance.setDirection(0);
                }
                // If the player is not moving horizontally, spawn in front of the player based on its forward direction.
                //spawnPosition = transform.position + transform.forward * snowballOffset;
            }

            Instantiate(snowball, spawnPosition, Quaternion.identity);
        }

        //if(Input.GetButtonDown("Jump") && isGrounded())
        if (dirY>.7 && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovemonetState state;
        if (dirX > 0f)
        {
            state = MovemonetState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovemonetState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovemonetState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state=MovemonetState.jumping; 
        }else if (rb.velocity.y < -.1f)
        {
            state=MovemonetState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private Boolean isGrounded ()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
        //return Physics2D.CapsuleCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}
