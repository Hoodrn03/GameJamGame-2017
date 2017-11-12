using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectMovement : MonoBehaviour {
    public float fWait;
    public float fSpeed;
    public bool bSpawned;
    // Update is called once per frame
    void Update()
    {
        if (bSpawned == false)
            Move();
    }
    void Move()
    {
        fWait = UnityEngine.Random.Range(2.0f, 1.0f);
        fSpeed = UnityEngine.Random.Range(0.5f, 0.1f);
        bSpawned = true;
        GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, fSpeed);
        StartCoroutine("Movement");
    }
    public IEnumerator Movement()
    {
        yield return new WaitForSeconds(fWait);
        EnemyFloatDown();
        yield return new WaitForSeconds(fWait);
        EnemyFloatUp();
    }
    void EnemyFloatDown()
    {
        for (int i = 0; i < 11; i++)
            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, -fSpeed);
    }
    void EnemyFloatUp()
    {
        for (int i = 0; i < 11; i++)
            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, fSpeed);

        StartCoroutine("Movement");
    }
}
