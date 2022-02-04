/*
 * Evan Wieland
 * Prototype 2
 * 
 * Detects collisions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to prefab projectile 
public class DetectCollisions : MonoBehaviour
{
    private DisplayScore _displayScoreScript;

    private void Start()
    {
        _displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other) {
        _displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
