using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--------------------------------------------------------
//                  Header
//
//      This is used to update the number of keys that 
//      are displayed on the screen, allowing for the 
//      player to keep track of how many keys are 
//      left out in the game world.
//
//--------------------------------------------------------

public class KeyTrackerUIScript : MonoBehaviour {

    // THis is used to hold the text that is displayed on the screen. 
    private Text TkeyText;

    // This is used to save the number of keys within this script.
    private int NumOfKeys;

    // This creates an instance of the keyTracker script.
    KeyTracker KeyTracker;

    // This creates an instance of the TotalNumberOfKeys script.
    TotalNumberOfKeys TotalNumberOfKeys;

	// Use this for initialization
	void Start () {

        // This is get the text component of the tKeyText variable, allowing for it to be changed.
        TkeyText = GetComponent<Text>();

        // This gets the script attatched to the gameManager gameObject and saves a reference to it. 
        KeyTracker = GameObject.FindWithTag("GameManager").GetComponent<KeyTracker>();

        // This gets the script attatched to the gameManager gameObject and saves a reference to it.
        TotalNumberOfKeys = GameObject.FindWithTag("GameManager").GetComponent<TotalNumberOfKeys>();
    }
	
	// Update is called once per frame
	void Update () {

        // This updates the local value for number of keys. This minuses the total number of keys 
        // by the number of collected keys to get the number of remaning keys. 
        NumOfKeys = TotalNumberOfKeys.getTotalNumberOfKeys() - KeyTracker.getCollectedKeys();

        // if the number of remaing keys is greater than 0, the player has x number of keys left to find.
        if (NumOfKeys > 0)
        {
            TkeyText.text = "Remaining Keys : " + NumOfKeys.ToString();
        }

        // Otherwise they have all of the key and can leave the level.
        else
        {
            TkeyText.text = "Find the door!";
        }
	}
}

//--------------------------------------------------------
//                  Footer 
//      
//          Code Written By Tom Woodley. 
//--------------------------------------------------------