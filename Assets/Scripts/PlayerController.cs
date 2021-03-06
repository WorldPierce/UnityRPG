﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator anim;
    private Rigidbody2D myRigidBody;
    private bool playerMoving;
    private Vector2 lastMove;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        playerMove();
        playerSetAnimation();

        
    }

    void playerMove()
    {
        playerMoving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

            myRigidBody.velocity = new Vector2( myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
        }
        //if(input.getaxisraw("horizontal") < 0.5f || input.getaxisraw("horizontal") > -0.5f)
        //{
        //    myrigidbody.velocity = new vector2(0f, myrigidbody.velocity.y);
        //}
    }

    void playerSetAnimation()
    {
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
