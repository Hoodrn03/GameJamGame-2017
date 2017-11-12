using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalNumberOfKeys : MonoBehaviour {

	[SerializeField]
	private int numberOfKeys = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void addToNumberOfKeys()
	{

		// This will keep track of all of the keys that have been spawned throughout the level. 
		numberOfKeys = numberOfKeys + 1;
	}

	// Used to get the maximum number of keys. 

	public int getTotalNumberOfKeys()
	{
		return numberOfKeys;
	}

}
