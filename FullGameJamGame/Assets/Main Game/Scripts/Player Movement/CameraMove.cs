using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                         Header
//
//      This will be used  to move the camera and keep
//      it with the player. 
//
//--------------------------------------------------------

public class CameraMove : MonoBehaviour {

    // This will get a reference to the player object.
    GameObject playerObj;

    // This will hold a value for the camera offset. 
    Vector3 cameraOffSet;

    // Use this for initialization
    void Start ()
    {
        // This will find the player's gameObject.
        playerObj = GameObject.Find("Player");

        // This will set the offset for the camera.
        cameraOffSet = new Vector3(0, 3.5f, -8);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // This will update the camera's current possition. 
        transform.position = playerObj.transform.position + cameraOffSet;
	}

    public Vector3 GetCameraOffSet()
    {
        return cameraOffSet;
    }

    public void SetCameraOffSet(Vector3 newCameraOffSet)
    {
        cameraOffSet = newCameraOffSet;
    }
        
}

//--------------------------------------------------------
//                         Header
//
//              Code Written By Ben Sparkes 
//--------------------------------------------------------