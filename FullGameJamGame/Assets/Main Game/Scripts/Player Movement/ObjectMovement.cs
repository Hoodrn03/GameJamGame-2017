using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//--------------------------------------------------
//                      Header
//
//     This is used to make the any object this
//      script is attached to bob up and down. 
//
//--------------------------------------------------

public class ObjectMovement : MonoBehaviour {

    // This is used to assign an interval between moves.
    public float fWait;

    // This is used to assign a speed in which the object will move.
    public float fSpeed;

    // This will be used to check if the object has been spawned.
    public bool bSpawned;

    // Update is called once per frame
    void Update()
    {
        // If Spawned == false :
        if (bSpawned == false)
        {
            // Calls Move : 
            Move();
        }
    }

    // This will initalize the object movement.
    void Move()
    {
        // These will assign random values to the movement speed and wait time
        fWait = UnityEngine.Random.Range(2.0f, 1.0f);
        fSpeed = UnityEngine.Random.Range(0.5f, 0.1f);

        // This sets Spawned to true. 
        bSpawned = true;
        
        // This gets the attached object's ridgid body. 
        GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, fSpeed);

        // This starts the movement Coroutine.
        StartCoroutine("Movement");
    }

    // This coroutine will run its course then repeate when it is finished.
    public IEnumerator Movement()
    {
        // These will be used to call the movement functions  after a set amount of time. 
        yield return new WaitForSeconds(fWait);
        EnemyFloatDown();
        yield return new WaitForSeconds(fWait);
        EnemyFloatUp();
    }

    // This will make the object move down.
    void EnemyFloatDown()
    {
        for (int i = 0; i < 11; i++)
            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, -fSpeed);
    }

    // This will make the object up.
    void EnemyFloatUp()
    {
        for (int i = 0; i < 11; i++)
            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, fSpeed);

        StartCoroutine("Movement");
    }
}

//---------------------------------------------------------------
//                      Footer
//
//              Code Written By Rory Lee
//---------------------------------------------------------------