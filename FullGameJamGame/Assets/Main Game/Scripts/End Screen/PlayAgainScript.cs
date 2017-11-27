using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-----------------------------------------------------
//                      Header
//
//  This will be used to play the first level when a 
//  button is pressed on the user interface. This 
//  will be attatched to a button on the end screen.
//
//-----------------------------------------------------


public class PlayAgainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // When a button is pressed : 

    public void OnClick()
    {
        // The scene manager will load the scene with the name "LevelOne"

        SceneManager.LoadScene("LevelOne");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}


//----------------------------------------------------
//                      Footer
//
//         Code Written By Tom Woodley
//----------------------------------------------------