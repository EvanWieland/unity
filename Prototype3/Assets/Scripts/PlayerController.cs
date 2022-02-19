/*
 * Evan Wieland
 * Prototype 3
 * 
 * Controls player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        jumpForceMode = ForceMode.Impulse;

        // Modify gravity
        // Physics.gravity *= gravityModifier;

        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        playerAnimator.SetFloat("Speed_f", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            playerAnimator.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;

            // Play dirt particle
            dirtParticle.Play();
        }else if(collision.gameObject.CompareTag("Obstacle")&& !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            // Play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            // Play expolosion particle
            explosionParticle.Play();

            // Play crash noise
            playerAudio.PlayOneShot(crashSound, 1.0f);

            // Stop playing dirt particle
            dirtParticle.Stop();
        }
    }

    public void StopRunning()
    {
        playerAnimator.SetFloat("Speed_f", 0);
    }
}
