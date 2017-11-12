using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTrackerUIScript : MonoBehaviour {

    private Text TkeyText;

    private int NumOfKeys;
    KeyTracker KeyTracker;
    TotalNumberOfKeys TotalNumberOfKeys;

	// Use this for initialization
	void Start () {

        TkeyText = GetComponent<Text>();
        KeyTracker = GameObject.FindWithTag("GameManager").GetComponent<KeyTracker>();
        TotalNumberOfKeys = GameObject.FindWithTag("GameManager").GetComponent<TotalNumberOfKeys>();
    }
	
	// Update is called once per frame
	void Update () {


        NumOfKeys = TotalNumberOfKeys.getTotalNumberOfKeys() - KeyTracker.getCollectedKeys();
        if (NumOfKeys > 0)
        {
            TkeyText.text = "Remaining Keys : " + NumOfKeys.ToString();
        }
        else
        {
            TkeyText.text = "Find the door!";
        }
		
	}
}
