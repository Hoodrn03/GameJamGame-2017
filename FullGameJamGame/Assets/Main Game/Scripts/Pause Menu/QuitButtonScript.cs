using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//--------------------------------------------------------
//                         Header
//
//      This will be used to add functionality to the 
//      quit button in on the pause menu. 
//
//--------------------------------------------------------

public class QuitButtonScript : MonoBehaviour {

    // This is uded to hold a reference to a script
    KeydownScript KeydownScript;

    // This is used to hold a reference to a gameObject.
    GameObject PauseMenu;

    // This is used to hold a reference to a gameObject.
    GravityFlip GravityFlip;

    // Use this for initialization
    void Start ()
    {
        // This will find the script attacted to a gameObject.
        KeydownScript = GameObject.Find("KeydownScript").GetComponent<KeydownScript>();

        // This will find the game object with the water tag.
        GravityFlip = GameObject.FindWithTag("Water").GetComponent<GravityFlip>();

        // This will find the game object with the pause menu tag.
        PauseMenu = GameObject.FindWithTag("PauseMenu");
    }

    // This will be called when a button is pressed.
    public void OnClick()
    {
        // This will load the scene called "menu"
        SceneManager.LoadScene("menu");

        // These will reset variabes within other scripts. 
        KeydownScript.isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GravityFlip.gravity_IsFlipped = false;
        Physics.gravity = new Vector3(0, -9.81f, 0);
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