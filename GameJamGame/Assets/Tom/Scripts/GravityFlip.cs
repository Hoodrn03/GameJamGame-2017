using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GravityFlip : MonoBehaviour {

    //PlayerMovement PlayerMovement;

    bool gravity_IsFlipped = false;

    [SerializeField]
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider collider)
    {
        PlayerMovement PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (collider.name == "Player")
        {
            PlayerMovement.jumpHeight = -PlayerMovement.jumpHeight;
            if (gravity_IsFlipped == false)
            
            {
                Physics.gravity = new Vector3(0, 9.81f, 0);
                
                gravity_IsFlipped = true;
            }
            else
            {
                gravity_IsFlipped = false;
                Physics.gravity = new Vector3(0, -9.81f, 0);

            }
        }
    }

   
	
	// Update is called once per frame
	void Update () {
		
	}
}
