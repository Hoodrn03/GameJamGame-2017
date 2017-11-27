using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                      Header
//
//      This will be used to display the pause menu
//      for the game.
//
//--------------------------------------------------------

public class KeydownScript : MonoBehaviour {

    // This local varibale will be used to check if the pause menu 
    //  is currently active.
    public bool isPaused = false;

    // This creates a reference for a gameObject.
    GameObject PauseMenu;
    
	// Use this for initialization
	void Start ()
    {
        // Setting the pause menu not to show on launch

        // This finds the object with the tag for pause menu.
        PauseMenu = GameObject.FindWithTag("PauseMenu");

        PauseMenu.SetActive( false);
    }

    // This is used to display the pause menu.
    private void ShowPauseMenu()
    {
        // This sets the pause menu to be active.
        PauseMenu.SetActive(true);

        // This lets the system know that the pause menu is currently
        // active.
        isPaused = true;

        // This makes the gameworld pause. 
        Time.timeScale = 0;
    }

    // This closes the pause menu.
    private void RemovePauseMenu()
    {
        // This deactivates the pause menu.
        PauseMenu.SetActive(false);

        // This allows for the system to know the pause menu is no longer 
        // being displayed.
        isPaused = false;

        // This resumes the gameworld.
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {

        // This will check for input from the player
        if (Input.GetKeyDown("escape") && isPaused == false)
        { 
            ShowPauseMenu();
        }
        else if (Input.GetKeyDown("escape") && isPaused == true)
        {
            RemovePauseMenu();
        }
	}
}

//--------------------------------------------------------
//                      Footer
//
//              Code Written By Tom Woodley.
//--------------------------------------------------------