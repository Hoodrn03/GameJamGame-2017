using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EnemySpawnScript : MonoBehaviour {
    public GameObject Enemy;
	public Transform T_SpawnLocation;
	// Use this for initialization
	void Start () {

		Instantiate(Enemy, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
