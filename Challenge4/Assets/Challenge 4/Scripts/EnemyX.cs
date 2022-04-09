/* Evan Wieland
 * Assingment 7
 * 
 * Manages AI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    static public int enemyGoals = 0;
    public Text loseText;

    // Start is called before the first frame update
    void Start()
    {
        loseText = GameObject.FindGameObjectWithTag("Lose").GetComponent<Text>();
        //loseText.enabled = false;
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("Player Goal");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * SpawnManagerX.difficulty * Time.deltaTime);

        if (loseText.enabled && Input.GetKeyDown(KeyCode.R))
        {
            loseText.enabled = false;
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(
                SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player Goal")
        {
            enemyGoals++;

            if (enemyGoals >= SpawnManagerX.difficulty)
            {
                Debug.Log(enemyGoals + " " + SpawnManagerX.difficulty);
                loseText.enabled = true;
                Time.timeScale = 0;
            }
            Destroy(gameObject);
        }

    }

}
