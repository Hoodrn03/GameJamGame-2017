using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                      Header 
//
//      This is used to keep track of the total
//      number of keys which have been spawned throughout 
//      the level. 
//
//--------------------------------------------------------

public class TotalNumberOfKeys : MonoBehaviour {

    // This is the variable which will hold the information about how  many key there are. 
	[SerializeField]
	private int numberOfKeys = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    // This is used to add one to the total number of keys are inside the level,
    // called whenever a new key is spawned. 
	public void addToNumberOfKeys()
	{
		// This will keep track of all of the keys that have been spawned throughout the level. 
		numberOfKeys = numberOfKeys + 1;
	}

	// Used to get the current number of keys inside the level. 

	public int getTotalNumberOfKeys()
	{
		return numberOfKeys;
	}
}

//--------------------------------------------------------
//                  Footer 
//
//          Code Written By Ryan Hood
//--------------------------------------------------------
