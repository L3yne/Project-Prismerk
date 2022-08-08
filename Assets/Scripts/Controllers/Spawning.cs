using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour 
{
    
public GameObject Enemy;
public Transform[] Spawner;
public float secondsBetweenSpawn;
public float elapsedTime = 0.0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Debug.Log(true);   
            Instantiate(Enemy, Spawner[0].transform.position, Quaternion.identity);
        }
    }
}
/*
public class Spawning : MonoBehaviour
{
    public GameObject Enemy;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}*/
