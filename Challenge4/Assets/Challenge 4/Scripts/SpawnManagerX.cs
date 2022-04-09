/* Evan Wieland
 * Assingment 7
 * 
 * Manages spawning
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int waveCount = 1;
    public int waveBench = 1;
    static public int difficulty;

    public Text waveText;
    public Text winText;
    public Text rulesText;

    static public int enemyGoals = 0;

    public GameObject player;

    void Start()
    {
        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (rulesText.enabled)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rulesText.enabled = false;
                Time.timeScale = 1;
            }

        }

        difficulty = waveCount;

       // Debug.Log(enemyGoals + " " + waveBench);

        waveText.text = "Wave: " + waveCount;

        if(waveCount >= 10)
        {
            winText.enabled = true;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadSceneAsync(
                    SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            winText.enabled = false;
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        ResetPlayerPosition(); // put player back at start

        EnemyX.enemyGoals = 0;
    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
