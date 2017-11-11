﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float PlayerSpeed;
    [SerializeField]
    private float jumpHeight;


    private Vector3 playerVelocity;


    //left and right control
    private Vector3 currentScale;           //used to alter transform
    private bool facingRight = true;        //holds directions of player

	//Check if grounded (on floor)
	public float threshold;

	private bool isGrounded;

    //animation components
    private Animator playerAnimator;
    private float movementSpeed = 0;        //variables that relate to parameters
    private bool jumped = false;


    // Use this for initialization
    void Start()
    {

        currentScale = transform.localScale;

        PlayerSpeed = 5;
        jumpHeight = 5;


        playerVelocity = GetComponent<Rigidbody>().velocity;

        // playerAnimator = GetComponent<Animator>();

    }


    void FixedUpdate()
    {



    }

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Platform") {
			isGrounded = true;
		}
	}
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "Platform") {
			isGrounded = false;
		}
	}
    // Update is called once per frame
    void Update()
    {
        playerVelocity = GetComponent<Rigidbody>().velocity;
		playerVelocity.z = 0;


        if (Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(PlayerSpeed * Input.GetAxis("Horizontal"), playerVelocity.y, playerVelocity.z);

            //set movement speed that will be used for the transitions of the player states in the animations
            movementSpeed = Mathf.Abs(Input.GetAxis("Horizontal"));
        }

		if (isGrounded == true) {
			//character jumps
			if (Input.GetButtonDown ("Jump")) {
				CharacterJump ();
			}
		}
    }


    private void CharacterJump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(playerVelocity.x, jumpHeight, playerVelocity.z);
    }
		
}