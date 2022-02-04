/*
 * Evan Wieland
 * Challenge 2
 * 
 * Manages player controls.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool _canPressKey = true;

    // https://gamedev.stackexchange.com/questions/106370/in-unity-how-do-i-set-up-a-delay-before-an-action
    IEnumerator keyTimer() {
        _canPressKey = false;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        _canPressKey = true;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if(_canPressKey == true && Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(keyTimer());
        };
    }
}
