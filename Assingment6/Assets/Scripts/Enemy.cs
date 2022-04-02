/*
 * Evan Wieland
 * Assignment 6
 * 
 * Create enemy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract classes are a form of poly because their exact funcationality is determined
// at runtime.
public abstract class Enemy : MonoBehaviour, IDamageable
{
    public BoxCollider2D dangerCollider;

    public abstract void TakeDamage();

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Make that sucker drop dead
            col.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            Goal.died = true;
            Debug.Log("Player got hit by enemy.");
        }
    }
}
