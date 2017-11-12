using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnClick()
    {
        SceneManager.LoadScene("LevelOne");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
