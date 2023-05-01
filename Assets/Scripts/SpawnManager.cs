using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[]obstaclePrefabs;
    private float spawnRangeX = 4;
    private float spawnPosZ = 20;
    private float startDelay = 1;
    private float spawnInterval = 1.00f;

    public GameObject powerup1Prefab;
    public GameObject powerup2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // random obstacle spawner

    void SpawnRandomObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
