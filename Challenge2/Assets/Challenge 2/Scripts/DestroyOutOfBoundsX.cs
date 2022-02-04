/*
 * Evan Wieland
 * Challange 2
 * 
 * Manages out of bounds.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    public HealthSystemX _healthSystem;

    void Start()
    {
        _healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystemX>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        
        // Destroy balls if y position is less than bottomLimit
        if (transform.position.y < bottomLimit)
        {
            _healthSystem.TakeDamage();
            Destroy(gameObject);
        }

    }
}
