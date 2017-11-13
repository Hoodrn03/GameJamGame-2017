using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
	[SerializeField]
	private GameObject spawnpos;

	GravityFlip GravityFlip;

	void Start()
	{
		var spawnpos = GameObject.Find("Spawn").transform.position;
		GravityFlip = GameObject.FindWithTag("Water").GetComponent<GravityFlip>();
	}
	void Update()
	{
		if (Input.GetKeyDown("r")){

			spawnPlayer ();

			Debug.Log ("Kill Yourself");
		}		
	}

	public int spawnPlayer()
	{
		transform.localPosition = spawnpos.transform.position;
		GravityFlip.gravity_IsFlipped = false;
		Physics.gravity = new Vector3(0, -9.81f, 0);

		return 0;
	}
}