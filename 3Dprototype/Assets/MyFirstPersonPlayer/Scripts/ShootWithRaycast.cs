/* Evan Wieland
 * Project 5B
 * 
 * Handles shooting with raycast
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;

    public ParticleSystem muzzleFlash;

    public float hitForce = 10f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
            Shoot();
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hitinfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitinfo, range))
        {
            Target target = hitinfo.transform.gameObject.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if(hitinfo.rigidbody != null)
            {
                hitinfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
