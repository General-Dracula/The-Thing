using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D playerBody;
    private CapsuleCollider2D playerCollider;
    private Animator animator;
    private SpriteRenderer sprite;
    private float directionX =  0f;
    [SerializeField] private float moveSpeed = 9f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private LayerMask ground; 

    private enum MovementState { idle, running, jumping, falling}

    private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSound; 


    void Start()
    {
        Debug.Log("Game started");
        playerBody = GetComponent<Rigidbody2D>();

        //Disable player from sbinalla(f1 thing)
        playerBody.freezeRotation = true;

        playerCollider = GetComponent<CapsuleCollider2D>();

        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get direction to be able to use controller as well
        directionX = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(moveSpeed * directionX, playerBody.velocity.y);

        PlayerMovement();
    }

    private bool isPlayerOnGround()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    private void PlayerMovement()
    {
        if (Input.GetButtonDown("Jump") && isPlayerOnGround()) //if the jump is pressed then jump
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
            jumpSound.Play();
        }

        if (playerBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else if (directionX > 0f)  //if the player is moving then change the animation
        {
            state = MovementState.running;
            sprite.flipX = false; //flip player in case of direction change
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; //flip player in case of direction change
        }
        else if (playerBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else
        {
            state = MovementState.idle;
        }
        animator.SetInteger("MovementState", (int)state);
    }

    
}


