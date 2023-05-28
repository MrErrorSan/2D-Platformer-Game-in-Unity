using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    //public GameObject snowball;
    public GameObject ballToRight;
    public GameObject ballToLeft;
    public float snowballOffset = 1f;
    public GameObject StartScreen;
    public GameObject PlayScreen;
    public GameObject firstStage;
    public GameObject firstStageCollecables;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource ballSoundEffect;
    private enum MovemonetState { idle, running, jumping, falling,death}

    private void Awake()
    {
        instance = this;
        StartScreen.SetActive(true);
        PlayScreen.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void Update()
    {
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballSoundEffect.Play();
                GameObject ballPrefab;
                Vector3 spawnPosition;
                if (dirX > 0)
                {
                    spawnPosition = transform.position + transform.right * snowballOffset;
                    ballPrefab = ballToRight;
                }
                else if (dirX < 0)
                {
                    spawnPosition = transform.position - transform.right * snowballOffset;
                    ballPrefab = ballToLeft;
                }
                else
                {
                    if (sprite.flipX)
                    {
                        spawnPosition = transform.position - transform.right * snowballOffset;
                        ballPrefab = ballToLeft;
                    }
                    else
                    {
                        spawnPosition = transform.position + transform.right * snowballOffset;
                        ballPrefab = ballToRight;
                    }
                }
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            }

            if (dirY > .7 && isGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            UpdateAnimationState();
        }
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
    }

    public void Play()
    {
        StartScreen.SetActive(false);
        PlayScreen.SetActive(true);
        firstStageCollecables.SetActive(true);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
