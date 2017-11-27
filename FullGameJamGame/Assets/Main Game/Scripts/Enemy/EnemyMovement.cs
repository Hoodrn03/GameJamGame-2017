using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------
//                      Header
//
//     This is used to make the enemies bob up and 
//     down, it is also used to detect if the 
//      player has gotten too close to the enemy.
//
//--------------------------------------------------


public class EnemyMovement : MonoBehaviour
{

    // This is used to check if the enemy has spawned.

	[SerializeField]
    private bool bSpawned;

    // This is used to get a refernce to the player's game object. 

	[SerializeField]
	private GameObject player;
    
    // This is called at the very beginning of the game :

	void Start()
	{
        // This will look for the gameobject with the player tag and set the player's game object to that. 

		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame

    void Update()
    {
        // This will check if the enemy has been spawned, if they haven't the code won't run.

        if (bSpawned == false)
        {
            // This will call the private function move. 

            Move();
        }
    }
    
	// This is used to move the enemies up and down.

	void Move()
    {
        // This makes bSpawned true to make it always bob up and down after being spawned.

        bSpawned = true;

        // This will get the enemy's redgid body allowing for it to be moved. 

        GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, 0.2f);

        // This will start a new Coroutine for "Movement". 

        StartCoroutine("Movement");
    }

	// This coroutine is used to constantly make the enemy move up then down after a 1.0 second pause. 

    public IEnumerator Movement()
    {
        // This will wait for 1 second before moving on. 

        yield return new WaitForSeconds(1.0f);

        // This will call the EnemyFloatDown function.

        EnemyFloatDown();

        // This will then wait for another second before moving on.

        yield return new WaitForSeconds(1.0f);

        // This calls the EnemyFloatUp function.

        EnemyFloatUp();

        // After a coroutine has finished it will then go back to the beggining and perform the same actions. 
    }

    // Used to make the enemy move down

    void EnemyFloatDown()
    {
        // This will loop 11 times

        for (int i = 0; i < 11; i++)
        {

            // This gets the enemy's ridgid body and moves it down

            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, -0.2f);
        }
    }
    
	// Used to make the enemy move up

	void EnemyFloatUp()
    {
        // This will loop 11 times

        for (int i = 0; i < 11; i++)
        {

            // This gets the enemy's ridgid body and moves it up

            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, +0.2f);
        }

        // This will then start the coroutine "Movement"

        StartCoroutine("Movement");
    }

	// Used to kill the player if they get too close. 

    void OnTriggerEnter(Collider other)
	{
        // If the enemy collides with the player :

        if (other.name == "Player")
        {
            // This gets the respawn script from the player.

            player.GetComponent<Respawn>().spawnPlayer();

            // Used for debugging :

            // Debug.Log("player Respawned");
        }
    }
}

//---------------------------------------------------------------
//                      Footer
//
//              Code Written By Rory Lee
//---------------------------------------------------------------