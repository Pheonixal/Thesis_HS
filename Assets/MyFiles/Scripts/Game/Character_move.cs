using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_move : MonoBehaviour
{

    float moveX;
    public int playerspeed;
    private bool facingRight = false;
    public float playerJumpPower;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;


    // Use this for initialization
    void Start()    {
    	anim = GetComponent<Animator>();
    }

    void FixedUpdate()  {
    	playerJumpPower= 12000f;
    	playerspeed = 300;
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    	anim.SetBool("Ground", grounded);

    	anim.SetFloat ("vSpeed", gameObject.GetComponent<Rigidbody2D>().velocity.y);
    	

    	//CONTROLS
        moveX = Input.GetAxis("Horizontal");

    	anim.SetFloat("Speed", Mathf.Abs(moveX));
    	//PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    


    // Update is called once per frame
    void Update()    {       

        if(grounded && Input.GetKeyDown(KeyCode.Space)) {
        anim.SetBool("Ground", false);
        GetComponent<Rigidbody2D>().AddForce( new Vector2 (0, playerJumpPower));

       	}
        
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false)     {
            FlipPlayer();
        }

        else if (moveX > 0.0f && facingRight == true)  {
            FlipPlayer();
        }
        
    }

    
    void FlipPlayer()  {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}﻿