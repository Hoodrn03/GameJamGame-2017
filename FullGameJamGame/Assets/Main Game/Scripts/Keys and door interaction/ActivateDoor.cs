using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//--------------------------------------------------------
//                     Header 
//
//  This will be used to give the player an end point,
//  the player will use to door to reach either the end
//  screen or another level. 
//
//--------------------------------------------------------

public class ActivateDoor : MonoBehaviour {

    // This will hold a refernce to the player's game object. 

	[SerializeField]
	private GameObject player;

    // This will hold a refernce to the gameManager object. 

	[SerializeField]
	private GameObject gameManager;

    // This creates a new instance of the gravity flip class.

    GravityFlip GravityFlip;

    // Use this for initialization
    void Start () {

        // This looks for the object marked with the gameManager tag.

		gameManager = GameObject.FindWithTag ("GameManager");

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider col)
	{
        // If the player collides with the door : 

		if (col.name == "Player")
		{
			// Check if the number of keys collected are the corrent number of keys.

			if (gameManager.GetComponent<KeyTracker> ().getCollectedKeys () == gameManager.GetComponent<TotalNumberOfKeys> ().getTotalNumberOfKeys ()) 
			{
                // Used for debugging :

                // Debug.Log("Progress...");

                // This will get the component tagged with "Water" and assign the object to gravity flip.

                GravityFlip = GameObject.FindWithTag("Water").GetComponent<GravityFlip>();

                // This resets the bool isFlipped to false making the player upright.

                GravityFlip.ResetFlip();

                // This loads the end screen. 

                SceneManager.LoadScene("finish");

            }

		}
	}
}

//--------------------------------------------------------
//                      Footer 
//
//              Code Written By Ryan Hood
//--------------------------------------------------------
