/*
 * Evan Wieland
 * Prototype 2
 * 
 * Destroys out of bounds objects.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add script to the food and animal prefabs
public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem _healthSystem;

    private void Start() {
        _healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();    
    }

    private void Update()
    {
        // Seperating the food from the animals going out of bounds
        
        // Food
        if(transform.position.z > topBound) {
            Destroy(gameObject);
        }

        // Animals
        if(transform.position.z < bottomBound){
            
            _healthSystem.TakeDamage();

            Destroy(gameObject);
        }
    
    }
}
