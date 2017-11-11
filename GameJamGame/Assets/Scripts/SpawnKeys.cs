using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeys : MonoBehaviour {


	// Attatch the game manager to this to keep track of the number of keys.
	[SerializeField]
	private GameObject gameManager;

	[SerializeField]
	private GameObject key;

	// Use this for initialization
	void Start () {

		// THis will spawn the keys at the very beggining of the game.
		spawnKeys ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnKeys()
	{
		// This will add to the total number of keys.
		gameManager.GetComponent<TotalNumberOfKeys> ().addToNumberOfKeys ();

		// THis will create a new instance of the key prefab. 
		Instantiate (key, this.transform);
	}
		
}
