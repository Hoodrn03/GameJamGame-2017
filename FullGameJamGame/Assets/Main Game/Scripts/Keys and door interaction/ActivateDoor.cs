using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateDoor : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private GameObject gameManager;

    GravityFlip GravityFlip;

    // Use this for initialization
    void Start () {

		gameManager = GameObject.FindWithTag ("GameManager");

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
                GravityFlip = GameObject.FindWithTag("Water").GetComponent<GravityFlip>();
                GravityFlip.gravity_IsFlipped = false;
                Physics.gravity = new Vector3(0, -9.81f, 0);
                SceneManager.LoadScene("finish");

            }

		}
	}
}
