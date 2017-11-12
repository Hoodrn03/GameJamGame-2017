using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour {

    KeydownScript KeydownScript;
    GameObject PauseMenu;

    GravityFlip GravityFlip;

    // Use this for initialization
    void Start ()
    {
        KeydownScript = GameObject.Find("KeydownScript").GetComponent<KeydownScript>();
        GravityFlip = GameObject.Find("Water").GetComponent<GravityFlip>();
        PauseMenu = GameObject.Find("Canvas/PauseMenu");
    }


    public void OnClick()
    {
        SceneManager.LoadScene("menu");
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
