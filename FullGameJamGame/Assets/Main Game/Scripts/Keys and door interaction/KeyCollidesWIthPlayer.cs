using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollidesWIthPlayer : MonoBehaviour {

	[SerializeField]
	private GameObject player; 

	[SerializeField]
	private GameObject gameManager;

	// Use this for initialization
	void Start () {

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
			gameManager.GetComponent<KeyTracker> ().addToCollectedKeys ();

			// This destroys this instance of the game object. 

			Destroy (this.gameObject);
		}
		

	}

}
