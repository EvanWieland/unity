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

public class Goal : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public CircleCollider2D gemCollider2D;
    public Text winText;
    public Text scoreText;

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void GemCollected()
	{
		gemCollider2D.enabled = false;
		gameObject.SetActive(false);
        ScoreController.score++;
		scoreText.text = "Score: " + ScoreController.score;
		winText.enabled = true;
	}
}
