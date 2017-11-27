using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                      Header
//
//      This is used to keep track of the total number 
//      of collected keys. 
//--------------------------------------------------------

public class KeyTracker : MonoBehaviour {

    // This is a value for the number of collected keys, it will increase
    // if the player collides with a key. 

	[SerializeField]
	private int collectedKeys = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Used to add to the current number of collected keys. 

	public void addToCollectedKeys()
	{
		collectedKeys = collectedKeys + 1;	
	}

	// used to check the current number of collected keys.

	public int getCollectedKeys()
	{
		return collectedKeys;
	}
}

//--------------------------------------------------------
//                      Footer 
//
//            Code Written By Ryan Hood 
//--------------------------------------------------------
