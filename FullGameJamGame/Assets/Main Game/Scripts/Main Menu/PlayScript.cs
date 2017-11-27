
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//--------------------------------------------------------
//                  Header 
//
//      This is used to load the first level.
//--------------------------------------------------------

public class PlayScript : MonoBehaviour
{

    // When a button is pressed:
    public void OnClick()
    {
        // Used for debugging :
        // Debug.Log("Play Button Clicked");

        // This will load the level named "LevelOne"
        SceneManager.LoadScene("LevelOne");
    }
}

//--------------------------------------------------------
//                  Footer 
//
//         Code Written By Tom Woodley 
//--------------------------------------------------------
