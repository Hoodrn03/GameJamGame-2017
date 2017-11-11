using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private GameObject gameManager;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.name == "Player")
		{
			// Check if the number of keys collected are the corrent number of keys.

			if (gameManager.GetComponent<KeyTracker> ().getCollectedKeys () == gameManager.GetComponent<TotalNumberOfKeys> ().getTotalNumberOfKeys ()) 
			{
				// Load Next Level... 

				Debug.Log("Progress...");

			}

		}
	}
}
