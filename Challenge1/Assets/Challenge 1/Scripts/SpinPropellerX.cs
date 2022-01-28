/*
 * Evan Wieland
 * Challenge 1
 * 
 * Spins the plane's prop.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Rotate propeller
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
