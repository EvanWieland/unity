/*
 * Evan Wieland
 * Challenge 2
 * 
 * Manages collision detection.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private DisplayScoreX _displayScoreScript;

    private void Start(){
        _displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScoreX>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _displayScoreScript.score++;
        Destroy(gameObject);
    }
}
