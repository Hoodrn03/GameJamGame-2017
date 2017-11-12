using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {

    //private Animation anim;
    private Animator anim;

    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		if (anim.isInitialized)
        {
           Debug.Log("Y");
        }
	}
}
