/*
 * Evan Wieland
 * Challenge 1
 * 
 * Controls trigger zones.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAddScoreOnceX : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && !triggered){
            triggered = true;
            ScoreManagerX.score++;
        }
    }
}