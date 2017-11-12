using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTracker : MonoBehaviour {

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
