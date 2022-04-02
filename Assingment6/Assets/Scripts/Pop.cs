/*
 * Evan Wieland
 * Assignment 6
 * 
 * Pop enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    public GameObject toPop;
	public GameObject collectedParticleSystem;
	private float durationOfCollectedParticleSystem;

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("POP");
			PopEnemy();

		}
    }

	void PopEnemy()
	{
		//gemCollider2D.enabled = false;
		//gemVisuals.SetActive(false);
		toPop.GetComponent<PolygonCollider2D>().enabled = false;
		collectedParticleSystem.SetActive(true);
		Invoke("DeactivateEnemyObject", durationOfCollectedParticleSystem);
		//ScoreController.score++;
		//scoreText.text = "Score: " + ScoreController.score;
	}

	void DeactivateEnemyObject()
	{
		toPop.SetActive(false);
		gameObject.SetActive(false);
	}
}
