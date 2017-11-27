using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

//--------------------------------------------------------
//              Header
//
//      This code is used to spawn the enemies at points
//      placed within the map.
//
//--------------------------------------------------------

public class EnemySpawnScript : MonoBehaviour
{

    // This is used to allow the code to know what is being spawned, its public allowing for the game object to easily 
    // attatched to the script

    public GameObject Enemy;

    // This is the location in the map the enemy will be spawned at.

    public Transform T_SpawnLocation;
	
    // Use this for initialization
	void Start () {

        // This is the process in which the game object will be spawned. 

		Instantiate(Enemy, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//--------------------------------------------------------
//                  Footer
//      
//             Code Written By Rory Lee
//--------------------------------------------------------
