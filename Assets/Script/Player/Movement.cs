using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Unity Elements
    private Rigidbody2D player;
    private Animator animator;
    private SpriteRenderer render;
    private BoxCollider2D collid;


    //Stats
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask jumpable;

    //Global Variables
    private float directionX;
    private enum MovementState { Idle, Run, Jump, Fall}
    private MovementState moveState;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        collid = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();

        Jump();

        UpdateHorizontalState();

        UpdateVerticalState();
    }

    private void Jump() 
    {
        if (Input.GetButtonDown(StringStore.jump) && CheckJump()) 
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }
    }

    private void Run() 
    {
        directionX = Input.GetAxisRaw(StringStore.horizontal);
        player.velocity = new Vector2(directionX * speed, player.velocity.y);
    }

    private void UpdateHorizontalState() 
    {     

        if (directionX > 0f) 
        {
            moveState = MovementState.Run;
            render.flipX = false;
            
            //Debug.Log("dirX > 0");
        } 
        else if (directionX < 0f)
        {
            moveState = MovementState.Run;
            render.flipX = true;
            
            //Debug.Log("dirX < 0");
        }
        else
        {
            moveState = MovementState.Idle;
        }

        animator.SetInteger(StringStore.moveState, (int) moveState);

    }

    private void UpdateVerticalState() 
    {
        if (player.velocity.y > 0.1f) 
        {
            moveState = MovementState.Jump;
        } 
        else if (player.velocity.y < -0.1f)
        {
            moveState = MovementState.Fall;
        }

        animator.SetInteger(StringStore.moveState, (int) moveState);

    }


    private bool CheckJump() 
    {
        return Physics2D.BoxCast(collid.bounds.center, 
        collid.bounds.size, 0f, Vector2.down, .1f, jumpable);
    }

}
