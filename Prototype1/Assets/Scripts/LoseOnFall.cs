/*
 * Evan Wieland
 * Prototype 1
 * 
 * Makes player loose on fall.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to player
public class LoseOnFall : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1){
            ScoreManager.gameOver = true;
        }
    }
}
