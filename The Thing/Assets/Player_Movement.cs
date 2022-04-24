using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D playerBody;
    private Animator animator;
    private SpriteRenderer sprite;
    private float directionX =  0f;
    [SerializeField] private float moveSpeed = 9f;
    [SerializeField] private float jumpForce = 15f;

    private enum MovementState { idle, running, jumping, falling}

    MovementState state = MovementState.idle;



    void Start()
    {
        Debug.Log("Game started");
        playerBody = GetComponent<Rigidbody2D>();

        //disable player from sbinalla
        playerBody.freezeRotation = true;

        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(moveSpeed * directionX, playerBody.velocity.y);

        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (Input.GetButtonDown("Jump") && playerBody.position.y < 2f && playerBody.position.y > -0.5f)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }

        if(playerBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } 
        else if (playerBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        animator.SetInteger("MovementState", (int)state);
    }
    
}
