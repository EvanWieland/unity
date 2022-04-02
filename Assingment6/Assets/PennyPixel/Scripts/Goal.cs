/*
 * Evan Wieland
 * Assignment 5A
 * 
 * Controls the goal
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public CircleCollider2D gemCollider2D;
    public Text winText;
	public Text looseText;
    public Text scoreText;

	public static bool died = false;
	private bool won = false;

	void Update()
    {
		if (died)
		{
			looseText.enabled = true;
			if (Input.GetKeyDown(KeyCode.R))
			{
				ScoreController.score = 0;
				SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
				died = false;
			}
        }
        else
        {
			looseText.enabled = false;
		}

		if (won)
        {
			if (Input.GetKeyDown(KeyCode.N))
			{
				ScoreController.score = 0;

				SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			}
		}
        else
        {
			winText.enabled = false;	
        }
    }

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void GemCollected()
	{
		gemCollider2D.enabled = false;
		gameObject.GetComponent<MeshFilter>().mesh = null;
        ScoreController.score++;
		scoreText.text = "Score: " + ScoreController.score;
		winText.enabled = true;
		won = true;
	}
}
