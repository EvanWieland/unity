/* Evan Wieland
 * Assingment 7
 * 
 * Manages player
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody plalayerRb;
    public float speed = 5.0f;
    private float fowardInput;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    public Text winText;
    public Text loseTxt;
    public bool win = false;
    public bool loose = false;
    public Text rulesText;

    // Start is called before the first frame update
    void Start()
    {
        plalayerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        fowardInput = Input.GetAxis("Vertical");
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (rulesText.enabled)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rulesText.enabled = false;
                Time.timeScale = 1;
            }
               
        }

        if (plalayerRb.position.y < -1)
        {
            loseTxt.enabled = true;
            CheckForR();
        }
        else if(SpawnManager.waveNumber >= 10)
        {
            winText.enabled = true;
            CheckForR();
        }
        else
        {
            winText.enabled = false;
            loseTxt.enabled = false;
        }
    }

    void CheckForR()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnManager.waveNumber = 1;
            SceneManager.LoadSceneAsync(
                SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        plalayerRb.AddForce(focalPoint.transform.forward * speed * fowardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdowRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdowRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup); 
        
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
