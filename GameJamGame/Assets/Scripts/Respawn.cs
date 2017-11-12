using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
	
	void Start()
	{


	}
	void Update()
	{
		var spawnpos = GameObject.Find("Spawn").transform.position;
		if (Input.GetKeyDown("r")){
			transform.localPosition = spawnpos; 
		}
	}


}