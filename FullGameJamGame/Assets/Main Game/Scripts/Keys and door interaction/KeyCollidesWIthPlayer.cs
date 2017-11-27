using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                      Header
//
//      This will be used to check if the player has 
//      entered the key's radius.
//
//--------------------------------------------------------

public class KeyCollidesWIthPlayer : MonoBehaviour {

    // This will hold a refernce to the player's game object. 

    [SerializeField]
	private GameObject player;

    // This will hold a refernce to the gameManager object. 

    [SerializeField]
	private GameObject gameManager;



	// Use this for initialization
	void Start () {

        // This looks for the object marked with the gameManager tag.

        gameManager = GameObject.FindWithTag ("GameManager");

	}
	
	// Update is called once per frame
	void Update () {

	}

	// Calls when the player collides with the key

	private void OnTriggerEnter(Collider other)
	{
		// If the object attached comes within a certain radius of this it will trigger.

		if (other.name == "Player")
		{
            // This will get access to the gameManager and use one of it's scripts increasing the 
            // number of the keys the player has collected. 

			gameManager.GetComponent<KeyTracker> ().addToCollectedKeys ();

			// This destroys this instance of the game object. 

			Destroy (this.gameObject);
		}
	}
}

//--------------------------------------------------------
//                  Footer 
//  
//          Code Written By Ryan Hood
//--------------------------------------------------------
