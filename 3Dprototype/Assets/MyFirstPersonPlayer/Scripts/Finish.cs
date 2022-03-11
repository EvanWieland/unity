/* Evan Wieland
 * Project 5B
 * 
 * Controls finish
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Text winText;

    void Awake()
    {
        winText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        winText.enabled = true;
    }
}
