/*
 * Evan Wieland
 * Prototype 1
 * 
 * Controls trigger zones.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attrach this to player
public class PlayerEnterTrigger : MonoBehaviour
{
    // When player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerZone")){
            ScoreManager.score++;
        }
    }
}
