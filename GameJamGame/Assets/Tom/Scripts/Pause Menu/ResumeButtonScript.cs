using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonScript : MonoBehaviour {

    KeydownScript KeydownScript;
    GameObject PauseMenu;


    // Use this for initialization
    void Start()
    {
        KeydownScript = GameObject.Find("KeydownScript").GetComponent<KeydownScript>();
        PauseMenu = GameObject.Find("Canvas/PauseMenu");
    }


    public void OnClick()
    {
        KeydownScript.isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

	
	
	// Update is called once per frame
	void Update () {
		
	}
}
