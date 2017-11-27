using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                      Header
//
//      This is used to spawn the keys at certain
//      points within the map. 
//--------------------------------------------------------


public class SpawnKeys : MonoBehaviour {


	// Attatch the game manager to this to keep track of the number of keys.
	[SerializeField]
	private GameObject gameManager;

    // This is the gameObject that will be spawned. 
	[SerializeField]
	private GameObject key;

	// Use this for initialization
	void Start () {

        // This finds the object marked with the gameManager tag.
		gameManager = GameObject.FindWithTag ("GameManager");

		// This will spawn the keys at the very beggining of the game.
		spawnKeys ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnKeys()
	{
		// This will add to the total number of keys.
		gameManager.GetComponent<TotalNumberOfKeys> ().addToNumberOfKeys ();

		// This will create a new instance of the key prefab. 
		Instantiate (key, this.transform);
	}
}

//--------------------------------------------------------
//                      Footer 
//
//           Code Written By Ryan Hood
//--------------------------------------------------------
