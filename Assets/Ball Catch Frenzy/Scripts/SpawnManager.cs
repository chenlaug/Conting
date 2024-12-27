using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] organsPrefabs;
    public float spawnRangeX = 7.12f;
    public int startDelay = 2;
    public float spawnInterval = 1.5f;
    private GameManager gameManager;
    private bool isSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.isGameActive == 1)
        {
            InvokeRepeating("SpawnRandomOrgans", startDelay, spawnInterval);
        }
    }

    void Update()
    {
        if (gameManager.isGameActive == 1 && !isSpawning)
        {
            StartSpawn();
        } else if (gameManager.isGameActive == 3 && isSpawning)
        {
            StopSpawn();
        }
    }
    void SpawnRandomOrgans()
    {
        int organIndex = Random.Range(0, organsPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 10.90f, -6.4f);
        Instantiate(organsPrefabs[organIndex], spawnPos, organsPrefabs[organIndex].transform.rotation);
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnRandomOrgans", startDelay, spawnInterval);
        isSpawning = true;

    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnRandomOrgans");
        isSpawning = false;
    }
}
