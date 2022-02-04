/*
 * Evan Wieland
 * Prototype 2
 * 
 * Spawns animals randomly.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // Attach prefabs to this array
    public GameObject[] prefabsToSpawn;

    private float _leftBount = -14;
    private float _rightBount = 14;
    private float _spawnPosz = 20;

    public bool gameOver = false;

    public HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        StartCoroutine(SpawnPrefabWithCoroutine());
        // InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);
    }
    
    IEnumerator SpawnPrefabWithCoroutine()
    {
        // Adds 3 sec delay to first prefab spawn
        yield return new WaitForSeconds(3f);

        // Continue while game not over
        while(!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            // Wait random sec
            float randomDelay = Random.Range(1.5f, 3.0f);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    void SpawnRandomPrefab()
    {
        // Picks random index btwn 0 and array len
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        // Random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(_leftBount, _rightBount), 0, _spawnPosz);

        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
