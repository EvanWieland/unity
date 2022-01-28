/*
 * Evan Wieland
 * Challenge 1
 * 
 * Player looses if out of bounds.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnOutOfBoundsX : MonoBehaviour
{
     // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -51 || transform.position.y > 80){
            ScoreManagerX.gameOver = true;
        }
    }
}
