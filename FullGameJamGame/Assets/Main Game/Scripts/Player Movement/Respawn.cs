﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                         Header
//
//      This will be used to make the player respawn at
//      a certain point on the map.
//
//--------------------------------------------------------

public class Respawn : MonoBehaviour
{
    // This will be used to get a reference to a gameObject.
	[SerializeField]
	private GameObject spawnpos;

    // This will be used to get a reference to a script.
	GravityFlip GravityFlip;

	void Start()
	{
        // This will be used to find the gameObject with the tag "Spawn"
		var spawnpos = GameObject.Find("Spawn").transform.position;

        // This will be used to find the script gravity flip.
		GravityFlip = GameObject.FindWithTag("Water").GetComponent<GravityFlip>();
	}

    // Checks every frame: 
	void Update()
	{

        // if the player has pressed r : 
		if (Input.GetKeyDown("r")){

            // Calls Spawn Player: 
			spawnPlayer ();

            // Used For debugging :
			// Debug.Log ("Kill Yourself");
		}		
	}


    // This is used to spawn player. 
	public int spawnPlayer()
	{
        // This sets the local transform equal to the spawnpos's local posstion.
		transform.localPosition = new Vector3(spawnpos.transform.position.x, spawnpos.transform.position.y + 2, spawnpos.transform.position.z);

        PlayerMovement PlayerMovement = GetComponent<PlayerMovement>();
        //Swaps the jump height otherwise the player will try and jump the wrong way
        PlayerMovement.SwapJumpHeight();
        // Resets all properties changed by gravity flip
        GravityFlip.ResetFlip();

		return 0;
	}
}

//--------------------------------------------------------
//                         Header
//
//              Code Written By Ben Sparkes 
//--------------------------------------------------------