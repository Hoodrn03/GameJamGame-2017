using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeydownScript : MonoBehaviour {

    public bool isPaused = false;
    GameObject PauseMenu;
    
	// Use this for initialization
	void Start ()
    {
        // Setting the pause menu not to show on launch

        PauseMenu = GameObject.Find("Canvas/PauseMenu");
        PauseMenu.SetActive( false);
    }


    private void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    private void RemovePauseMenu()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
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
