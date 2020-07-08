using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRight : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float move_speed = 7f;
	private float movement = 0f;
    public float jump_speed = 7f;

    // Advanced jumping
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> (); //getting the object with whom the script is associated
    }


    void Update()
    {

        // checking for ground
        isTouchingGround =  Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

    	movement = Input.GetAxis("Vertical");   // gets how much u press on left or right shiii


        // Horizontal movement
    	if(movement > 0f)
        {
        	rigidBody.velocity = new Vector2(movement*move_speed, rigidBody.velocity.y);  // (x , y ) for moving stuff
        }
        else if(movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement*move_speed, rigidBody.velocity.y);  // (x , y ) for moving stuff
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);  // (x , y ) for moving stuff        	
        }

        // Jumping
        if(Input.GetButtonDown("Jump1") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump_speed);
        }
   
    }
}
