using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyMovement : MonoBehaviour
{

	[SerializeField]
    private bool bSpawned;

	[SerializeField]
	private GameObject player;
    
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
    void Update()
    {
       if (bSpawned == false)
            Move();
    }
    
	// This is used to move the enemies up and down.

	void Move()
    {
        bSpawned = true;
        GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, 0.2f);
        StartCoroutine("Movement");
    }

	// Used to select if the player is going up or down. 

    public IEnumerator Movement()
    {
        yield return new WaitForSeconds(1.0f);
        EnemyFloatDown();
        yield return new WaitForSeconds(1.0f);
        EnemyFloatUp();
    }
    
	// Used to make the enemy move down

	void EnemyFloatDown()
    {
        for(int i = 0; i < 11; i++)
            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, -0.2f);
    }
    
	// Used to make the enemy move up

	void EnemyFloatUp()
    {
        for (int i = 0; i < 11; i++)
            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, +0.2f);

        StartCoroutine("Movement");
    }

	// Used to kill the player if they get too close. 

    void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
			
            // Respawn Player ...

			player.GetComponent<Respawn> ().spawnPlayer ();

			Debug.Log ("player Respawned");
		
    }
}

