using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovemonetState { idle, running, jumping, falling}
    private MovemonetState state  = MovemonetState.idle;

    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log("Hello Game! This is Start");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
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
            state=MovemonetState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovemonetState.running;
            sprite.flipX = true;
        }
        else
            state = MovemonetState.idle;
        if(rb.velocity.y > .1f)
        {
            state=MovemonetState.jumping; 
        }else if (rb.velocity.y < -.1f)
        {
            state=MovemonetState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
}
