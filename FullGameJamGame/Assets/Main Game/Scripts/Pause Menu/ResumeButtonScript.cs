using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                         Header
//
//      This will be used to add functionality to the 
//      resume button in on the pause menu. 
//
//--------------------------------------------------------

public class ResumeButtonScript : MonoBehaviour {

    // This is uded to hold a reference to a script
    KeydownScript KeydownScript;

    // This is used to hold a reference to a gameObject.
    GameObject PauseMenu;


    // Use this for initialization
    void Start()
    {
        // This will find the script attacted to a gameObject.
        KeydownScript = GameObject.Find("KeydownScript").GetComponent<KeydownScript>();

        // This will find the game object with the pause menu tag.
        PauseMenu = GameObject.FindWithTag("PauseMenu");
    }

    // This will be called when a button is pressed.
    public void OnClick()
    {
        // These will be used to close the pause menu.
        KeydownScript.isPaused = false;
        PauseMenu.SetActive(false);

        // This will resume the time within the game world.
        Time.timeScale = 1;
    }

	// Update is called once per frame
	void Update () {
		
	}
}

//--------------------------------------------------------
//                         Footer
//
//              Code Written By Tom Woodley
//--------------------------------------------------------