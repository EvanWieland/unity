/*
 * Evan Wieland
 * Challenge 2
 * 
 * Manages scoring.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreX : MonoBehaviour
{
    public Text textbox;
    public int score = 0;

    private HealthSystemX _healthSystem;

    public GameObject gameWonText;

    // Start is called before the first frame update
    void Start()
    {
        _healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystemX>();
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 5){
            _healthSystem.gameOver = true;
            gameWonText.SetActive(true);
            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                UnityEngine.SceneManagement.SceneManager
                    .LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }else{
            textbox.text = "Score: " + score;
        }
    }
}
