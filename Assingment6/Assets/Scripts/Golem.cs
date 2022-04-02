/*
 * Evan Wieland
 * Assignment 6
 * 
 * Make golem
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    public override void TakeDamage()
    {
        Debug.Log("Gollem is dead!");
    }
}
