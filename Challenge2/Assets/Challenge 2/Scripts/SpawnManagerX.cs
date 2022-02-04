/*
 * Evan Wieland
 * Challenge 2
 * 
 * Manages spawn.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private HealthSystemX _healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        _healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystemX>();

        StartCoroutine(SpawnPrefabWithCoroutine());
    }

    IEnumerator SpawnPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(3f);
        
        Debug.Log(_healthSystem.gameOver);

        while(!_healthSystem.gameOver)
        {   
            SpawnRandomBall();
            // Wait random time
            float randomDelay = Random.Range(3f, 5f);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int preFabIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[preFabIndex], spawnPos, ballPrefabs[preFabIndex].transform.rotation);
    }

}
