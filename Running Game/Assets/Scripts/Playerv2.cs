using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerv2 : MonoBehaviour {
    // Horizontal Movement
    private Vector3 horInput;           // Contains the sideways info movement of the player
    public float speed = 20f;

    // Jumping
    private bool transJump;             // Transfers the info from Update() to FixedUpdate()
    private Vector3 jumpTarget;
    public float jumpIncrease;          // The target the player is going to lerp to when jumping
    public float jumpTimeMax;
    private float currentJumpTime;

    // Double or Triple Jumps
    public int maxJumps = 1;
    private int currentJump;
    private bool canJumpMoreTimes;       // It is there to prevent the transfer code

    // Gravity
    public float gravitySpeed;

    // Going down faster
    public float downSpeed;             // Input down speed
    private bool transDown;


    // Useful information
    private bool touchingGround;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        horInput = Vector3.right * Input.GetAxisRaw("Horizontal");

        // || Jumping Inputs ||

        // Getting the target of the lerp jump & getting the logic for +1 jumps in the air
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentJumpTime = 0;
            currentJump++;
            // TN: current jump is before the if statement not after
            if (currentJump < maxJumps)
            {
                jumpTarget = transform.position + Vector3.up * (jumpIncrease);
                canJumpMoreTimes = true;
            }
            else
            {
                canJumpMoreTimes = false;       
                // TEST: Debug.Log("Too many jumps");
            }
        }



        // ||| Variable info transfers |||
        // Jumps
        if (Input.GetKey(KeyCode.W) && canJumpMoreTimes && currentJumpTime <= jumpTimeMax)
        {
            currentJumpTime += Time.deltaTime;
            transJump = true;
        }
        if (!Input.GetKey(KeyCode.W) || currentJumpTime > jumpTimeMax)
        {
 
            transJump = false;
        }

        // Going down faster
        if (Input.GetKey(KeyCode.S) && !touchingGround)
        {
            // TEST: Debug.Log("Going Down faster");
            transDown = true;
        }
        if(!Input.GetKey(KeyCode.S) || touchingGround)
        {
            // TEST: Debug.Log("Stopped going down faster");
            transDown = false;
        }
        // Resetting the current num of jumps
        if (touchingGround)
        {
            currentJump = 0;
        }

  

    }

    private void PhysicallyMoving()
    {
        // TEST: Debug.Log("Jumping");
        transform.position = Vector3.Lerp(transform.position, jumpTarget, 0.1f);
    }

    private void FixedUpdate()
    {
        transform.position += horInput * speed / 10;
        if (transJump)
        {
            PhysicallyMoving();
        }
        else if(!touchingGround && !transDown)
        {
            // TEST: Debug.Log("Going down by gravity");
            transform.position += Vector3.down * gravitySpeed;
        }
        else if (transDown)
        {
            // TEST: Debug.Log("Physically going down faster");
            transform.position += Vector3.down * downSpeed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            touchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            touchingGround = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * jumpIncrease);
    }
}
